using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data.Entities
{
    public class User:IdentityUser
    {
       
        [MaxLength(30, ErrorMessage = "El {0} campo no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es necesario")]
        public string Document { get; set; }
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es necesario")]
        [Display(Name = "Firts Name")]
        public string FirstName { get; set; }
        [MaxLength(50, ErrorMessage = "El {0} campo no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es necesario")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [MaxLength(20, ErrorMessage = "El {0} campo no puede tener más de {1} caracteres")]

        [Display(Name = "Fixed Phone")]
        public string FixedPhone { get; set; }
        [MaxLength(20, ErrorMessage = "El {0} campo no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es necesario")]
        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }
        [MaxLength(30, ErrorMessage = "El {0} campo no puede tener más de {1} caracteres")]
        public string Address { get; set; }
        //public string FullName
        //{ get
        //    {
        //        return $"{FirstName} {LastName}";
        //    }
        //}
        [Display(Name = "Owner")]
        public string FullName => $"{FirstName} {LastName}";
        [Display(Name = "Owner")]
        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";

        public ICollection<Pet> Pets { get; set; }
        public ICollection<Agenda> Agendas { get; set; }
    }
}
