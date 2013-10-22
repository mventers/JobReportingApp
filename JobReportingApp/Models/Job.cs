using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace JobReportingApp.Models
{
    public class Job
    {
        public int ID { get; set; }
        public string JobNumber { get; set; }
        public string AttendDate { get; set; }
        public string AttendingTech { get; set; }
        public string StatusNow { get; set; }
        public string OdModel { get; set; }
        public string OdSerial { get; set; }
        public string IdModel { get; set; }
        public string IdSerial { get; set; }
        public string POP { get; set; }
        public string PurchInv { get; set; }
        public DateTime DOP { get; set; }
        public string Report { get; set; }
        public string StatusAfter { get; set; }
        public string Visits { get; set; }
        public decimal Labour { get; set; }
        public string SentEmail { get; set; }
    }

    public class JobDBContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
    }
}