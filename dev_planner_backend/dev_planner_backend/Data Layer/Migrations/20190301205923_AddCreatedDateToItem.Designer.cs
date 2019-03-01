﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dev_planner_backend.Contexts;

namespace dev_planner_backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190301205923_AddCreatedDateToItem")]
    partial class AddCreatedDateToItem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview3-35497")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("dev_planner_backend.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<int?>("CommentId");

                    b.Property<string>("Content")
                        .HasMaxLength(300);

                    b.Property<int?>("ItemId");

                    b.Property<DateTimeOffset>("PublishDate");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CommentId");

                    b.HasIndex("ItemId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("dev_planner_backend.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("Created");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("OwnerId");

                    b.Property<int>("StateId");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("StateId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("dev_planner_backend.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("dev_planner_backend.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("dev_planner_backend.Models.Comment", b =>
                {
                    b.HasOne("dev_planner_backend.Models.Person", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("dev_planner_backend.Models.Comment")
                        .WithMany("Replies")
                        .HasForeignKey("CommentId");

                    b.HasOne("dev_planner_backend.Models.Item")
                        .WithMany("Comments")
                        .HasForeignKey("ItemId");
                });

            modelBuilder.Entity("dev_planner_backend.Models.Item", b =>
                {
                    b.HasOne("dev_planner_backend.Models.Person", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.HasOne("dev_planner_backend.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
