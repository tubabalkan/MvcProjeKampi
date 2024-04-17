namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "writerId", c => c.Int());
            CreateIndex("dbo.Contents", "writerId");
            AddForeignKey("dbo.Contents", "writerId", "dbo.writers", "writerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "writerId", "dbo.writers");
            DropIndex("dbo.Contents", new[] { "writerId" });
            DropColumn("dbo.Contents", "writerId");
        }
    }
}
