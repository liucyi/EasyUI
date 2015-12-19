namespace EasyUI.Liuy.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class price : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductOrder", "GoodsId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductOrder", "GoodsId");
        }
    }
}
