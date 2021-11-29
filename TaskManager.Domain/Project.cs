using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain
{
    public class Project
    {
        public Guid ProjectID { get; set; }
        public string PName { get; set; }
        public List<Mission> Missions { get; set; }
    }
}
