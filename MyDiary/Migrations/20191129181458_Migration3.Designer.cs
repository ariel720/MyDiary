﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyDiary.Models;

namespace MyDiary.Migrations
{
    [DbContext(typeof(MyDiaryContext))]
    [Migration("20191129181458_Migration3")]
    partial class Migration3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyDiary.Models.Content", b =>
                {
                    b.Property<int>("ContentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Text");

                    b.Property<string>("Title");

                    b.Property<string>("Writer");

                    b.HasKey("ContentId");

                    b.ToTable("Content");
                });

            modelBuilder.Entity("MyDiary.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContentId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Text");

                    b.Property<string>("Writer");

                    b.HasKey("ReviewId");

                    b.HasIndex("ContentId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("MyDiary.Models.Review", b =>
                {
                    b.HasOne("MyDiary.Models.Content")
                        .WithMany("Reviews")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
