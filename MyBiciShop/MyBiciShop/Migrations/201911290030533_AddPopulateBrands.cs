namespace MyBiciShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPopulateBrands : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Brands (brand_name) values ('Specialized')");
            Sql("INSERT INTO Brands (brand_name) values ('Trek')");
            Sql("INSERT INTO Brands (brand_name) values ('Merida')");
            Sql("INSERT INTO Brands (brand_name) values ('Scott')");
            Sql("INSERT INTO Brands (brand_name) values ('Giant')");
            Sql("INSERT INTO Brands (brand_name) values ('Cube')");
            Sql("INSERT INTO Brands (brand_name) values ('Lapierre')");
            Sql("INSERT INTO Brands (brand_name) values ('Orbea')");
            Sql("INSERT INTO Brands (brand_name) values ('Pinarello')");
            Sql("INSERT INTO Brands (brand_name) values ('Aurora')");
            Sql("INSERT INTO Brands (brand_name) values ('Olmo')");
            Sql("INSERT INTO Brands (brand_name) values ('Bmc')");
        }
        
        public override void Down()
        {
        }
    }
}
