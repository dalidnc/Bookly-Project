namespace BooklyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_admin_table2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "UserName");
        }
    }
}
