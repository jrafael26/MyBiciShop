namespace MyBiciShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixStocksModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stocks", "stock_id", "dbo.Stores");
            DropForeignKey("dbo.Products", "Stocks_stock_id", "dbo.Stocks");
            DropIndex("dbo.Stocks", new[] { "stock_id" });
            DropPrimaryKey("dbo.Stocks");
            AddColumn("dbo.Stocks", "store_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Stocks", "stock_id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Stocks", "stock_id");
            CreateIndex("dbo.Stocks", "store_id");
            AddForeignKey("dbo.Stocks", "store_id", "dbo.Stores", "store_id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "Stocks_stock_id", "dbo.Stocks", "stock_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Stocks_stock_id", "dbo.Stocks");
            DropForeignKey("dbo.Stocks", "store_id", "dbo.Stores");
            DropIndex("dbo.Stocks", new[] { "store_id" });
            DropPrimaryKey("dbo.Stocks");
            AlterColumn("dbo.Stocks", "stock_id", c => c.Int(nullable: false));
            DropColumn("dbo.Stocks", "store_id");
            AddPrimaryKey("dbo.Stocks", "stock_id");
            CreateIndex("dbo.Stocks", "stock_id");
            AddForeignKey("dbo.Products", "Stocks_stock_id", "dbo.Stocks", "stock_id");
            AddForeignKey("dbo.Stocks", "stock_id", "dbo.Stores", "store_id");
        }
    }
}
