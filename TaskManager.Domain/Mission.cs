using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain
{
    public class Mission
    {
        public Guid MissionID { get; set; }
        public string MName { get; set; }
        public string MStatus { get; set; }
        public string MType { get; set; }
        public string MDescription { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Guid ProjectID { get; set; }
        public Project Project { get; set; }
        public Guid EmployeeID { get; set; }
        public Employee Employee { get; set; }
    }
}
