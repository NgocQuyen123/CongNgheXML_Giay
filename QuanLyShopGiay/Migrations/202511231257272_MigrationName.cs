namespace QuanLyShopGiay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.NhanViens", newName: "NhanVien");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.NhanVien", newName: "NhanViens");
        }
    }
}
