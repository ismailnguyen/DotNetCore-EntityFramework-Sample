using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore_EntityFramework_sample
{
    public class CandidateRepository : ICandidateRepository
    {
        private string connectionString;

        public CandidateRepository()
        {
            connectionString = "Your connection string here";
        }

        public IEnumerable<Candidate> Find()
        {
            using (var candidateDbContext = new CandidateDbContext(connectionString))
            {
                return candidateDbContext.Candidates.ToList();
            }
        }

        public IEnumerable<Candidate> Search(string email)
        {
            using (var candidateDbContext = new CandidateDbContext(connectionString))
            {
                return candidateDbContext.Candidates.Where(c => c.Email.Contains(email)).ToList();
            }
        }

        public void Save(string email)
        {
            using (var candidateDbContext = new CandidateDbContext(connectionString))
            {
                candidateDbContext.Candidates.Add(new Candidate() { Email = email});

                candidateDbContext.SaveChanges();
            }
        }
    }
}
