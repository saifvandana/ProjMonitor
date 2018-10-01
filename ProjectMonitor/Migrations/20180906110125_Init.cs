using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectMonitor.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ShowInList = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItem",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<short>(nullable: true),
                    OperationId = table.Column<short>(nullable: false),
                    OrderNumber = table.Column<short>(nullable: false),
                    Icon = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ChildItemId = table.Column<short>(nullable: true),
                    OperationId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItem_MenuItem_ChildItemId",
                        column: x => x.ChildItemId,
                        principalTable: "MenuItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuItem_Operations_OperationId1",
                        column: x => x.OperationId1,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OperationRole",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<short>(nullable: false),
                    OperationId = table.Column<short>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    OperationId1 = table.Column<int>(nullable: true),
                    RoleId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperationRole_Operations_OperationId1",
                        column: x => x.OperationId1,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OperationRole_Roles_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleOperation",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    OperationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleOperation", x => new { x.RoleId, x.OperationId });
                    table.ForeignKey(
                        name: "FK_RoleOperation_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleOperation_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdentityNumber = table.Column<string>(maxLength: 11, nullable: false),
                    PasswordHashed = table.Column<string>(nullable: true),
                    PasswordHashedSalt = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FullName = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    RoleId = table.Column<short>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Phone = table.Column<string>(maxLength: 30, nullable: true),
                    RoleId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Roles_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLog",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    Page = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    IpAdress = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLog_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_ChildItemId",
                table: "MenuItem",
                column: "ChildItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_OperationId1",
                table: "MenuItem",
                column: "OperationId1");

            migrationBuilder.CreateIndex(
                name: "IX_OperationRole_OperationId1",
                table: "OperationRole",
                column: "OperationId1");

            migrationBuilder.CreateIndex(
                name: "IX_OperationRole_RoleId1",
                table: "OperationRole",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_RoleOperation_OperationId",
                table: "RoleOperation",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId1",
                table: "User",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserLog_UserId",
                table: "UserLog",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItem");

            migrationBuilder.DropTable(
                name: "OperationRole");

            migrationBuilder.DropTable(
                name: "RoleOperation");

            migrationBuilder.DropTable(
                name: "UserLog");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
