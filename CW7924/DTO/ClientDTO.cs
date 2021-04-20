using CW7924.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class ClientDTO
    {
       
      public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; } 

        public string GenderType { get; set; }

       public DateTime DateOfBirth { get; set; }


        public int PlantID { get; set; }

        public Plant Plant { get; set; } 
    }
}
