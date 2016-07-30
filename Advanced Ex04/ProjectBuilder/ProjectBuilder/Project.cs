using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectBuilder
{
    class Project
    {
        private readonly List<Task> _dependentcyBuilders = new List<Task>();
        private Task<int> _task;

        public Project(int id)
        {
            _task = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                return id;
            });
        }

        public Task<int> Builder()
        {
            return _task;
        }

        public List<Task> DependentcyBuilders
        {
            get
            {
                return _dependentcyBuilders;
            }
        }
    }
}
