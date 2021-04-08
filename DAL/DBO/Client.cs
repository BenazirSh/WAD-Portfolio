using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CW7924.DAL
{
    public class Client
    {
        [Range(0, int.MaxValue)]
        public int Id { get; set; }

        [MinLength(2)]
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [MinLength(2)]
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Plant Name")]
        public int PlantID { get; set; }

        public Plant Plant { get; set; }

    }
    public enum Gender
    {
        Male,
        Female,
        Unknown
    }


}
