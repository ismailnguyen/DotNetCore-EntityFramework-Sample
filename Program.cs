using System;
using System.Linq;

namespace DotNetCore_EntityFramework_sample
{
    class Program
    {
        private static CandidateRepository candidateRepository;

        static void Main(string[] args)
        {
            var connectionString = "Your connection string here";

            using (candidateRepository = new CandidateRepository(connectionString))
            {
                int choice = 0;

                do 
                {
                    Console.WriteLine("1 - Add a candidate");
                    Console.WriteLine("2 - Show all candidates");
                    Console.WriteLine("3 - Search candidate");
                    Console.WriteLine("4 - Exit");

                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch (choice)
                        {
                            case 1 : Insert(); break;
                            case 2 : Find(); break;
                            case 3 : Search(); break;
                            default: Environment.Exit(0); break;
                        }
                    }
                }
                while (choice != 0);
            }

            Console.ReadLine();
        }

        private static void Search()
        {
            Console.WriteLine("Email of candidate :");

            foreach (var candidate in candidateRepository.Candidates.Where(c => c.Email.Contains(Console.ReadLine())))
            {
                Console.WriteLine(candidate.Email);
            }

            Console.WriteLine("\n\n");
        }

        private static void Find()
        {
            foreach (var candidate in candidateRepository.Candidates)
            {
                Console.WriteLine(candidate.Email);
            }

            Console.WriteLine("\n\n");
        }

        private static void Insert()
        {
            Console.WriteLine("Email of candidate :");

            candidateRepository.Add(new Candidate() { Email = Console.ReadLine() });

            candidateRepository.SaveChanges();

            Console.WriteLine("\n\n");
        }
    }
}
