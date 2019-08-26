using ProjectX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.ViewModels
{
    public class WorkersViewModel
    {
        public List<Workers> AllWorkersList { get; set; }
        public List<WorkersAssigmentData> WorkersAssigmentData { get; set; }
    }
}
