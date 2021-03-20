using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CW7924.DAL
{
    public class Plant
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Id { get; set; }

        [Display(Name = "Plant Name")]
        public string PlantName { get; set; }

        [Display(Name = "Plant Type")]
        public PlantType PlantType { get; set; }

       [JsonIgnore]
        public virtual ICollection<Client> Clients { get; set; }
    }
    public enum PlantType
    {
        Flower,
        Bush,
        Tree

    }

}
