namespace MyBiciShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrdersModelAndRelationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        order_id = c.Int(nullable: false, identity: true),
                        customer_id = c.Int(nullable: false),
                        order_status = c.String(),
                        order_date = c.DateTime(nullable: false),
                        required_date = c.DateTime(nullable: false),
                        shipped_date = c.DateTime(nullable: false),
                        store_id = c.Int(nullable: false),
                        staff_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.order_id)
                .ForeignKey("dbo.Customers", t => t.customer_id, cascadeDelete: false)
                .ForeignKey("dbo.Staffs", t => t.staff_id, cascadeDelete: false)
                .ForeignKey("dbo.Stores", t => t.store_id, cascadeDelete: false)
                .Index(t => t.customer_id)
                .Index(t => t.store_id)
                .Index(t => t.staff_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "store_id", "dbo.Stores");
            DropForeignKey("dbo.Orders", "staff_id", "dbo.Staffs");
            DropForeignKey("dbo.Orders", "customer_id", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "staff_id" });
            DropIndex("dbo.Orders", new[] { "store_id" });
            DropIndex("dbo.Orders", new[] { "customer_id" });
            DropTable("dbo.Orders");
        }
    }
}
