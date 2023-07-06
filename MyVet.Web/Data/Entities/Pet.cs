using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data.Entities
{
    public class Pet
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        [MaxLength(50, ErrorMessage = "El Campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Name { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        [MaxLength(50,ErrorMessage ="El campo {0} no puede tener más de {1} caracteres")]
        public string Race { get; set; }
        [Display(Name ="Born")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd}",ApplyFormatInEditMode =true)]

        public DateTime Born { get; set; }
        public string Remarks { get; set; }
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
            ? null
            : $"https://TDB.azurewebsites.net{ImageUrl.Substring(1)}";

        [Display(Name = "Born")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime BornLocal => Born.ToLocalTime();

        public PepType PepType { get; set; }
        public Owner Owner { get; set; }
        public ICollection<History> Histories { get; set; }
    }
}
