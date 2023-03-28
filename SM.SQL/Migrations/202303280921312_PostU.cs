namespace SM.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostU : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Image", c => c.String());
            AddColumn("dbo.Posts", "Category", c => c.String());
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Posts", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Description", c => c.String());
            AlterColumn("dbo.Posts", "Title", c => c.String());
            DropColumn("dbo.Posts", "Category");
            DropColumn("dbo.Posts", "Image");
        }
    }
}
