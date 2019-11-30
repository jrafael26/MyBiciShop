namespace MyBiciShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        brand_id = c.Int(nullable: false, identity: true),
                        brand_name = c.String(),
                    })
                .PrimaryKey(t => t.brand_id);
            
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
                        description = c.String(),
                        Stocks_stock_id = c.Int(),
                    })
                .PrimaryKey(t => t.product_id)
                .ForeignKey("dbo.Brands", t => t.brand_id, cascadeDelete: false)
                .ForeignKey("dbo.Categories", t => t.category_id, cascadeDelete: false)
                .ForeignKey("dbo.Stocks", t => t.Stocks_stock_id)
                .Index(t => t.brand_id)
                .Index(t => t.category_id)
                .Index(t => t.Stocks_stock_id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        category_id = c.Int(nullable: false, identity: true),
                        category_name = c.String(),
                    })
                .PrimaryKey(t => t.category_id);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        orderItem_id = c.Int(nullable: false, identity: true),
                        order_id = c.Int(nullable: false),
                        product_id = c.Int(nullable: false),
                        list_price = c.Double(nullable: false),
                        discount = c.Double(nullable: false),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.orderItem_id)
                .ForeignKey("dbo.Orders", t => t.order_id, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.product_id, cascadeDelete: false)
                .Index(t => t.order_id)
                .Index(t => t.product_id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        order_id = c.Int(nullable: false, identity: true),
                        customer_id = c.Int(nullable: false),
                        order_status = c.Int(nullable: false),
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
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        customer_id = c.Int(nullable: false, identity: true),
                        first_name = c.String(nullable: false, maxLength: 50),
                        last_name = c.String(nullable: false, maxLength: 50),
                        phone = c.String(maxLength: 50),
                        email = c.String(nullable: false, maxLength: 50),
                        street = c.String(maxLength: 50),
                        city = c.String(maxLength: 50),
                        state = c.String(maxLength: 50),
                        zip_code = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.customer_id);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        staff_id = c.Int(nullable: false, identity: true),
                        first_name = c.String(nullable: false),
                        last_name = c.String(nullable: false),
                        phone = c.String(),
                        email = c.String(nullable: false),
                        active = c.Boolean(nullable: false),
                        store_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.staff_id)
                .ForeignKey("dbo.Stores", t => t.store_id, cascadeDelete: false)
                .Index(t => t.store_id);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        store_id = c.Int(nullable: false, identity: true),
                        store_name = c.String(),
                        phone = c.String(),
                        email = c.String(nullable: false),
                        street = c.String(),
                        city = c.String(),
                        state = c.String(),
                        zip_code = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.store_id);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        stock_id = c.Int(nullable: false, identity: true),
                        store_id = c.Int(nullable: false),
                        product_id = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.stock_id)
                .ForeignKey("dbo.Stores", t => t.store_id, cascadeDelete: false)
                .Index(t => t.store_id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.OrderItems", "product_id", "dbo.Products");
            DropForeignKey("dbo.Stocks", "store_id", "dbo.Stores");
            DropForeignKey("dbo.Products", "Stocks_stock_id", "dbo.Stocks");
            DropForeignKey("dbo.Staffs", "store_id", "dbo.Stores");
            DropForeignKey("dbo.Orders", "store_id", "dbo.Stores");
            DropForeignKey("dbo.Orders", "staff_id", "dbo.Staffs");
            DropForeignKey("dbo.OrderItems", "order_id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "customer_id", "dbo.Customers");
            DropForeignKey("dbo.Products", "category_id", "dbo.Categories");
            DropForeignKey("dbo.Products", "brand_id", "dbo.Brands");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Stocks", new[] { "store_id" });
            DropIndex("dbo.Staffs", new[] { "store_id" });
            DropIndex("dbo.Orders", new[] { "staff_id" });
            DropIndex("dbo.Orders", new[] { "store_id" });
            DropIndex("dbo.Orders", new[] { "customer_id" });
            DropIndex("dbo.OrderItems", new[] { "product_id" });
            DropIndex("dbo.OrderItems", new[] { "order_id" });
            DropIndex("dbo.Products", new[] { "Stocks_stock_id" });
            DropIndex("dbo.Products", new[] { "category_id" });
            DropIndex("dbo.Products", new[] { "brand_id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Stocks");
            DropTable("dbo.Stores");
            DropTable("dbo.Staffs");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Brands");
        }
    }
}
