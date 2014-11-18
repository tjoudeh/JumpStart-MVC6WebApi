using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Model;
using System;

namespace Registration_MVC6WebApi.Migrations
{
    public partial class initial : Migration
    {
        public override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("Course",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Credits = c.Int(nullable: false),
                        Name = c.String()
                    })
                .PrimaryKey("PK_Course", t => t.Id);
        }
        
        public override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Course");
        }
    }
}