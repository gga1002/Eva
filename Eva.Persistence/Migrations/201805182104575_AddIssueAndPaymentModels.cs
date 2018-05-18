namespace Eva.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIssueAndPaymentModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Issues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        Member_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Member_Id)
                .Index(t => t.BookId)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                        paymentDate = c.DateTime(nullable: false),
                        Member_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Member_Id)
                .Index(t => t.BookId)
                .Index(t => t.Member_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "Member_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Payments", "BookId", "dbo.Books");
            DropForeignKey("dbo.Issues", "Member_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Issues", "BookId", "dbo.Books");
            DropIndex("dbo.Payments", new[] { "Member_Id" });
            DropIndex("dbo.Payments", new[] { "BookId" });
            DropIndex("dbo.Issues", new[] { "Member_Id" });
            DropIndex("dbo.Issues", new[] { "BookId" });
            DropTable("dbo.Payments");
            DropTable("dbo.Issues");
        }
    }
}
