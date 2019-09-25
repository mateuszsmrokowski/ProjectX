using ProjectX.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Models.Logic.MainBoard
{
    public interface IWorkerBoardUpdate
    {
        void UpdateWorkersBoard(WorkersContext workersContext, int dayId, int workerId, int shift, int unity, int resevr);
    };
    public class WorkerBoardUpdate : IWorkerBoardUpdate
    {
        public void UpdateWorkersBoard(WorkersContext workersContext, int dayId, int workerId, int shift, int unity, int resevr)
        {
            var workerData = new DaysOfWork
            {
                DayId = dayId,
                WorkerId = workerId,
                Shift = shift,
                Unity = unity,
                Reserv = resevr
            };

            workersContext.Add(workerData);
            workersContext.SaveChanges();
        }
    }
}
