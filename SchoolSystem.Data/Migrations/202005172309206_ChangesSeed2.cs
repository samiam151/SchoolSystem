namespace SchoolSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesSeed2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Students", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Programs", "Name", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Programs", "Name", c => c.String());
            AlterColumn("dbo.Students", "Name", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String());
        }
    }
}
