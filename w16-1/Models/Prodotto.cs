using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace w16_1.Models
{
    public class Prodotto
    {
        public int Quantità { get; set; }
        public int IdPizza { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public decimal? Prezzo { get; set; }
        public TimeSpan? TempoConsegna { get; set; }
        public string Ingredienti { get; set; }
        public static List<Prodotto> ListPizze = new List<Prodotto>();
        public decimal totale { get; set; }
    }
}