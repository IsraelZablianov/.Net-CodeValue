using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBuilder
{
    class ProjectBuilder
    {
        public void ExcecuteProjects(List<Project> listOfProjects)
        {
            Parallel.ForEach<Project>(listOfProjects, proj =>
            {
                if (proj.DependentcyBuilders.Count == 0)
                {
                    proj.Builder().Start();
                    Console.WriteLine($"Id = {proj.Builder().Result}");
                }
                else
                {
                    Task.Factory.ContinueWhenAll(proj.DependentcyBuilders.ToArray(),
                        _ =>
                        {
                            proj.Builder().Start();
                            Console.WriteLine($"Id = {proj.Builder().Result}");
                        });
                }
            });
        }
    }
}
