using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MvcDemo.Models;
using MvcDemo.AbstractLayer;


namespace MvcDemo.Repository
{
    public class JobRepository : IJobRepository
    {
        private MvcForumEntities context = new MvcForumEntities();

        public IQueryable<Job> GetAllJobs
        {
            get { return context.Jobs; }
        }

        public Job GetJob(int id)
        {
            return context.Jobs.FirstOrDefault(j => j.JobID == id);
        }

        // Administrator Section
        public Job CloseJob(int id)
        {
            Job j = (from o in context.Jobs
                     where o.JobID == id
                     select o).First();
            j.IsActive = false;
            context.SaveChanges();
            return j;
        }

        public void SaveJob(Job job)
        {
            if (job.JobID == 0)
            {
                job.IsActive = true;
                job.AddedDate = DateTime.Now;
                context.Jobs.Add(job);
            }
            else
            {
                Job dbEntry = context.Jobs.Find(job.JobID);

                dbEntry.JobSerialNumber = job.JobSerialNumber;
                dbEntry.Name = job.Name;
                dbEntry.OwnerOfJob = job.OwnerOfJob;
                dbEntry.PageUrl = job.PageUrl;
                dbEntry.ValidTo = job.ValidTo;
                dbEntry.AddedDate = job.AddedDate;
                dbEntry.Description = job.Description;
                dbEntry.IsActive = job.IsActive;
            }
        }

        public Job DeleteJob(int id)
        {
            Job dbEntry = context.Jobs.Find(id);
            if (dbEntry != null)
            {
                context.Jobs.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}