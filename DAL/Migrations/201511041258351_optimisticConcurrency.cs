namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class optimisticConcurrency : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.School", "TimeStamp", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.School", "TimeStamp");
        }
    }
}
