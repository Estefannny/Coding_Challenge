using CodingChallengeGreenSlate.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeGreenSlate.Model
{
    public class Project : Entity<int>
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "You must specify the start date of the project!")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "You must specify the end date of the project!")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Credits")]
        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Credits is a requeried field")]
        public int Credits { get; set; }
    }
}
