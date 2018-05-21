namespace Eva.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuantityToBook : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Issues", "Member_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Issues", new[] { "Member_Id" });
            DropColumn("dbo.Issues", "MemberId");
            RenameColumn(table: "dbo.Issues", name: "Member_Id", newName: "MemberId");
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "GenreId", c => c.Byte(nullable: false));
            AddColumn("dbo.Books", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.Issues", "MemberId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Issues", "MemberId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Books", "GenreId");
            CreateIndex("dbo.Issues", "MemberId");
            AddForeignKey("dbo.Books", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Issues", "MemberId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Issues", "MemberId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropIndex("dbo.Issues", new[] { "MemberId" });
            DropIndex("dbo.Books", new[] { "GenreId" });
            AlterColumn("dbo.Issues", "MemberId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Issues", "MemberId", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "Quantity");
            DropColumn("dbo.Books", "GenreId");
            DropTable("dbo.Genres");
            RenameColumn(table: "dbo.Issues", name: "MemberId", newName: "Member_Id");
            AddColumn("dbo.Issues", "MemberId", c => c.Int(nullable: false));
            CreateIndex("dbo.Issues", "Member_Id");
            AddForeignKey("dbo.Issues", "Member_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
