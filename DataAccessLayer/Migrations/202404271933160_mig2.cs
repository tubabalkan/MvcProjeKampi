namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.writers", "WriterAbout", c => c.String(maxLength: 100));
            AlterColumn("dbo.writers", "writerMail", c => c.String(maxLength: 200));
            AlterColumn("dbo.writers", "writerPassword", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.writers", "writerPassword", c => c.String(maxLength: 20));
            AlterColumn("dbo.writers", "writerMail", c => c.String(maxLength: 50));
            DropColumn("dbo.writers", "WriterAbout");
        }
    }
}
