namespace w16_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clienti",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 50),
                        Cognome = c.String(maxLength: 50),
                        Indirizzo = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.IdCliente);
            
            CreateTable(
                "dbo.Ordini",
                c => new
                    {
                        IdOrdine = c.Int(nullable: false, identity: true),
                        IdClienti = c.Int(),
                        Allergie = c.String(),
                        Evaso = c.Boolean(),
                        DataConsegna = c.DateTime(nullable: false, storeType: "date"),
                        NoteAggiunzione = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.IdOrdine)
                .ForeignKey("dbo.Clienti", t => t.IdClienti)
                .Index(t => t.IdClienti);
            
            CreateTable(
                "dbo.PizzeScelte",
                c => new
                    {
                        IdPizze = c.Int(nullable: false, identity: true),
                        PizzaScelta = c.Int(),
                        Quantità = c.Int(),
                        IdOrdine = c.Int(),
                    })
                .PrimaryKey(t => t.IdPizze)
                .ForeignKey("dbo.Ordini", t => t.IdOrdine)
                .ForeignKey("dbo.Pizze", t => t.PizzaScelta)
                .Index(t => t.PizzaScelta)
                .Index(t => t.IdOrdine);
            
            CreateTable(
                "dbo.Pizze",
                c => new
                    {
                        IdPizza = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 50),
                        Foto = c.String(maxLength: 50),
                        Prezzo = c.Decimal(storeType: "money"),
                        TempoConsegna = c.Time(precision: 7),
                        Ingredienti = c.String(),
                    })
                .PrimaryKey(t => t.IdPizza);
            
            CreateTable(
                "dbo.Utenti",
                c => new
                    {
                        IdUtente = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        Ruolo = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.IdUtente);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ordini", "IdClienti", "dbo.Clienti");
            DropForeignKey("dbo.PizzeScelte", "PizzaScelta", "dbo.Pizze");
            DropForeignKey("dbo.PizzeScelte", "IdOrdine", "dbo.Ordini");
            DropIndex("dbo.PizzeScelte", new[] { "IdOrdine" });
            DropIndex("dbo.PizzeScelte", new[] { "PizzaScelta" });
            DropIndex("dbo.Ordini", new[] { "IdClienti" });
            DropTable("dbo.Utenti");
            DropTable("dbo.Pizze");
            DropTable("dbo.PizzeScelte");
            DropTable("dbo.Ordini");
            DropTable("dbo.Clienti");
        }
    }
}
