using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petzey.Model.Consultations
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        public int PetId { get; set; }
        public string PetName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DOB { get; set; }
    }
}
