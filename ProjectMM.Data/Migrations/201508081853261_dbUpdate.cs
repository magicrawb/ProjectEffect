namespace ProjectMM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbUpdate : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.NewTricks", name: "ApplicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.NewTricks", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.NewTricks", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.NewTricks", name: "UserId", newName: "ApplicationUser_Id");
        }
    }
}
