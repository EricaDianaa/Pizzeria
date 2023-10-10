namespace w16_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ordini")]
    public partial class Ordini
    {
        [Key]
        public int IdOrdine { get; set; }

        public int? IdClienti { get; set; }

        public string Allergie { get; set; }

        public bool? Evaso { get; set; }

        public virtual Aggiunte Aggiunte { get; set; }

        public virtual Clienti Clienti { get; set; }

        public virtual PizzeScelte PizzeScelte { get; set; }
    }
}
