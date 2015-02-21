namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fgrdqf : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MyBlogs", "UserId", c => c.String(nullable: false));
            AlterColumn("dbo.MyBlogs", "BlogTitle", c => c.String(nullable: false));
            AlterColumn("dbo.MyBlogs", "BlogDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MyBlogs", "BlogDescription", c => c.String());
            AlterColumn("dbo.MyBlogs", "BlogTitle", c => c.String());
            AlterColumn("dbo.MyBlogs", "UserId", c => c.String());
        }
    }
}
