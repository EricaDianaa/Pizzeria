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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ordini()
        {
            PizzeScelte = new HashSet<PizzeScelte>();
        }

        [Key]
        public int IdOrdine { get; set; }

        public int? IdClienti { get; set; }

        public string Allergie { get; set; }

        public bool? Evaso { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataConsegna { get; set; }

        [StringLength(100)]
        public string NoteAggiunzione { get; set; }

        public virtual Clienti Clienti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PizzeScelte> PizzeScelte { get; set; }

        
    }
}
