using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCore_EntityFramework_sample
{
    [Table("candidates", Schema = "public")]
    public class Candidate
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("email")]
        public string Email { get; set; }
    }
}