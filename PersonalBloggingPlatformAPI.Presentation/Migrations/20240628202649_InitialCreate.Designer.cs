﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalBloggingPlatformAPI.Infrastructure.Data;

#nullable disable

namespace PersonalBloggingPlatformAPI.Presentation.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240628202649_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("PersonalBloggingPlatformAPI.Domain.Entities.Article", b =>
                {
                    b.Property<Guid>("ArticleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("BodyText")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PublishingDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("TagId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("ArticleId");

                    b.HasIndex("TagId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("PersonalBloggingPlatformAPI.Domain.Entities.Tag", b =>
                {
                    b.Property<Guid>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("PersonalBloggingPlatformAPI.Domain.Entities.Article", b =>
                {
                    b.HasOne("PersonalBloggingPlatformAPI.Domain.Entities.Tag", null)
                        .WithMany("Articles")
                        .HasForeignKey("TagId");
                });

            modelBuilder.Entity("PersonalBloggingPlatformAPI.Domain.Entities.Tag", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}