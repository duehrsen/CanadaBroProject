using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class EmailReportPairContext:DbContext
    {
        public EmailReportPairContext(DbContextOptions<EmailReportPairContext> options):base (options) { }
        public DbSet<EmailReportPair> Pairs { get; set; }
    }
}
