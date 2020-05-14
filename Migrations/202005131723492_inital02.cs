namespace demoASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital02 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.products", "quantity_per_unit", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.products", "quantity_per_unit", c => c.Int(nullable: false));
        }
    }
}
