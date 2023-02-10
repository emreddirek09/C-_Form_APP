namespace FormApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Donanım", "DeleteDate");
            DropColumn("dbo.Donanım", "ModifeDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Donanım", "ModifeDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Donanım", "DeleteDate", c => c.DateTime(nullable: false));
        }
    }
}
