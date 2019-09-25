using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Models
{
    public class WorkersAssigmentData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public int Unity { get; set; }
        public int Shift { get; set; }
        public int Reserv { get; set; }
        public DateTime Day { get; set; }
    }
}
