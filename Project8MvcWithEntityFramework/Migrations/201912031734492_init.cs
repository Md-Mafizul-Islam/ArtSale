namespace Project8MvcWithEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistID = c.Int(nullable: false, identity: true),
                        ArtistName = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.ArtistID);
            
            CreateTable(
                "dbo.Arts",
                c => new
                    {
                        ArtID = c.Int(nullable: false, identity: true),
                        Arts = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.ArtID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 15),
                        ArtistID = c.Int(nullable: false),
                        ArtID = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerType = c.String(nullable: false, maxLength: 9),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Arts", t => t.ArtID, cascadeDelete: true)
                .ForeignKey("dbo.Artists", t => t.ArtistID, cascadeDelete: true)
                .Index(t => t.ArtistID)
                .Index(t => t.ArtID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 15),
                        Password = c.String(nullable: false, maxLength: 15),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "ArtistID", "dbo.Artists");
            DropForeignKey("dbo.Customers", "ArtID", "dbo.Arts");
            DropIndex("dbo.Customers", new[] { "ArtID" });
            DropIndex("dbo.Customers", new[] { "ArtistID" });
            DropTable("dbo.Users");
            DropTable("dbo.Customers");
            DropTable("dbo.Arts");
            DropTable("dbo.Artists");
        }
    }
}
