namespace MyBiciShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderDetailsModelAndRelationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        orderItem_id = c.Int(nullable: false, identity: true),
                        order_id = c.Int(nullable: false),
                        product_id = c.Int(nullable: false),
                        list_price = c.Double(nullable: false),
                        discount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.orderItem_id)
                .ForeignKey("dbo.Orders", t => t.order_id, cascadeDelete: false)
                .Index(t => t.order_id);
            
            AddColumn("dbo.Products", "OrderItems_orderItem_id", c => c.Int());
            CreateIndex("dbo.Products", "OrderItems_orderItem_id");
            AddForeignKey("dbo.Products", "OrderItems_orderItem_id", "dbo.OrderItems", "orderItem_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "OrderItems_orderItem_id", "dbo.OrderItems");
            DropForeignKey("dbo.OrderItems", "order_id", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "order_id" });
            DropIndex("dbo.Products", new[] { "OrderItems_orderItem_id" });
            DropColumn("dbo.Products", "OrderItems_orderItem_id");
            DropTable("dbo.OrderItems");
        }
    }
}
