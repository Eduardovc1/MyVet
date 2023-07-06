﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data.Entities
{
    public class PepType
    {
        public int Id { get; set; }
        [Display(Name ="Pep Type")]
        [MaxLength(50,ErrorMessage ="El {0} no debe tener más de {1} caracteres")]
        [Required(ErrorMessage ="El campo {0} es requerido.")]
        public string Name { get; set; }

        public ICollection<Pet> Pets { get; set; }
    }
}
