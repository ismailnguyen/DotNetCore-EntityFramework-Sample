using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCore_EntityFramework_sample
{
    class Program
    {
        private static ICandidateRepository candidateRepository;

        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddTransient<ICandidateRepository, CandidateRepository>();

            var provider = services.BuildServiceProvider();
            candidateRepository = provider.GetService<ICandidateRepository>();

            int choice = 0;

            do 
            {
                Console.WriteLine(" ------------------ ");
                Console.WriteLine("1 - Add a candidate");
                Console.WriteLine("2 - Show all candidates");
                Console.WriteLine("3 - Search candidate");
                Console.WriteLine("4 - Exit");
                Console.WriteLine(" ------------------ ");

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

            Console.ReadLine();
        }

        private static void Search()
        {
            Console.WriteLine("Email of candidate :");

            foreach (var candidate in candidateRepository.Search(Console.ReadLine()))
            {
                Console.WriteLine(candidate.Email);
            }

            Console.WriteLine("\n\n");
        }

        private static void Find()
        {
            foreach (var candidate in candidateRepository.Find())
            {
                Console.WriteLine(candidate.Email);
            }

            Console.WriteLine("\n\n");
        }

        private static void Insert()
        {
            Console.WriteLine("Email of candidate :");

            candidateRepository.Save(Console.ReadLine());

            Console.WriteLine("\n\n");
        }
    }
}
