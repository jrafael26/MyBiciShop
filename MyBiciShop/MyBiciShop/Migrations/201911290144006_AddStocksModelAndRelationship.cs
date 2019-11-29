namespace MyBiciShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStocksModelAndRelationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        stock_id = c.Int(nullable: false, identity: true),
                        product_id = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.stock_id)
                .ForeignKey("dbo.Stores", t => t.stock_id)
                .Index(t => t.stock_id);
            
            AddColumn("dbo.Products", "Stocks_stock_id", c => c.Int());
            CreateIndex("dbo.Products", "Stocks_stock_id");
            AddForeignKey("dbo.Products", "Stocks_stock_id", "dbo.Stocks", "stock_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Stocks_stock_id", "dbo.Stocks");
            DropForeignKey("dbo.Stocks", "stock_id", "dbo.Stores");
            DropIndex("dbo.Stocks", new[] { "stock_id" });
            DropIndex("dbo.Products", new[] { "Stocks_stock_id" });
            DropColumn("dbo.Products", "Stocks_stock_id");
            DropTable("dbo.Stocks");
        }
    }
}
