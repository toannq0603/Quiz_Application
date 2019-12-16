namespace QuizApplication.Logic.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class QuizMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Time = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        IsMale = c.Boolean(nullable: false),
                        Accuracy = c.Single(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PersonModels");
        }
    }
}
