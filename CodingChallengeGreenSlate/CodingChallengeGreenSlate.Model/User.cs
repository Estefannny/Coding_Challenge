using CodingChallengeGreenSlate.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingChallengeGreenSlate.Model
{
    public class User : Entity<int>
    {
        [Key]
        public override int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required(ErrorMessage="Fisrt name is a requeried field")]
        public string FirstName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required(ErrorMessage = "Last name is a requeried field")]
        public string LastName { get; set; }
    }
}