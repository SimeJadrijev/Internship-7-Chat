using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "IsAdmin", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "sime.jadrijev@gmail.com", true, "password123", "Sime Jadrijev" },
                    { 2, "marko.livaja@gmail.com", false, "password123", "Marko Livaja" },
                    { 3, "kevin.punter@gmail.com", false, "password123", "Kevin Punter" },
                    { 4, "anthony.edwards@gmail.com", false, "password123", "Anthony Edwards" },
                    { 5, "toni.kukoc@gmail.com", true, "password123", "Toni Kukoc" },
                    { 6, "marin.cilic@gmail.com", true, "password123", "Marin Cilic" },
                    { 7, "mondo.duplantis@gmail.com", false, "password123", "Mondo Duplantis" },
                    { 8, "luka.doncic@gmail.com", false, "password123", "Luka Doncic" },
                    { 9, "devin.booker@gmail.com", false, "password123", "Devin Booker" },
                    { 10, "kevin.durant@gmail.com", false, "password123", "Kevin Durant" },
                    { 11, "cristiano.ronaldo@gmail.com", false, "password123", "Cristiano Ronaldo" },
                    { 12, "kylian.mbappe@gmail.com", false, "password123", "Kylian Mbappe" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupID", "GroupName", "UserCreatorID" },
                values: new object[,]
                {
                    { 1, "Basketball players", 3 },
                    { 2, "Football players", 2 },
                    { 3, "Others", 1 }
                });

            migrationBuilder.InsertData(
                table: "PrivateMessages",
                columns: new[] { "PrivateMessageID", "Content", "MessageTime", "UserReceiverID", "UserSenderID" },
                values: new object[,]
                {
                    { 1, "Pozdrav Marine, Sime je.", new DateTime(2023, 12, 26, 12, 12, 0, 0, DateTimeKind.Utc), 6, 1 },
                    { 2, "Pozdrav Sime! Kako si?", new DateTime(2023, 12, 26, 12, 14, 0, 0, DateTimeKind.Utc), 1, 6 },
                    { 3, "Odlicno, upravo gledam tvoj prosli mec.", new DateTime(2023, 12, 26, 12, 15, 0, 0, DateTimeKind.Utc), 6, 1 },
                    { 4, "Super, ja upravo koristim tvoju aplikaciju. Pozdrav, Marin.", new DateTime(2023, 12, 26, 12, 16, 0, 0, DateTimeKind.Utc), 1, 6 },
                    { 5, "Pozdrav Luka, Sime je.", new DateTime(2023, 12, 27, 11, 12, 0, 0, DateTimeKind.Utc), 8, 1 },
                    { 6, "Bok Sime, ne mogu sad razgovarat, spremam se za utakmicu.", new DateTime(2023, 12, 27, 11, 12, 0, 0, DateTimeKind.Utc), 1, 8 },
                    { 7, "U redu, cujemo se drugom prilikom.", new DateTime(2023, 12, 27, 11, 15, 0, 0, DateTimeKind.Utc), 8, 1 },
                    { 8, "Pozdrav Cristiano, Luka je.", new DateTime(2023, 12, 26, 12, 12, 0, 0, DateTimeKind.Utc), 11, 8 },
                    { 9, "Bok Luka, cestitam na prinovi.", new DateTime(2023, 12, 26, 12, 13, 0, 0, DateTimeKind.Utc), 8, 11 },
                    { 10, "Hvala ti! Kako je u novom klubu?", new DateTime(2023, 12, 26, 12, 14, 0, 0, DateTimeKind.Utc), 11, 8 },
                    { 11, "Sve je odlicno, hvala na pitanju!", new DateTime(2023, 12, 26, 12, 15, 0, 0, DateTimeKind.Utc), 8, 11 },
                    { 12, "Kad dolazis u Europu?", new DateTime(2023, 12, 26, 12, 16, 0, 0, DateTimeKind.Utc), 8, 11 },
                    { 13, "Na ljeto dolazim u Portugal pa se mozemo vidjeti. ", new DateTime(2023, 12, 26, 12, 17, 0, 0, DateTimeKind.Utc), 11, 8 },
                    { 14, "Dogovoreno, vidimo se!", new DateTime(2023, 12, 26, 12, 20, 0, 0, DateTimeKind.Utc), 8, 11 },
                    { 15, "Pozdrav KD, Punter je.", new DateTime(2023, 12, 28, 10, 15, 0, 0, DateTimeKind.Utc), 10, 3 },
                    { 16, "Bok, kako ti mogu pomoci?", new DateTime(2023, 12, 28, 10, 15, 30, 0, DateTimeKind.Utc), 3, 10 },
                    { 17, "Dolazim u Phoenix za 2 dana, mozes li sredit kartu za utakmicu?", new DateTime(2023, 12, 28, 10, 16, 0, 0, DateTimeKind.Utc), 10, 3 },
                    { 18, "Naravno, poslat cu ti court side ulaznice preko menadzera. Vidimo se!", new DateTime(2023, 12, 28, 10, 18, 30, 0, DateTimeKind.Utc), 3, 10 },
                    { 19, "Pozdrav Livaja, mozes li mi sredit neki transfer u Hajduk?", new DateTime(2023, 12, 29, 12, 11, 0, 0, DateTimeKind.Utc), 2, 12 },
                    { 20, "Nema problema Mbappe, ali broj 10 je zauzet.", new DateTime(2023, 12, 29, 12, 12, 0, 0, DateTimeKind.Utc), 12, 2 },
                    { 21, "Znam tko je glavni u Splitu tako da nema problema. Igrat cu na krilu.", new DateTime(2023, 12, 29, 12, 14, 0, 0, DateTimeKind.Utc), 2, 12 },
                    { 22, "Onda u redu, spojit cu te s Luksom.", new DateTime(2023, 12, 29, 12, 18, 0, 0, DateTimeKind.Utc), 12, 2 }
                });

            migrationBuilder.InsertData(
                table: "GroupMessages",
                columns: new[] { "GroupMessageID", "Content", "GroupID", "MessageTime", "UserSenderID" },
                values: new object[,]
                {
                    { 1, "Ja sam Punter!", 1, new DateTime(2023, 12, 25, 13, 25, 0, 0, DateTimeKind.Utc), 3 },
                    { 2, "Ja sam AntMan!", 1, new DateTime(2023, 12, 26, 12, 25, 0, 0, DateTimeKind.Utc), 4 },
                    { 3, "Ja sam Toni!", 1, new DateTime(2023, 12, 27, 12, 25, 0, 0, DateTimeKind.Utc), 5 },
                    { 4, "Ja sam Luka!", 1, new DateTime(2023, 12, 28, 14, 25, 0, 0, DateTimeKind.Utc), 8 },
                    { 5, "Ja sam Devin!", 1, new DateTime(2023, 12, 27, 15, 25, 0, 0, DateTimeKind.Utc), 9 },
                    { 6, "Ja sam KD!", 1, new DateTime(2023, 12, 27, 12, 28, 0, 0, DateTimeKind.Utc), 10 },
                    { 7, "Ja sam Marko!", 2, new DateTime(2023, 12, 28, 23, 25, 0, 0, DateTimeKind.Utc), 2 },
                    { 8, "Ja sam Cristiano!", 2, new DateTime(2023, 12, 27, 23, 25, 0, 0, DateTimeKind.Utc), 11 },
                    { 9, "Ja sam Kylian!", 2, new DateTime(2023, 12, 28, 23, 29, 0, 0, DateTimeKind.Utc), 12 },
                    { 10, "Ja sam Sime!", 3, new DateTime(2023, 12, 22, 22, 25, 0, 0, DateTimeKind.Utc), 1 },
                    { 11, "Ja sam Marin!", 3, new DateTime(2023, 12, 27, 13, 25, 0, 0, DateTimeKind.Utc), 6 },
                    { 12, "Ja sam Mondo!", 3, new DateTime(2023, 12, 25, 13, 26, 0, 0, DateTimeKind.Utc), 7 }
                });

            migrationBuilder.InsertData(
                table: "GroupUsers",
                columns: new[] { "GroupID", "UserID" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 1, 3 },
                    { 2, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 3, 6 },
                    { 3, 7 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 10 },
                    { 2, 11 },
                    { 2, 12 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GroupMessages",
                keyColumn: "GroupMessageID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GroupMessages",
                keyColumn: "GroupMessageID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GroupMessages",
                keyColumn: "GroupMessageID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GroupMessages",
                keyColumn: "GroupMessageID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GroupMessages",
                keyColumn: "GroupMessageID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "GroupMessages",
                keyColumn: "GroupMessageID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "GroupMessages",
                keyColumn: "GroupMessageID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "GroupMessages",
                keyColumn: "GroupMessageID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "GroupMessages",
                keyColumn: "GroupMessageID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "GroupMessages",
                keyColumn: "GroupMessageID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "GroupMessages",
                keyColumn: "GroupMessageID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "GroupMessages",
                keyColumn: "GroupMessageID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "GroupUsers",
                keyColumns: new[] { "GroupID", "UserID" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "GroupUsers",
                keyColumns: new[] { "GroupID", "UserID" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "GroupUsers",
                keyColumns: new[] { "GroupID", "UserID" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "GroupUsers",
                keyColumns: new[] { "GroupID", "UserID" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "GroupUsers",
                keyColumns: new[] { "GroupID", "UserID" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "GroupUsers",
                keyColumns: new[] { "GroupID", "UserID" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "GroupUsers",
                keyColumns: new[] { "GroupID", "UserID" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "GroupUsers",
                keyColumns: new[] { "GroupID", "UserID" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "GroupUsers",
                keyColumns: new[] { "GroupID", "UserID" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "GroupUsers",
                keyColumns: new[] { "GroupID", "UserID" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "GroupUsers",
                keyColumns: new[] { "GroupID", "UserID" },
                keyValues: new object[] { 2, 11 });

            migrationBuilder.DeleteData(
                table: "GroupUsers",
                keyColumns: new[] { "GroupID", "UserID" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "PrivateMessages",
                keyColumn: "PrivateMessageID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PrivateMessages",
                keyColumn: "PrivateMessageID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PrivateMessages",
                keyColumn: "PrivateMessageID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PrivateMessages",
                keyColumn: "PrivateMessageID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PrivateMessages",
                keyColumn: "PrivateMessageID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PrivateMessages",
                keyColumn: "PrivateMessageID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PrivateMessages",
                keyColumn: "PrivateMessageID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PrivateMessages",
                keyColumn: "PrivateMessageID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PrivateMessages",
                keyColumn: "PrivateMessageID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PrivateMessages",
                keyColumn: "PrivateMessageID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PrivateMessages",
                keyColumn: "PrivateMessageID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PrivateMessages",
                keyColumn: "PrivateMessageID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PrivateMessages",
                keyColumn: "PrivateMessageID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "PrivateMessages",
                keyColumn: "PrivateMessageID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "PrivateMessages",
                keyColumn: "PrivateMessageID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "PrivateMessages",
                keyColumn: "PrivateMessageID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "PrivateMessages",
                keyColumn: "PrivateMessageID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "PrivateMessages",
                keyColumn: "PrivateMessageID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "PrivateMessages",
                keyColumn: "PrivateMessageID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "PrivateMessages",
                keyColumn: "PrivateMessageID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "PrivateMessages",
                keyColumn: "PrivateMessageID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "PrivateMessages",
                keyColumn: "PrivateMessageID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3);
        }
    }
}
