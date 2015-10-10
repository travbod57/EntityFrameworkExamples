namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.School",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        School_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.School", t => t.School_Id)
                .Index(t => t.School_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "School_Id", "dbo.School");
            DropIndex("dbo.Student", new[] { "School_Id" });
            DropTable("dbo.Student");
            DropTable("dbo.School");
        }
    }
}
