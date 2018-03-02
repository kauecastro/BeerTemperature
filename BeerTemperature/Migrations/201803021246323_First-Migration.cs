namespace BeerTemperature.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BeetTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        minTemperature = c.Int(nullable: false),
                        maxTemperature = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        productName = c.String(),
                        beerType_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.BeetTypes", t => t.beerType_id)
                .Index(t => t.beerType_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "beerType_id", "dbo.BeetTypes");
            DropIndex("dbo.Products", new[] { "beerType_id" });
            DropTable("dbo.Products");
            DropTable("dbo.BeetTypes");
        }
    }
}
