﻿// <auto-generated />
using System;
using Artifact_Service_Api.AppData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Artifact_Service_Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241110171716_add many to many to documentNoteAccess")]
    partial class addmanytomanytodocumentNoteAccess
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Artifact_Service_Api.Models.DocumentNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid>("FileId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("FileId");

                    b.ToTable("DocumentNotes");
                });

            modelBuilder.Entity("Artifact_Service_Api.Models.DocumentNoteAccess", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DocumentNoteId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DocumentNoteId");

                    b.HasIndex("UserId");

                    b.ToTable("DocumentNoteAccesses");
                });

            modelBuilder.Entity("Artifact_Service_Api.Models.DocumentNoteTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DocumentNoteId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DocumentNoteId");

                    b.HasIndex("TagId");

                    b.ToTable("DocumentNoteTags");
                });

            modelBuilder.Entity("Artifact_Service_Api.Models.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CustomFileName")
                        .HasColumnType("text");

                    b.Property<Guid?>("NoteId")
                        .HasColumnType("uuid");

                    b.Property<string>("ServerFileName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("NoteId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Artifact_Service_Api.Models.Note", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("boolean");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Artifact_Service_Api.Models.NoteAccess", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("CanEdit")
                        .HasColumnType("boolean");

                    b.Property<Guid>("NoteId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("NoteId");

                    b.HasIndex("UserId");

                    b.ToTable("NoteAccesses");
                });

            modelBuilder.Entity("Artifact_Service_Api.Models.NoteTag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("NoteId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("NoteId");

                    b.HasIndex("TagId");

                    b.ToTable("NoteTags");
                });

            modelBuilder.Entity("Artifact_Service_Api.Models.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Artifact_Service_Api.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("ActivatedEmail")
                        .HasColumnType("boolean");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("GAcoount")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int?>("RegistryCode")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Artifact_Service_Api.Models.DocumentNote", b =>
                {
                    b.HasOne("Artifact_Service_Api.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Artifact_Service_Api.Models.File", "File")
                        .WithMany()
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("File");
                });

            modelBuilder.Entity("Artifact_Service_Api.Models.DocumentNoteAccess", b =>
                {
                    b.HasOne("Artifact_Service_Api.Models.DocumentNote", "DocumentNote")
                        .WithMany("DocumentNoteAccesses")
                        .HasForeignKey("DocumentNoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Artifact_Service_Api.Models.User", "User")
                        .WithMany("DocumentNoteAccesses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentNote");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Artifact_Service_Api.Models.DocumentNoteTag", b =>
                {
                    b.HasOne("Artifact_Service_Api.Models.DocumentNote", "DocumentNote")
                        .WithMany("DocumentNoteTags")
                        .HasForeignKey("DocumentNoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Artifact_Service_Api.Models.Tag", "Tag")
                        .WithMany("DocumentNoteTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentNote");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Artifact_Service_Api.Models.File", b =>
                {
                    b.HasOne("Artifact_Service_Api.Models.Note", null)
                        .WithMany("Files")
                        .HasForeignKey("NoteId");
                });

            modelBuilder.Entity("Artifact_Service_Api.Models.Note", b =>
                {
                    b.HasOne("Artifact_Service_Api.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Artifact_Service_Api.Models.NoteAccess", b =>
                {
                    b.HasOne("Artifact_Service_Api.Models.Note", "Note")
                        .WithMany("NoteAccess")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Artifact_Service_Api.Models.User", "User")
                        .WithMany("NoteAccess")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Note");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Artifact_Service_Api.Models.NoteTag", b =>
                {
                    b.HasOne("Artifact_Service_Api.Models.Note", "Note")
                        .WithMany("NoteTags")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Artifact_Service_Api.Models.Tag", "Tag")
                        .WithMany("NoteTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Note");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Artifact_Service_Api.Models.DocumentNote", b =>
                {
                    b.Navigation("DocumentNoteAccesses");

                    b.Navigation("DocumentNoteTags");
                });

            modelBuilder.Entity("Artifact_Service_Api.Models.Note", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("NoteAccess");

                    b.Navigation("NoteTags");
                });

            modelBuilder.Entity("Artifact_Service_Api.Models.Tag", b =>
                {
                    b.Navigation("DocumentNoteTags");

                    b.Navigation("NoteTags");
                });

            modelBuilder.Entity("Artifact_Service_Api.Models.User", b =>
                {
                    b.Navigation("DocumentNoteAccesses");

                    b.Navigation("NoteAccess");
                });
#pragma warning restore 612, 618
        }
    }
}
