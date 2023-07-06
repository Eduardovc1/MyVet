using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data.Entities
{
    public class History
    {
        public int Id { get; set; }
        [Display(Name ="Description")]
        [MaxLength(100,ErrorMessage ="El Campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage ="El campo {0} es requerido")]
        public string Descripcion { get; set; }
       
        [Display(Name = "Date")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd}",ApplyFormatInEditMode =true)]
        public DateTime Date { get; set; }
        public string Remarks { get; set; }
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateLocal => Date.ToLocalTime();
        public ServiceType ServiceType { get; set; }
        public Pet Pet { get; set; }

    }
}
