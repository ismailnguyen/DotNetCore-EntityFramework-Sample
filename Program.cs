using System;

namespace DotNetCore_EntityFramework_sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Your connection string here";

            using (var candidateRepository = new CandidateRepository(connectionString))
            {
                foreach (var candidate in candidateRepository.Candidates)
                {
                    Console.WriteLine(candidate.Email);
                }
            }

            Console.ReadLine();
        }
    }
}
