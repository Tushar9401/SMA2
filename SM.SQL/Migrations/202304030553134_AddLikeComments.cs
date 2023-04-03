namespace SM.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLikeComments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Likes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Likes");
        }
    }
}
