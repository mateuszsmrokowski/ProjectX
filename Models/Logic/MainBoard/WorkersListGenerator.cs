using Microsoft.Web.Administration;
using ProjectX.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using ProjectX.Data;
using Microsoft.EntityFrameworkCore.Internal;

namespace ProjectX.Models.Logic.MainBoard
{
    public interface IGenerateWorkersList
    {
        WorkersViewModel GenerateWorkersData(WorkersContext workersContext);
    };

    public class WorkersListGenerator : IGenerateWorkersList
    {
        public WorkersViewModel GenerateWorkersData(WorkersContext workersContext)
        {
            //var daysData = new Days
            //{
            //    Day = DateTime.Now
            //};

            //workersContext.Days.Add(daysData);
            //daysData = new Days
            //{
            //    Day = DateTime.Now.AddDays(1)
            //};

            //workersContext.Days.Add(daysData);
            //workersContext.SaveChanges();
            //var testCheck1 = workersContext.DaysOfWork.ToList();



            //var workersData = new Workers
            //{
            //    Name = "Antek",
            //    Surname = "Walentynowicz",
            //    PhoneNumber = "234432234",
            //    Position = "Medic",
            //    Shift = "2",
            //    Unity = "1",

            //};

            //workersContext.Workers.Add(workersData);

            //workersData = new Workers
            //{
            //    Name = "Bartosz",
            //    Surname = "Walenrod",
            //    PhoneNumber = "345654789",
            //    Position = "Enginerr",
            //    Shift = "1",
            //    Unity = "2",

            //};

            //workersContext.Workers.Add(workersData);
            var dateTime = DateTime.Now;

            var allWorkersList = workersContext.Workers.Select(t => t);
            var dayId = workersContext.Days
                .Where(y => y.Day.Day == dateTime.Day || y.Day.Day == dateTime.AddDays(1).Day);

            var joinAll = workersContext.DaysOfWork.Select(t => t);


            //.Join(allWorkersList, Workerss => Workerss, Workers => Workers.Id, (Workerss, Workers) => new { WorkerName = Workers.Name, UnityRank = Workerss. });
            var query = from i in joinAll
                        join x in dayId on i.DayId equals x.Id
                        join y in allWorkersList on i.WorkerId equals y.Id
                        select new { y.Name, y.Surname, y.Position, i.Shift, i.Unity, x.Day };
            var data = new WorkersViewModel
            {
                AllWorkersList = allWorkersList.ToList(),
                //WorkersAssigmentData = query.ToList();
            };

            return data;
        }

}


}
