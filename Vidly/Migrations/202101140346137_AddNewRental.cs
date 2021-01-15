namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewRental : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewRentals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RentalDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(),
                        Customer_ID = c.Int(),
                        Movie_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.Customer_ID)
                .ForeignKey("dbo.Movies", t => t.Movie_ID)
                .Index(t => t.Customer_ID)
                .Index(t => t.Movie_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewRentals", "Movie_ID", "dbo.Movies");
            DropForeignKey("dbo.NewRentals", "Customer_ID", "dbo.Customers");
            DropIndex("dbo.NewRentals", new[] { "Movie_ID" });
            DropIndex("dbo.NewRentals", new[] { "Customer_ID" });
            DropTable("dbo.NewRentals");
        }
    }
}
