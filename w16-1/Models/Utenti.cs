namespace w16_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Utenti")]
    public partial class Utenti
    {
        [Key]
        public int IdUtente { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(10)]
        public string Ruolo { get; set; } = "User";

        //public static List<Utenti> ListUtenti = new List<Utenti>();
    }
}
