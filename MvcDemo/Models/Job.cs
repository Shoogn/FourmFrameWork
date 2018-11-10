using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    public class Job
    {
        public int JobID { get; set; }
        public string JobSerialNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OwnerOfJob { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ValidTo { get; set; }
        public bool IsActive { get; set; }
        public string PageUrl { get; set; }
    }
}