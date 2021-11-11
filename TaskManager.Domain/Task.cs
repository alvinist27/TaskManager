using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain
{
    public class Task
    {
        public Guid TaskID { get; set; }
        public string TName { get; set; }
        public string TStatus { get; set; }
        public string TType { get; set; }
        public string TDescription { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Guid ProjectID { get; set; }
        public Project Project { get; set; }
        public Guid EmployeeID { get; set; }
        public Employee Employee { get; set; }
    }
}