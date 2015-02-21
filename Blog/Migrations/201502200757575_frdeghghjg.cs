namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class frdeghghjg : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Registers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Registers",
                c => new
                    {
                        RegisterId = c.String(nullable: false, maxLength: 128),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RegisterId);
            
        }
    }
}
