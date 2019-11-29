namespace MyBiciShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriesModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        category_id = c.Int(nullable: false, identity: true),
                        category_name = c.String(),
                    })
                .PrimaryKey(t => t.category_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
        }
    }
}
