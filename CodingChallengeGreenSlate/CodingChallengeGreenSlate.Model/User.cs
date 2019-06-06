using CodingChallengeGreenSlate.Model.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CodingChallengeGreenSlate.Model
{
    public class User : Entity<int>
    {
        [Key]
        public override int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required]
        public string LastName { get; set; }
    }
}