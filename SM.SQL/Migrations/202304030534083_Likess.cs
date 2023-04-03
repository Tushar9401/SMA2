namespace SM.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Likess : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        LikeCount = c.Int(nullable: false),
                        PostID = c.String(),
                        createdAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Likes");
        }
    }
}
