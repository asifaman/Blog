namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fgrdqfg : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MyBlogs", "VisitorCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MyBlogs", "VisitorCount", c => c.String());
        }
    }
}
