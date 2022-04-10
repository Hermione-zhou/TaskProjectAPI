using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class TaskDetails
    {
        public int TaskDetailsId { get; set; }
        public string Task { get; set; }
        public int Priority { get; set; }
        public string Description { get; set; }
        public string By_who { get; set; }
        public int Stage { get; set; }
    }
}
