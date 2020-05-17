using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class EmailReportPair
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string ReportName { get; set; }
    }

/*    public class EmailReportPairDBContext : DbContext
    {
        public DbSet<EmailReportPair> Pairs { get; set; }
    }*/
}
