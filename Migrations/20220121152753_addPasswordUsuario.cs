﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TVA_Registro_de_Vacunados.Migrations
{
    public partial class addPasswordUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Usuarios",
                type: "BLOB",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Usuarios",
                type: "BLOB",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Usuarios");
        }
    }
}
