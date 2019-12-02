namespace MyBiciShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPopulateCategory : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (category_name) values ('Montaña (MTB)')");
            Sql("INSERT INTO Categories (category_name) values ('Ruta')");
            Sql("INSERT INTO Categories (category_name) values ('Híbridas')");
            Sql("INSERT INTO Categories (category_name) values ('Urbanas')");
            Sql("INSERT INTO Categories (category_name) values ('Plegables')");
            Sql("INSERT INTO Categories (category_name) values ('Fixies ')");
            Sql("INSERT INTO Categories (category_name) values ('Single speed')");
            Sql("INSERT INTO Categories (category_name) values ('Cruisers')");
            Sql("INSERT INTO Categories (category_name) values ('MBX')");
            Sql("INSERT INTO Categories (category_name) values ('Touring')");
            Sql("INSERT INTO Categories (category_name) values ('Eléctricas')");

        }

        public override void Down()
        {
        }
    }
}
