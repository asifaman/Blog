namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ftoi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyBlogs", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MyBlogs", "Status");
        }
    }
}
