﻿// <auto-generated />
using System;
using Firebend.AutoCrud.Web.Sample.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Firebend.AutoCrud.Web.Sample.Migrations
{
    [DbContext(typeof(PersonDbContext))]
    [Migration("20210817205151_Testing_Other_Email")]
    partial class Testing_Other_Email
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Firebend.AutoCrud.Core.Models.CustomFields.CustomFieldsEntity<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CustomFieldsEntity<Guid>");
                });

            modelBuilder.Entity("Firebend.AutoCrud.CustomFields.EntityFramework.Models.EfCustomFieldsModelTenant<System.Guid, Firebend.AutoCrud.Web.Sample.Models.EfPerson, int>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EntityId")
                        .IsClustered();

                    b.ToTable("EfPeople_CustomFields");
                });

            modelBuilder.Entity("Firebend.AutoCrud.CustomFields.EntityFramework.Models.EfCustomFieldsModelTenant<System.Guid, Firebend.AutoCrud.Web.Sample.Models.EfPet, int>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EntityId")
                        .IsClustered();

                    b.ToTable("Pets_CustomFields");
                });

            modelBuilder.Entity("Firebend.AutoCrud.Web.Sample.Models.EfPerson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTimeOffset>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NickName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("OtherEmail")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("NotEmail");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("OtherEmail")
                        .IsUnique()
                        .HasFilter("[NotEmail] IS NOT NULL");

                    b.ToTable("EfPeople");
                });

            modelBuilder.Entity("Firebend.AutoCrud.Web.Sample.Models.EfPet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("EfPersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("PetName")
                        .IsRequired()
                        .HasMaxLength(205)
                        .HasColumnType("nvarchar(205)");

                    b.Property<string>("PetType")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EfPersonId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("Firebend.AutoCrud.CustomFields.EntityFramework.Models.EfCustomFieldsModelTenant<System.Guid, Firebend.AutoCrud.Web.Sample.Models.EfPerson, int>", b =>
                {
                    b.HasOne("Firebend.AutoCrud.Web.Sample.Models.EfPerson", "Entity")
                        .WithMany("CustomFields")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entity");
                });

            modelBuilder.Entity("Firebend.AutoCrud.CustomFields.EntityFramework.Models.EfCustomFieldsModelTenant<System.Guid, Firebend.AutoCrud.Web.Sample.Models.EfPet, int>", b =>
                {
                    b.HasOne("Firebend.AutoCrud.Web.Sample.Models.EfPet", "Entity")
                        .WithMany("CustomFields")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entity");
                });

            modelBuilder.Entity("Firebend.AutoCrud.Web.Sample.Models.EfPet", b =>
                {
                    b.HasOne("Firebend.AutoCrud.Web.Sample.Models.EfPerson", "Person")
                        .WithMany("Pets")
                        .HasForeignKey("EfPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Firebend.AutoCrud.Web.Sample.Models.EfPerson", b =>
                {
                    b.Navigation("CustomFields");

                    b.Navigation("Pets");
                });

            modelBuilder.Entity("Firebend.AutoCrud.Web.Sample.Models.EfPet", b =>
                {
                    b.Navigation("CustomFields");
                });
#pragma warning restore 612, 618
        }
    }
}
