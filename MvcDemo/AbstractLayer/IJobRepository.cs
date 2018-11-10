using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcDemo.Models;
namespace MvcDemo.AbstractLayer
{
   public interface IJobRepository
    {
       /* I will use this function in JobsController to GET ALL Job whether active or not for Admin only
        And also I will invoke it in some Action Methods to retrive Active job (that is valid) to show it 
        in Home page
        */
       IQueryable<Job> GetAllJobs { get; } 
       Job GetJob(int id);
       Job CloseJob(int id); // It will be NOT active!
       void SaveJob(Job job);
       Job DeleteJob(int id);
    }
}
