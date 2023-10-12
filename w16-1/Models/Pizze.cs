namespace w16_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pizze")]
    public partial class Pizze
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pizze()
        {
            PizzeScelte = new HashSet<PizzeScelte>();
        }

        [Key]
        public int IdPizza { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(50)]
        public string Foto { get; set; }

        [Column(TypeName = "money")]
        public decimal? Prezzo { get; set; }

        public TimeSpan? TempoConsegna { get; set; }

        public string Ingredienti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PizzeScelte> PizzeScelte { get; set; }


       public static List<Pizze> ListPizze = new List<Pizze>();

        public static List<int> ListQuantità = new List<int>();
    }
}
