using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCore_EntityFramework_sample
{
    [Table("candidates")]
    public class Candidate
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("email")]
        public string Email { get; set; }
    }
}