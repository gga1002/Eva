namespace Eva.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateEntityAtributes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Name", c => c.String(nullable: false, maxLength: 155));
            AlterColumn("dbo.Books", "ISBN", c => c.String(nullable: false, maxLength: 25));
            DropColumn("dbo.AspNetUsers", "Hometown");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Hometown", c => c.String());
            AlterColumn("dbo.Books", "ISBN", c => c.String());
            AlterColumn("dbo.Books", "Name", c => c.String());
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
