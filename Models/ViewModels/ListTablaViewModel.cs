using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPrueba1.Models.ViewModels
{
    public class ListTablaViewModel
    {
        public int id { get; set; }
        public string nameClient { get; set; }
        public string documentType { get; set; }
        public string documentNumber { get; set; }
        public string addressPlace { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string dateCreate { get; set; }

    }
}