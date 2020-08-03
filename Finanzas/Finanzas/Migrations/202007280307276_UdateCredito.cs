namespace Finanzas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UdateCredito : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Creditoes", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Creditoes", "UserId");
        }
    }
}
