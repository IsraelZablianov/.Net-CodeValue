using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var project1 = new Project(1);
            var project2 = new Project(2);
            var project3 = new Project(3);
            var project4 = new Project(4);
            var project5 = new Project(5);
            var project6 = new Project(6);
            var project7 = new Project(7);
            var project8 = new Project(8);
            var listOfProjects = new List<Project>();

            project4.DependentcyBuilders.Add(project1.Builder());

            project5.DependentcyBuilders.Add(project1.Builder());
            project5.DependentcyBuilders.Add(project2.Builder());
            project5.DependentcyBuilders.Add(project3.Builder());

            project6.DependentcyBuilders.Add(project3.Builder());
            project6.DependentcyBuilders.Add(project4.Builder());

            project7.DependentcyBuilders.Add(project5.Builder());
            project7.DependentcyBuilders.Add(project6.Builder());

            project8.DependentcyBuilders.Add(project5.Builder());

            listOfProjects.Add(project1);
            listOfProjects.Add(project2);
            listOfProjects.Add(project3);
            listOfProjects.Add(project4);
            listOfProjects.Add(project5);
            listOfProjects.Add(project6);
            listOfProjects.Add(project7);
            listOfProjects.Add(project8);

            var projectBuilder = new ProjectBuilder();
            projectBuilder.ExcecuteProjects(listOfProjects);

            Console.ReadLine();
        }
    }
}
