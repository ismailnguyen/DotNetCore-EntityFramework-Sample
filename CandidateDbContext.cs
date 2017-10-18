using System;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore_EntityFramework_sample
{
    public class CandidateDbContext : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        private string connectionString;

        public CandidateDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
