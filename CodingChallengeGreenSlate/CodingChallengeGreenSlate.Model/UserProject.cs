using CodingChallengeGreenSlate.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingChallengeGreenSlate.Model
{
    public class UserProject : Entity<int>
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Column(TypeName = "BIT")]
        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime AssignedDate { get; set; }

        [NotMapped]
        public String TimeToStart
        {
            get
            {
                int intStartDate = Convert.ToInt32(Project.StartDate.ToString("yyyyMMdd"));
                int intAssignedDate = Convert.ToInt32(AssignedDate.ToString("yyyyMMdd"));
                if (intStartDate < intAssignedDate)
                {
                    return "Started";
                }
                else
                {
                    int daysToStartProject = intStartDate - intAssignedDate;
                    string daysToStart = daysToStartProject.ToString() + " days";
                    return daysToStart;
                }
            }
            private set
            {

            }
        }

        [NotMapped]
        public String Status
        {
            get
            {
                if (IsActive.Equals(true))
                {
                    return "Active";
                }
                else
                {
                    return "Inactive";
                }
            }
            private set
            {

            }
        }

        [NotMapped]
        public String StartDate
        {
            get
            {
                return Project.StartDate.ToString("dd/MM/yyyy") ;
            }
            private set
            {

            }
        }

        [NotMapped]
        public String EndDate
        {
            get
            {
                return Project.EndDate.ToString("dd/MM/yyyy");
            }
            private set
            {

            }
        }

        [NotMapped]
        public int Credits
        {
            get
            {
                return Project.Credits;
            }
            private set
            {

            }
        }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
    }
}