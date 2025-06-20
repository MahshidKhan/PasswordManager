using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasswordManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedDummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
{
    // Insert dummy data
    migrationBuilder.InsertData(
        table: "Passwords",
        columns: new[] { "Category", "App", "UserName", "EncryptedPassword", "CreatedAt", "UpdatedAt" },
        values: new object[,]
        {
            // Original 5 rows
            { "work",           "Outlook",        "john.doe@company.com",   "V29ya1Bhc3MxMjMh",        DateTime.UtcNow, DateTime.UtcNow },
            { "social",         "Facebook",       "john.doe@gmail.com",     "RmFjZWJvb2syMDIz",        DateTime.UtcNow, DateTime.UtcNow },
            { "banking",        "Chase Bank",     "johndoe123",             "U2VjdXJlQmFuazQ1Ng==",   DateTime.UtcNow, DateTime.UtcNow },
            { "entertainment",  "Netflix",        "john.doe@email.com",     "TmV0ZmxpeDc4OQ==",        DateTime.UtcNow, DateTime.UtcNow },
            { "shopping",       "Amazon",         "johndoe@amazon.com",     "QW1hem9uMjAyMyE=",        DateTime.UtcNow, DateTime.UtcNow },

            // 20 additional rows
            { "work",           "Slack",          "john.doe@company.com",   "U2xhY2tQYXNzMTIzIQ==",    DateTime.UtcNow, DateTime.UtcNow },
            { "work",           "GitHub",         "johndoe",                "R2l0SHViUGFzczQ1Ng==",    DateTime.UtcNow, DateTime.UtcNow },

            { "social",         "Twitter",        "john_doe",               "VHdpdHRlclBhc3Mh",        DateTime.UtcNow, DateTime.UtcNow },
            { "social",         "Instagram",      "john.doe",               "SW5zdGFnUGFzc18=",        DateTime.UtcNow, DateTime.UtcNow },

            { "banking",        "PayPal",         "john.doe@paypal.com",    "UGF5UGFsUGFzczEyMw==",    DateTime.UtcNow, DateTime.UtcNow },
            { "banking",        "Bank of America","jdoe_boa",               "Qk9BMTIzNDU2",            DateTime.UtcNow, DateTime.UtcNow },

            { "entertainment",  "Spotify",        "john_doe_music",         "U3BvdGlmeVBhc3Mh",        DateTime.UtcNow, DateTime.UtcNow },
            { "entertainment",  "Hulu",           "john.doe@hulu.com",      "SHVsdVBhc3MxMjM=",        DateTime.UtcNow, DateTime.UtcNow },

            { "shopping",       "eBay",           "john.doe@ebay.com",      "ZUJheVBhc3M0NTY=",        DateTime.UtcNow, DateTime.UtcNow },
            { "shopping",       "Alibaba",        "johndoe@alibaba.com",    "QWxpYmFiYVBhc3Mh",        DateTime.UtcNow, DateTime.UtcNow },

            { "education",      "Coursera",       "john.doe@gmail.com",     "Q291cnNlcmFQYXNz",        DateTime.UtcNow, DateTime.UtcNow },
            { "education",      "edX",            "john.doe@gmail.com",     "ZWR4MTIzUGFzcw==",        DateTime.UtcNow, DateTime.UtcNow },

            { "gaming",         "Steam",          "johndoe_steam",          "U3RlYW1QYXNz",            DateTime.UtcNow, DateTime.UtcNow },
            { "gaming",         "Epic Games",     "john_doe",               "RXBpY1BhczEyMw==",        DateTime.UtcNow, DateTime.UtcNow },

            { "utilities",      "Dropbox",        "john.doe@gmail.com",     "RHJvcGJveFBhc3Mh",        DateTime.UtcNow, DateTime.UtcNow },
            { "utilities",      "Google Drive",   "john.doe@gmail.com",     "R29vZ2xlRHJpdmVQYXNz",    DateTime.UtcNow, DateTime.UtcNow },

            { "health",         "MyFitnessPal",   "john.doe",               "TXlGaXRuZXNzUGFs",        DateTime.UtcNow, DateTime.UtcNow },
            { "health",         "Apple Health",   "john.doe@icloud.com",    "QXBwbGVIZWFsdGg=",        DateTime.UtcNow, DateTime.UtcNow },

            { "travel",         "Airbnb",         "john.doe@gmail.com",     "QWlyYm5iUGFzcw==",        DateTime.UtcNow, DateTime.UtcNow },
            { "travel",         "Booking.com",    "john.doe",               "Qm9va2luZ1Bhc3M=",        DateTime.UtcNow, DateTime.UtcNow }
        });
}


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
