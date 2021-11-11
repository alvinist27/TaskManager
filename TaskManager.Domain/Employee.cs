using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain
{
    public class Employee
    {
        public Guid EmployeeID { get; set; }
        public string EName { get; set; }
        public string EWork { get; set; }
        public List<Task> Tasks { get; set; }
    }
}
