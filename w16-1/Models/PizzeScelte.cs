namespace w16_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PizzeScelte")]
    public partial class PizzeScelte
    {
        [Key]
        public int IdPizze { get; set; }

        public int? PizzaScelta { get; set; }

        public int? Quantità { get; set; }

        public int? IdOrdine { get; set; }

        public virtual Ordini Ordini { get; set; }

        public virtual Pizze Pizze { get; set; }
    }
}
