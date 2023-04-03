namespace SM.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Likeee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "NumberOfLikes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "NumberOfLikes");
        }
    }
}
