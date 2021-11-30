using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebPrueba1.Models.ViewModels
{

    public class typeDocument
    {
        public int typeDocumentId { get; set; }
        public string Name { get; set; }
    }
    public class TablaViewModel
    {

        public int id { get; set; }

        [Required]
        [Display(Name ="Nombre")]
        public string nameClient { get; set; }

        [Required]
        [Display(Name = "Tipo de documento")]
        public string documentType { get; set; }

        [Required]
        [Display(Name = "Número de documento")]
        public string documentNumber { get; set; }

        [Display(Name = "Dirección")]
        public string addressPlace { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        public string phone { get; set; }

        [EmailAddress]
        [Display(Name = "Correo")]
        public string email { get; set; }


        [Display(Name = "Fecha de creación")]
        public string dateCreate { get; set; }

    }
}