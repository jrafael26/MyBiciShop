namespace MyBiciShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBrandsModel : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Brands");
        }
    }
}
