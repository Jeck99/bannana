namespace Entity_Framework_test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InstructorOfCourses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Instructor_Id = c.Long(nullable: false),
                        Course_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InstructorOfCourses");
        }
    }
}
