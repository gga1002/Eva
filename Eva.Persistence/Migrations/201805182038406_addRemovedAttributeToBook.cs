namespace Eva.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRemovedAttributeToBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "removed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "removed");
        }
    }
}
