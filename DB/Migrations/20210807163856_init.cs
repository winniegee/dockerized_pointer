using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    CampaignID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserProfileUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.CampaignID);
                    table.ForeignKey(
                        name: "FK_Campaign_Users_UserProfileUserId",
                        column: x => x.UserProfileUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    MessageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserProfileUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Message_Users_UserProfileUserId",
                        column: x => x.UserProfileUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessagesMessageId = table.Column<int>(nullable: true),
                    CampaignID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Campaign_CampaignID",
                        column: x => x.CampaignID,
                        principalTable: "Campaign",
                        principalColumn: "CampaignID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Message_MessagesMessageId",
                        column: x => x.MessagesMessageId,
                        principalTable: "Message",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_UserProfileUserId",
                table: "Campaign",
                column: "UserProfileUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserProfileUserId",
                table: "Message",
                column: "UserProfileUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CampaignID",
                table: "Tasks",
                column: "CampaignID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_MessagesMessageId",
                table: "Tasks",
                column: "MessagesMessageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
