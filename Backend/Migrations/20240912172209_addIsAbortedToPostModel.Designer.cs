﻿// <auto-generated />
using System;
using Backend.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(FoodBoxContext))]
    [Migration("20240912172209_addIsAbortedToPostModel")]
    partial class addIsAbortedToPostModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Backend.models.Post", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FulfillerId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAborted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFulfilled")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Payment")
                        .HasColumnType("int");

                    b.Property<int?>("ReviewOnCreatorId")
                        .HasColumnType("int");

                    b.Property<int?>("ReviewOnFulfillerId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("FulfillerId");

                    b.HasIndex("ReviewOnCreatorId");

                    b.HasIndex("ReviewOnFulfillerId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Backend.models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<int>("FulfillerId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("FulfillerId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Backend.models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClerkId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Backend.models.Post", b =>
                {
                    b.HasOne("Backend.models.User", "Creator")
                        .WithMany("PostHistory")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Backend.models.User", "Fulfiller")
                        .WithMany()
                        .HasForeignKey("FulfillerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Backend.models.User", null)
                        .WithOne("ActivePost")
                        .HasForeignKey("Backend.models.Post", "Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Backend.models.Review", "ReviewOnCreator")
                        .WithMany()
                        .HasForeignKey("ReviewOnCreatorId");

                    b.HasOne("Backend.models.Review", "ReviewOnFulfiller")
                        .WithMany()
                        .HasForeignKey("ReviewOnFulfillerId");

                    b.HasOne("Backend.models.User", null)
                        .WithMany("AcceptedJobs")
                        .HasForeignKey("UserId");

                    b.Navigation("Creator");

                    b.Navigation("Fulfiller");

                    b.Navigation("ReviewOnCreator");

                    b.Navigation("ReviewOnFulfiller");
                });

            modelBuilder.Entity("Backend.models.Review", b =>
                {
                    b.HasOne("Backend.models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Backend.models.User", "Fulfiller")
                        .WithMany()
                        .HasForeignKey("FulfillerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Fulfiller");
                });

            modelBuilder.Entity("Backend.models.User", b =>
                {
                    b.Navigation("AcceptedJobs");

                    b.Navigation("ActivePost");

                    b.Navigation("PostHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
