using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XLinq
{
    public class Xml
    {
        private XElement xmlElement;

        public Xml()
        {
            xmlElement = new XElement("Types",
                from type in typeof(string).Assembly.GetTypes()
                where type.IsClass && type.IsPublic
                select new XElement("Type",
                new XAttribute("FullName", type.Name),
                new XElement("Properties",
                    from prop in type.GetProperties()
                    where (prop.CanRead || prop.CanWrite)
                    select new XElement("Property",
                        new XAttribute("Name", prop.Name),
                        new XAttribute("Type", prop.GetType().ToString()))),
                new XElement("Methods",
                    from method in type.GetMethods()
                    where method.IsPublic
                    && method.DeclaringType == type
                    select new XElement("Method",
                        new XAttribute("Name", method.Name),
                        new XAttribute("ReturnType", method.ReturnType),
                new XElement("Parameters",
                    from parameter in method.GetParameters()
                    select new XElement("Parameter",
                        new XAttribute("Name", parameter.Name),
                        new XAttribute("Type", parameter.GetType())))))));
        }

        public List<string> ListOfTypesWithNoProp()
        {
            var list = new List<string>();
            var listOfTypesWithNoProp = from type in xmlElement.Elements()
                                        where type.Element("Properties").Element("Property") == null
                                        orderby (string)type.Attribute("FullName")
                                        select type;

            list.Add($"Amount of types with out properties = {listOfTypesWithNoProp.Count()}");
            foreach (var item in listOfTypesWithNoProp)
            {
                list.Add(item.Attribute("FullName").ToString());
            }

            return list;
        }

        public int AmountOfMethodsNotInherited()
        {
            var amountOfMethodsNotInherited =
            (from method in xmlElement.Descendants("Method")
             select method).Count();

            return amountOfMethodsNotInherited;
        }

        public int PropertiesAmount()
        {
            var propAmount = (from prop in xmlElement.Descendants("Property")
                 select prop).Count();

            return propAmount;
        }

        public string CommonParameter()
        {
            var commonParameter = (from type in xmlElement.Descendants("Parameter")
                group type by (type.Attributes("Type"))
                into types
                orderby (string)types.Key.First() descending
                select types.First().Attribute("Type")).First();

            return commonParameter.ToString();
        }

        public List<string> NumberOfMethodsAndProperties()
        {
            var list = new List<string>();
            var numberOfMethodsAndProp = from type in xmlElement.Elements()
                orderby type.Descendants("Method").Count() descending
                select new
                {
                    Type = type.Attribute("FullName"),
                    NumOfMethods = type.Descendants("Method").Count(),
                    NumOfProperties = type.Descendants("Property").Count()
                };

            foreach (var item in numberOfMethodsAndProp)
            {
                list.Add(item.ToString());
            }

            return list;
        }

        public void Grouping()
        {
            var query = (from type in xmlElement.Elements()
                         group type by type.Element("Methods").Elements("Method").Count())
             .OrderByDescending(grop => grop.Key)
             .OrderBy(grop => grop.Elements("FullName"));
        }
    }
}
