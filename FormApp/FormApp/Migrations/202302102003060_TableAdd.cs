namespace FormApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Donanım",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Marka = c.String(),
                        Model = c.String(),
                        SeriNo = c.String(),
                        Kategori = c.String(),
                        ArizaAciklama = c.String(),
                        Status = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Modife = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        DeleteDate = c.DateTime(nullable: false),
                        ModifeDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Donanım");
        }
    }
}
