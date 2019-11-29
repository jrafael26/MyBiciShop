namespace MyBiciShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoreAndStaffModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        staff_id = c.Int(nullable: false, identity: true),
                        first_name = c.String(nullable: false),
                        last_name = c.String(nullable: false),
                        phone = c.String(),
                        email = c.String(nullable: false),
                        active = c.Byte(nullable: false),
                        Stores_store_id = c.Int(),
                    })
                .PrimaryKey(t => t.staff_id)
                .ForeignKey("dbo.Stores", t => t.Stores_store_id)
                .Index(t => t.Stores_store_id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staffs", "Stores_store_id", "dbo.Stores");
            DropIndex("dbo.Staffs", new[] { "Stores_store_id" });
            DropTable("dbo.Stores");
            DropTable("dbo.Staffs");
        }
    }
}
