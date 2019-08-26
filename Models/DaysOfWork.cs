using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Models
{
    public class DaysOfWork
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public int DayId { get; set; }
        public int Unity { get; set; }
        public int Shift { get; set; }
    }
}
