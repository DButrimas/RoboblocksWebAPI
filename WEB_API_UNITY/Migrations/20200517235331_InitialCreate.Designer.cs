﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RoboblocksWebAPI.Data;

namespace RoboblocksWebAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200517235331_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RoboblocksWebAPI.Models.Level", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("RoboblocksWebAPI.Models.LevelTopScore", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Complition_time")
                        .HasColumnType("real");

                    b.Property<long>("LevelId")
                        .HasColumnType("bigint");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TopLevelScores");
                });

            modelBuilder.Entity("RoboblocksWebAPI.Models.Object", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("LevelId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("b")
                        .HasColumnType("real");

                    b.Property<float>("g")
                        .HasColumnType("real");

                    b.Property<float>("posX")
                        .HasColumnType("real");

                    b.Property<float>("posY")
                        .HasColumnType("real");

                    b.Property<float>("posZ")
                        .HasColumnType("real");

                    b.Property<float>("r")
                        .HasColumnType("real");

                    b.Property<float>("rotationX")
                        .HasColumnType("real");

                    b.Property<float>("rotationY")
                        .HasColumnType("real");

                    b.Property<float>("rotationZ")
                        .HasColumnType("real");

                    b.Property<float>("scaleX")
                        .HasColumnType("real");

                    b.Property<float>("scaleY")
                        .HasColumnType("real");

                    b.Property<float>("scaleZ")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("LevelId");

                    b.ToTable("Objects");
                });

            modelBuilder.Entity("RoboblocksWebAPI.Models.Rating", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("LevelId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<float>("User_rating")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("LevelId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("RoboblocksWebAPI.Models.TankProperties", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("BarrelRotationSpeed")
                        .HasColumnType("real");

                    b.Property<float>("MovementSpeed")
                        .HasColumnType("real");

                    b.Property<float>("ShootingSpeed")
                        .HasColumnType("real");

                    b.Property<float>("TriggerScale")
                        .HasColumnType("real");

                    b.Property<long>("levelId")
                        .HasColumnType("bigint");

                    b.Property<string>("levelName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TankProperties");
                });

            modelBuilder.Entity("RoboblocksWebAPI.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RoboblocksWebAPI.Models.Waypoint", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LevelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ObjectId")
                        .HasColumnType("int");

                    b.Property<float>("posX")
                        .HasColumnType("real");

                    b.Property<float>("posY")
                        .HasColumnType("real");

                    b.Property<float>("posZ")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Waypoints");
                });

            modelBuilder.Entity("RoboblocksWebAPI.Models.Level", b =>
                {
                    b.HasOne("RoboblocksWebAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("RoboblocksWebAPI.Models.Object", b =>
                {
                    b.HasOne("RoboblocksWebAPI.Models.Level", null)
                        .WithMany("Objects")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoboblocksWebAPI.Models.Rating", b =>
                {
                    b.HasOne("RoboblocksWebAPI.Models.Level", null)
                        .WithMany("Ratings")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
