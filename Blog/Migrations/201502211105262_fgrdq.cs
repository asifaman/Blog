namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fgrdq : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Date", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Date");
        }
    }
}
