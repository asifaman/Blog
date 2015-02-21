namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyBlogs", "Date", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MyBlogs", "Date");
        }
    }
}
