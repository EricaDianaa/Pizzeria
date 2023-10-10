namespace w16_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Aggiunte")]
    public partial class Aggiunte
    {
        [Key]
        public int IdAggiunte { get; set; }

        public int? Pizza { get; set; }

        public int? IdOrdine { get; set; }

        [StringLength(50)]
        public string NomeAggiunte { get; set; }

        public virtual Pizze Pizze { get; set; }

        public virtual Ordini Ordini { get; set; }
    }
}
