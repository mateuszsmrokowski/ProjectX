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

            var allWorkersList = workersContext.Workers.Select(t => t).ToList();
            var daysOfWorkIds = workersContext.Days
                //.Where(y => y.Day.Day == dateTime.Day || y.Day.Day == dateTime.AddDays(1).Day)
                .ToList();

            var dayOfWorkData = workersContext.DaysOfWork.Select(t => t).ToList();

            var workersAssigmentData = dayOfWorkData.Join(daysOfWorkIds,
                dw => dw.DayId,
                d => d.Id,
                (dw, d) => new { d.Day, dw.Unity, dw.Shift, dw.WorkerId })
                .Join(allWorkersList,
                dw => dw.WorkerId,
                wc => wc.Id,
                (dw, wc) => new { wc.Name, wc.Surname, wc.Position, dw.Day, dw.Shift, dw.Unity })
                .Select( x => new WorkersAssigmentData { Name = x.Name, Surname = x.Surname, Position = x.Position, Shift = x.Shift, Unity = x.Unity, Day = x.Day })
                .ToList();
          


            var data = new WorkersViewModel
            {
                AllWorkersList = allWorkersList,
                WorkersAssigmentData = workersAssigmentData
            };

            return data;
        }

    }


}
