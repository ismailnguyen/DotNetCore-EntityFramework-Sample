using System.Collections.Generic;

namespace DotNetCore_EntityFramework_sample
{
    public interface ICandidateRepository
    {
        IEnumerable<Candidate> Find();

        IEnumerable<Candidate> Search(string email);

        void Save(string email);
    }
}