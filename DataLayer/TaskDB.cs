using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestinGList.Models;

namespace TestinGList.DataLayer
{
    public partial class TaskDB : DbContext
    {

        public TaskDB()
        {

        }


        public TaskDB(DbContextOptions<TaskDB> options) : base(options)
        {

        }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Task> Tasks { get; set; }
      



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //should use connectionstring from the config file
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Advanced VB\TestinGList\NewTaskDBF.mdf;Integrated Security=True;");
        }

     
    }
}
