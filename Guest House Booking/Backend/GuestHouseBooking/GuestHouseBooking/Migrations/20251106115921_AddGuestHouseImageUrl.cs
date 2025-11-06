using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuestHouseBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddGuestHouseImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "GuestHouses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "GuestHouses");
        }
    }
}
