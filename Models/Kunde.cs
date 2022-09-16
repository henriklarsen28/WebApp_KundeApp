using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KundeApp1.Models
{
    public class Kunde
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int id { get; set; }
        public string fornavn { get; set; }

        public string etternavn { get; set; }

        public string adresse { get; set; }
        public string postnr { get; set; }
        public string poststed { get; set; }
    }

    
}
