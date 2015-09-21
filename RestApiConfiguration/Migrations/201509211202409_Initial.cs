namespace RestApiConfiguration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConfigurationEntities",
                c => new
                    {
                        ConfigName = c.String(nullable: false, maxLength: 128),
                        EmailAdress = c.String(),
                        HostingName = c.String(),
                        FtpUserName = c.String(),
                        Registration = c.Boolean(nullable: false),
                        TypeOfHosting = c.String(),
                    })
                .PrimaryKey(t => t.ConfigName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ConfigurationEntities");
        }
    }
}
