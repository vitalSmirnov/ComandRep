﻿// <auto-generated />
using System;
using CloneIntime.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CloneIntime.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CloneIntime.Entities.AuditoryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Building")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuditoryEntities");
                });

            modelBuilder.Entity("CloneIntime.Entities.DayEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DayName")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("DayEntities");
                });

            modelBuilder.Entity("CloneIntime.Entities.DirectionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FacultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("DirectionEntities");
                });

            modelBuilder.Entity("CloneIntime.Entities.DisciplineEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GroupEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TeacherEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GroupEntityId");

                    b.HasIndex("TeacherEntityId");

                    b.ToTable("DisciplineEntities");
                });

            modelBuilder.Entity("CloneIntime.Entities.EditorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EditorEntity");
                });

            modelBuilder.Entity("CloneIntime.Entities.FacultyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FacultyEntities");
                });

            modelBuilder.Entity("CloneIntime.Entities.GroupEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DirectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DirectionId");

                    b.ToTable("GroupEntities");
                });

            modelBuilder.Entity("CloneIntime.Entities.PairEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuditoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DisciplineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LessonType")
                        .HasColumnType("int");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TimeSlotEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AuditoryId");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("TeacherId");

                    b.HasIndex("TimeSlotEntityId");

                    b.ToTable("PairEntities");
                });

            modelBuilder.Entity("CloneIntime.Entities.TeacherEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TeachersEntities");
                });

            modelBuilder.Entity("CloneIntime.Entities.TimeSlotEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DayEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("PairNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DayEntityId");

                    b.ToTable("TimeSlotEntities");
                });

            modelBuilder.Entity("CloneIntime.Models.Entities.TokenEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TokenEntity");
                });

            modelBuilder.Entity("GroupEntityPairEntity", b =>
                {
                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PairsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GroupId", "PairsId");

                    b.HasIndex("PairsId");

                    b.ToTable("GroupEntityPairEntity");
                });

            modelBuilder.Entity("CloneIntime.Entities.DirectionEntity", b =>
                {
                    b.HasOne("CloneIntime.Entities.FacultyEntity", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("CloneIntime.Entities.DisciplineEntity", b =>
                {
                    b.HasOne("CloneIntime.Entities.GroupEntity", null)
                        .WithMany("Disciplines")
                        .HasForeignKey("GroupEntityId");

                    b.HasOne("CloneIntime.Entities.TeacherEntity", null)
                        .WithMany("Disciplines")
                        .HasForeignKey("TeacherEntityId");
                });

            modelBuilder.Entity("CloneIntime.Entities.GroupEntity", b =>
                {
                    b.HasOne("CloneIntime.Entities.DirectionEntity", "Direction")
                        .WithMany()
                        .HasForeignKey("DirectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Direction");
                });

            modelBuilder.Entity("CloneIntime.Entities.PairEntity", b =>
                {
                    b.HasOne("CloneIntime.Entities.AuditoryEntity", "Auditory")
                        .WithMany()
                        .HasForeignKey("AuditoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CloneIntime.Entities.DisciplineEntity", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CloneIntime.Entities.TeacherEntity", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CloneIntime.Entities.TimeSlotEntity", null)
                        .WithMany("Pair")
                        .HasForeignKey("TimeSlotEntityId");

                    b.Navigation("Auditory");

                    b.Navigation("Discipline");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("CloneIntime.Entities.TimeSlotEntity", b =>
                {
                    b.HasOne("CloneIntime.Entities.DayEntity", null)
                        .WithMany("Lessons")
                        .HasForeignKey("DayEntityId");
                });

            modelBuilder.Entity("GroupEntityPairEntity", b =>
                {
                    b.HasOne("CloneIntime.Entities.GroupEntity", null)
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CloneIntime.Entities.PairEntity", null)
                        .WithMany()
                        .HasForeignKey("PairsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CloneIntime.Entities.DayEntity", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("CloneIntime.Entities.GroupEntity", b =>
                {
                    b.Navigation("Disciplines");
                });

            modelBuilder.Entity("CloneIntime.Entities.TeacherEntity", b =>
                {
                    b.Navigation("Disciplines");
                });

            modelBuilder.Entity("CloneIntime.Entities.TimeSlotEntity", b =>
                {
                    b.Navigation("Pair");
                });
#pragma warning restore 612, 618
        }
    }
}
