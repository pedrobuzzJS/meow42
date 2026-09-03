using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace mewo42_api.Migrations
{
    /// <inheritdoc />
    public partial class Start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "aud");

            migrationBuilder.EnsureSchema(
                name: "web");

            migrationBuilder.EnsureSchema(
                name: "pro");

            migrationBuilder.EnsureSchema(
                name: "uni");

            migrationBuilder.EnsureSchema(
                name: "doc");

            migrationBuilder.EnsureSchema(
                name: "evt");

            migrationBuilder.EnsureSchema(
                name: "sys");

            migrationBuilder.EnsureSchema(
                name: "log");

            migrationBuilder.EnsureSchema(
                name: "adm");

            migrationBuilder.EnsureSchema(
                name: "tkt");

            migrationBuilder.EnsureSchema(
                name: "itg");

            migrationBuilder.CreateTable(
                name: "tbcompany",
                schema: "uni",
                columns: table => new
                {
                    companyid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    domain = table.Column<string>(type: "text", nullable: true),
                    subdomain = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    pln = table.Column<string>(type: "text", nullable: false),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcompany", x => x.companyid);
                });

            migrationBuilder.CreateTable(
                name: "tbpermission",
                schema: "adm",
                columns: table => new
                {
                    permid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbpermission", x => x.permid);
                });

            migrationBuilder.CreateTable(
                name: "tbrole",
                schema: "adm",
                columns: table => new
                {
                    roleid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbrole", x => x.roleid);
                });

            migrationBuilder.CreateTable(
                name: "tbaudit",
                schema: "aud",
                columns: table => new
                {
                    auditid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbaudit", x => x.auditid);
                    table.ForeignKey(
                        name: "FK_tbaudit_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbbanner",
                schema: "web",
                columns: table => new
                {
                    banid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbbanner", x => x.banid);
                    table.ForeignKey(
                        name: "FK_tbbanner_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbbannergroup",
                schema: "web",
                columns: table => new
                {
                    bangid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    height = table.Column<string>(type: "text", nullable: false),
                    width = table.Column<string>(type: "text", nullable: false),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbbannergroup", x => x.bangid);
                    table.ForeignKey(
                        name: "FK_tbbannergroup_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbbrand",
                schema: "pro",
                columns: table => new
                {
                    brandid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbbrand", x => x.brandid);
                    table.ForeignKey(
                        name: "FK_tbbrand_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbcategory",
                schema: "pro",
                columns: table => new
                {
                    catid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcategory", x => x.catid);
                    table.ForeignKey(
                        name: "FK_tbcategory_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbderivation",
                schema: "pro",
                columns: table => new
                {
                    derivid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbderivation", x => x.derivid);
                    table.ForeignKey(
                        name: "FK_tbderivation_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbderivationitem",
                schema: "pro",
                columns: table => new
                {
                    derivitemid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbderivationitem", x => x.derivitemid);
                    table.ForeignKey(
                        name: "FK_tbderivationitem_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbdocumentsignature",
                schema: "doc",
                columns: table => new
                {
                    docsigid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbdocumentsignature", x => x.docsigid);
                    table.ForeignKey(
                        name: "FK_tbdocumentsignature_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbdocumenttemplate",
                schema: "doc",
                columns: table => new
                {
                    doctid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbdocumenttemplate", x => x.doctid);
                    table.ForeignKey(
                        name: "FK_tbdocumenttemplate_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbevent",
                schema: "evt",
                columns: table => new
                {
                    evtid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbevent", x => x.evtid);
                    table.ForeignKey(
                        name: "FK_tbevent_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbfile",
                schema: "sys",
                columns: table => new
                {
                    fileid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    filename = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    directory = table.Column<string>(type: "text", nullable: false),
                    mimetype = table.Column<string>(type: "text", nullable: false),
                    size = table.Column<decimal>(type: "numeric", nullable: false),
                    @virtual = table.Column<bool>(name: "virtual", type: "boolean", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbfile", x => x.fileid);
                    table.ForeignKey(
                        name: "FK_tbfile_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbform",
                schema: "sys",
                columns: table => new
                {
                    formid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: false),
                    fields = table.Column<string>(type: "text", nullable: false),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbform", x => x.formid);
                    table.ForeignKey(
                        name: "FK_tbform_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbinventory",
                schema: "log",
                columns: table => new
                {
                    invtid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbinventory", x => x.invtid);
                    table.ForeignKey(
                        name: "FK_tbinventory_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbinventorymovement",
                schema: "log",
                columns: table => new
                {
                    invtmid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbinventorymovement", x => x.invtmid);
                    table.ForeignKey(
                        name: "FK_tbinventorymovement_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblog",
                schema: "aud",
                columns: table => new
                {
                    logid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblog", x => x.logid);
                    table.ForeignKey(
                        name: "FK_tblog_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbmenu",
                schema: "sys",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    parameters = table.Column<string>(type: "text", nullable: true),
                    route = table.Column<string>(type: "text", nullable: true),
                    parent_id = table.Column<int>(type: "integer", nullable: true),
                    has_children = table.Column<bool>(type: "boolean", nullable: true),
                    icon = table.Column<string>(type: "text", nullable: true),
                    order = table.Column<int>(type: "integer", nullable: true),
                    disabled = table.Column<bool>(type: "boolean", nullable: false),
                    divisor = table.Column<bool>(type: "boolean", nullable: true),
                    type = table.Column<string>(type: "text", nullable: true),
                    template = table.Column<string>(type: "text", nullable: true),
                    render = table.Column<string>(type: "text", nullable: true),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbmenu", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbmenu_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbmodule",
                schema: "sys",
                columns: table => new
                {
                    moduleid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbmodule", x => x.moduleid);
                    table.ForeignKey(
                        name: "FK_tbmodule_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbpage",
                schema: "web",
                columns: table => new
                {
                    pgid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    slug = table.Column<string>(type: "text", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    mobile = table.Column<bool>(type: "boolean", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    widgets = table.Column<string>(type: "text", nullable: false),
                    redirect = table.Column<string>(type: "text", nullable: false),
                    htmlkeywords = table.Column<string>(type: "text", nullable: false),
                    htmldescription = table.Column<string>(type: "text", nullable: false),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbpage", x => x.pgid);
                    table.ForeignKey(
                        name: "FK_tbpage_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbperson",
                schema: "uni",
                columns: table => new
                {
                    perid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    cpfcnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    tag = table.Column<string>(type: "text", nullable: false, comment: "Tag da Pessoa"),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbperson", x => x.perid);
                    table.ForeignKey(
                        name: "FK_tbperson_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbproduct",
                schema: "pro",
                columns: table => new
                {
                    productid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbproduct", x => x.productid);
                    table.ForeignKey(
                        name: "FK_tbproduct_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbproductderivation",
                schema: "pro",
                columns: table => new
                {
                    prodderivid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbproductderivation", x => x.prodderivid);
                    table.ForeignKey(
                        name: "FK_tbproductderivation_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbroutine",
                schema: "sys",
                columns: table => new
                {
                    routineid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbroutine", x => x.routineid);
                    table.ForeignKey(
                        name: "FK_tbroutine_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbticket",
                schema: "tkt",
                columns: table => new
                {
                    tktid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbticket", x => x.tktid);
                    table.ForeignKey(
                        name: "FK_tbticket_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbuser",
                schema: "adm",
                columns: table => new
                {
                    usrid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    login = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    token = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbuser", x => x.usrid);
                    table.ForeignKey(
                        name: "FK_tbuser_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbwebhook",
                schema: "itg",
                columns: table => new
                {
                    wbhid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    uri = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    @default = table.Column<bool>(name: "default", type: "boolean", nullable: false),
                    mapper = table.Column<bool>(type: "boolean", nullable: false),
                    payload = table.Column<string>(type: "text", nullable: false),
                    listening = table.Column<bool>(type: "boolean", nullable: false),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbwebhook", x => x.wbhid);
                    table.ForeignKey(
                        name: "FK_tbwebhook_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbrolepermission",
                columns: table => new
                {
                    PermissionsId = table.Column<int>(type: "integer", nullable: false),
                    RolesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbrolepermission", x => new { x.PermissionsId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_tbrolepermission_tbpermission_PermissionsId",
                        column: x => x.PermissionsId,
                        principalSchema: "adm",
                        principalTable: "tbpermission",
                        principalColumn: "permid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbrolepermission_tbrole_RolesId",
                        column: x => x.RolesId,
                        principalSchema: "adm",
                        principalTable: "tbrole",
                        principalColumn: "roleid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbeventdate",
                schema: "evt",
                columns: table => new
                {
                    evtdateid = table.Column<int>(type: "integer", nullable: false),
                    evtid = table.Column<int>(type: "integer", nullable: false),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbeventdate", x => new { x.evtdateid, x.evtid });
                    table.ForeignKey(
                        name: "FK_tbeventdate_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbeventdate_tbevent_evtid",
                        column: x => x.evtid,
                        principalSchema: "evt",
                        principalTable: "tbevent",
                        principalColumn: "evtid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbeventlocal",
                schema: "evt",
                columns: table => new
                {
                    evtlocalid = table.Column<int>(type: "integer", nullable: false),
                    evtid = table.Column<int>(type: "integer", nullable: false),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbeventlocal", x => new { x.evtlocalid, x.evtid });
                    table.ForeignKey(
                        name: "FK_tbeventlocal_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbeventlocal_tbevent_evtid",
                        column: x => x.evtid,
                        principalSchema: "evt",
                        principalTable: "tbevent",
                        principalColumn: "evtid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbsetting",
                schema: "sys",
                columns: table => new
                {
                    settingid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false),
                    moduleid = table.Column<int>(type: "integer", nullable: false),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbsetting", x => x.settingid);
                    table.ForeignKey(
                        name: "FK_tbsetting_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbsetting_tbmodule_moduleid",
                        column: x => x.moduleid,
                        principalSchema: "sys",
                        principalTable: "tbmodule",
                        principalColumn: "moduleid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbpersoncontact",
                schema: "uni",
                columns: table => new
                {
                    percid = table.Column<int>(type: "integer", nullable: false),
                    perid = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false),
                    principal = table.Column<bool>(type: "boolean", nullable: false),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbpersoncontact", x => new { x.percid, x.perid });
                    table.ForeignKey(
                        name: "FK_tbpersoncontact_tbperson_perid",
                        column: x => x.perid,
                        principalSchema: "uni",
                        principalTable: "tbperson",
                        principalColumn: "perid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbticketbatch",
                schema: "tkt",
                columns: table => new
                {
                    tktbid = table.Column<int>(type: "integer", nullable: false),
                    tktid = table.Column<int>(type: "integer", nullable: false),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbticketbatch", x => new { x.tktbid, x.tktid });
                    table.ForeignKey(
                        name: "FK_tbticketbatch_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbticketbatch_tbticket_tktid",
                        column: x => x.tktid,
                        principalSchema: "tkt",
                        principalTable: "tbticket",
                        principalColumn: "tktid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbusernotification",
                schema: "adm",
                columns: table => new
                {
                    usernid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    usrid = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    body = table.Column<string>(type: "text", nullable: false),
                    message = table.Column<string>(type: "text", nullable: false),
                    isread = table.Column<bool>(type: "boolean", nullable: false),
                    company_id = table.Column<int>(type: "integer", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbusernotification", x => x.usernid);
                    table.ForeignKey(
                        name: "FK_tbusernotification_tbcompany_company_id",
                        column: x => x.company_id,
                        principalSchema: "uni",
                        principalTable: "tbcompany",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbusernotification_tbuser_usrid",
                        column: x => x.usrid,
                        principalSchema: "adm",
                        principalTable: "tbuser",
                        principalColumn: "usrid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbaudit_company_id",
                schema: "aud",
                table: "tbaudit",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbbanner_company_id",
                schema: "web",
                table: "tbbanner",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbbannergroup_company_id",
                schema: "web",
                table: "tbbannergroup",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbbrand_company_id",
                schema: "pro",
                table: "tbbrand",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbcategory_company_id",
                schema: "pro",
                table: "tbcategory",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbderivation_company_id",
                schema: "pro",
                table: "tbderivation",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbderivationitem_company_id",
                schema: "pro",
                table: "tbderivationitem",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbdocumentsignature_company_id",
                schema: "doc",
                table: "tbdocumentsignature",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbdocumenttemplate_company_id",
                schema: "doc",
                table: "tbdocumenttemplate",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbevent_company_id",
                schema: "evt",
                table: "tbevent",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbeventdate_company_id",
                schema: "evt",
                table: "tbeventdate",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbeventdate_evtid",
                schema: "evt",
                table: "tbeventdate",
                column: "evtid");

            migrationBuilder.CreateIndex(
                name: "IX_tbeventlocal_company_id",
                schema: "evt",
                table: "tbeventlocal",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbeventlocal_evtid",
                schema: "evt",
                table: "tbeventlocal",
                column: "evtid");

            migrationBuilder.CreateIndex(
                name: "IX_tbfile_company_id",
                schema: "sys",
                table: "tbfile",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbform_company_id",
                schema: "sys",
                table: "tbform",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbinventory_company_id",
                schema: "log",
                table: "tbinventory",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbinventorymovement_company_id",
                schema: "log",
                table: "tbinventorymovement",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblog_company_id",
                schema: "aud",
                table: "tblog",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbmenu_company_id",
                schema: "sys",
                table: "tbmenu",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbmodule_company_id",
                schema: "sys",
                table: "tbmodule",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbpage_company_id",
                schema: "web",
                table: "tbpage",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbperson_company_id",
                schema: "uni",
                table: "tbperson",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbpersoncontact_perid",
                schema: "uni",
                table: "tbpersoncontact",
                column: "perid");

            migrationBuilder.CreateIndex(
                name: "IX_tbproduct_company_id",
                schema: "pro",
                table: "tbproduct",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbproductderivation_company_id",
                schema: "pro",
                table: "tbproductderivation",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbrolepermission_RolesId",
                table: "tbrolepermission",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_tbroutine_company_id",
                schema: "sys",
                table: "tbroutine",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbsetting_company_id",
                schema: "sys",
                table: "tbsetting",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbsetting_moduleid",
                schema: "sys",
                table: "tbsetting",
                column: "moduleid");

            migrationBuilder.CreateIndex(
                name: "IX_tbticket_company_id",
                schema: "tkt",
                table: "tbticket",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbticketbatch_company_id",
                schema: "tkt",
                table: "tbticketbatch",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbticketbatch_tktid",
                schema: "tkt",
                table: "tbticketbatch",
                column: "tktid");

            migrationBuilder.CreateIndex(
                name: "IX_tbuser_company_id",
                schema: "adm",
                table: "tbuser",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbusernotification_company_id",
                schema: "adm",
                table: "tbusernotification",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbusernotification_usrid",
                schema: "adm",
                table: "tbusernotification",
                column: "usrid");

            migrationBuilder.CreateIndex(
                name: "IX_tbwebhook_company_id",
                schema: "itg",
                table: "tbwebhook",
                column: "company_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbaudit",
                schema: "aud");

            migrationBuilder.DropTable(
                name: "tbbanner",
                schema: "web");

            migrationBuilder.DropTable(
                name: "tbbannergroup",
                schema: "web");

            migrationBuilder.DropTable(
                name: "tbbrand",
                schema: "pro");

            migrationBuilder.DropTable(
                name: "tbcategory",
                schema: "pro");

            migrationBuilder.DropTable(
                name: "tbderivation",
                schema: "pro");

            migrationBuilder.DropTable(
                name: "tbderivationitem",
                schema: "pro");

            migrationBuilder.DropTable(
                name: "tbdocumentsignature",
                schema: "doc");

            migrationBuilder.DropTable(
                name: "tbdocumenttemplate",
                schema: "doc");

            migrationBuilder.DropTable(
                name: "tbeventdate",
                schema: "evt");

            migrationBuilder.DropTable(
                name: "tbeventlocal",
                schema: "evt");

            migrationBuilder.DropTable(
                name: "tbfile",
                schema: "sys");

            migrationBuilder.DropTable(
                name: "tbform",
                schema: "sys");

            migrationBuilder.DropTable(
                name: "tbinventory",
                schema: "log");

            migrationBuilder.DropTable(
                name: "tbinventorymovement",
                schema: "log");

            migrationBuilder.DropTable(
                name: "tblog",
                schema: "aud");

            migrationBuilder.DropTable(
                name: "tbmenu",
                schema: "sys");

            migrationBuilder.DropTable(
                name: "tbpage",
                schema: "web");

            migrationBuilder.DropTable(
                name: "tbpersoncontact",
                schema: "uni");

            migrationBuilder.DropTable(
                name: "tbproduct",
                schema: "pro");

            migrationBuilder.DropTable(
                name: "tbproductderivation",
                schema: "pro");

            migrationBuilder.DropTable(
                name: "tbrolepermission");

            migrationBuilder.DropTable(
                name: "tbroutine",
                schema: "sys");

            migrationBuilder.DropTable(
                name: "tbsetting",
                schema: "sys");

            migrationBuilder.DropTable(
                name: "tbticketbatch",
                schema: "tkt");

            migrationBuilder.DropTable(
                name: "tbusernotification",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "tbwebhook",
                schema: "itg");

            migrationBuilder.DropTable(
                name: "tbevent",
                schema: "evt");

            migrationBuilder.DropTable(
                name: "tbperson",
                schema: "uni");

            migrationBuilder.DropTable(
                name: "tbpermission",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "tbrole",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "tbmodule",
                schema: "sys");

            migrationBuilder.DropTable(
                name: "tbticket",
                schema: "tkt");

            migrationBuilder.DropTable(
                name: "tbuser",
                schema: "adm");

            migrationBuilder.DropTable(
                name: "tbcompany",
                schema: "uni");
        }
    }
}
