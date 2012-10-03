using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;


namespace Skeletor.DatabaseMigrations
{

    /// <summary>
    /// By convention, attribute all migrations with the current date in the format yyyyMMddHHmm, e.g.201210031600
    /// </summary>

    [Migration(201210031600)]
    public class CreateUserTable : Migration
    {
        public override void Up()
        {
            Create.Table("User")
                .WithColumn("UserId").AsGuid().NotNullable().PrimaryKey().Identity()
                .WithColumn("UserName").AsString(200).NotNullable()
                .WithColumn("FirstName").AsString(200).NotNullable()
                .WithColumn("LastnNme").AsString(200).NotNullable()
                .WithColumn("Email").AsString(255).NotNullable()
                .WithColumn("IsSystem").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("CreatedByUserId").AsGuid().Nullable()
                .WithColumn("CreatedUtcDate").AsDateTime().Nullable()
                .WithColumn("ModifiedByUserId").AsGuid().Nullable()
                .WithColumn("ModifiedUtcDate").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Delete.Table("User");
        }
    }
}
