namespace MyBiciShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomersModelDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "first_name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customers", "last_name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customers", "phone", c => c.String(maxLength: 50));
            AlterColumn("dbo.Customers", "email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customers", "street", c => c.String(maxLength: 50));
            AlterColumn("dbo.Customers", "city", c => c.String(maxLength: 50));
            AlterColumn("dbo.Customers", "state", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "state", c => c.String());
            AlterColumn("dbo.Customers", "city", c => c.String());
            AlterColumn("dbo.Customers", "street", c => c.String());
            AlterColumn("dbo.Customers", "email", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "phone", c => c.String());
            AlterColumn("dbo.Customers", "last_name", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "first_name", c => c.String(nullable: false));
        }
    }
}
