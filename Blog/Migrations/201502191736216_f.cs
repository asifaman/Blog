namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyBlogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        BlogTitle = c.String(),
                        BlogDescription = c.String(),
                        BloggerImg = c.String(),
                        VisitorCount = c.String(),
                    })
                .PrimaryKey(t => t.BlogId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        BlogId = c.String(),
                        UserComment = c.String(),
                    })
                .PrimaryKey(t => t.CommentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Comments");
            DropTable("dbo.MyBlogs");
        }
    }
}
