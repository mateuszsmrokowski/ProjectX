using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Models.Logic.Dtos
{
    public class WorkersDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public List<DateTime> DayOfWork { get; set; }
        public string Unit { get; set; }
        public string Shift { get; set; }
    }
}
