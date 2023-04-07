namespace SM.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Picks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Pick", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Pick");
        }
    }
}
