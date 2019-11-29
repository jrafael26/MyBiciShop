namespace MyBiciShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomersModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        customer_id = c.Int(nullable: false, identity: true),
                        first_name = c.String(nullable: false),
                        last_name = c.String(nullable: false),
                        phone = c.String(),
                        email = c.String(nullable: false),
                        street = c.String(),
                        city = c.String(),
                        state = c.String(),
                        zip_code = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.customer_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
