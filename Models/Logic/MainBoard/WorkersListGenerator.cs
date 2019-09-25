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
            var dateTime = DateTime.Now;

            var allWorkersList = workersContext.Workers.Select(t => t)
                .ToList();
            var daysOfWorkIds = workersContext.Days.ToList();
            var dayOfWorkData = workersContext.DaysOfWork.Select(t => t)
                .ToList();

            var workersAssigmentData = dayOfWorkData
                .Join(daysOfWorkIds, dw => dw.DayId, d => d.Id,
                (dw, d) => new { d.Day, dw.Unity, dw.Shift, dw.WorkerId, dw.Reserv })
                .Join(allWorkersList,dw => dw.WorkerId,wc => wc.Id,
                (dw, wc) => new { wc.Id, wc.Name, wc.Surname, wc.Position, dw.Day, dw.Shift, dw.Unity, dw.Reserv})
                .Select( x => new WorkersAssigmentData { Id = x.Id, Name = x.Name, Surname = x.Surname, Position = x.Position, Shift = x.Shift, Unity = x.Unity, Day = x.Day, Reserv = x.Reserv })
                .ToList();

            return new WorkersViewModel
            {
                AllWorkersList = allWorkersList,
                WorkersAssigmentData = workersAssigmentData
            };

        }

    }


}
