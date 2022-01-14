namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class talentvalue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Talents", "TalentValue", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Talents", "TalentValue");
        }
    }
}
