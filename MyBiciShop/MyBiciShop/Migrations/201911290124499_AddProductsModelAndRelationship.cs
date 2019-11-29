namespace MyBiciShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductsModelAndRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Staffs", "Stores_store_id", "dbo.Stores");
            DropIndex("dbo.Staffs", new[] { "Stores_store_id" });
            RenameColumn(table: "dbo.Staffs", name: "Stores_store_id", newName: "store_id");
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        product_id = c.Int(nullable: false, identity: true),
                        product_name = c.String(nullable: false),
                        brand_id = c.Int(nullable: false),
                        category_id = c.Int(nullable: false),
                        model_year = c.Int(nullable: false),
                        list_price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.product_id)
                .ForeignKey("dbo.Brands", t => t.brand_id, cascadeDelete: false)
                .ForeignKey("dbo.Categories", t => t.category_id, cascadeDelete: false)
                .Index(t => t.brand_id)
                .Index(t => t.category_id);
            
            AlterColumn("dbo.Staffs", "store_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Staffs", "store_id");
            AddForeignKey("dbo.Staffs", "store_id", "dbo.Stores", "store_id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staffs", "store_id", "dbo.Stores");
            DropForeignKey("dbo.Products", "category_id", "dbo.Categories");
            DropForeignKey("dbo.Products", "brand_id", "dbo.Brands");
            DropIndex("dbo.Staffs", new[] { "store_id" });
            DropIndex("dbo.Products", new[] { "category_id" });
            DropIndex("dbo.Products", new[] { "brand_id" });
            AlterColumn("dbo.Staffs", "store_id", c => c.Int());
            DropTable("dbo.Products");
            RenameColumn(table: "dbo.Staffs", name: "store_id", newName: "Stores_store_id");
            CreateIndex("dbo.Staffs", "Stores_store_id");
            AddForeignKey("dbo.Staffs", "Stores_store_id", "dbo.Stores", "store_id");
        }
    }
}
