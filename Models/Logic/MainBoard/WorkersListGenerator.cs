using ProjectX.Models.Logic.Dtos;
using ProjectX.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Models.Logic.MainBoard
{
    public interface IGenerateWorkersList
    {
        Workers GenerateWorkersList();
    };

    public class WorkersListGenerator : IGenerateWorkersList
    {
        public Workers GenerateWorkersList()
        {
            var data = new Workers();
            data.WorkersData = new List<WorkersDto> { new WorkersDto { Name = "Ziom1", Surname = "Z2", PhoneNumber = "234432234", Position = "Dir", DayOfWork = new List<DateTime> { DateTime.Now } }  };
            data.WorkersData.Add(new WorkersDto { Name = "Ziom2", Surname = "Z2", PhoneNumber = "234432234", Position = "Knur", DayOfWork = new List<DateTime> { DateTime.Now } });
            data.WorkersData.Add(new WorkersDto { Name = "Ziom3", Surname = "Z3", PhoneNumber = "234432234", Position = "Gbur", DayOfWork = new List<DateTime> { DateTime.Now } });

            return data;
        }

    }


}
