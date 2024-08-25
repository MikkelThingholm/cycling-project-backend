﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace cycling_project_web_api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("App.EntityModels.MetaTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id")
                        .HasName("pk_meta_teams");

                    b.ToTable("meta_teams", (string)null);
                });

            modelBuilder.Entity("App.EntityModels.Nation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<bool>("StillExists")
                        .HasColumnType("boolean")
                        .HasColumnName("still_exists");

                    b.HasKey("Id")
                        .HasName("pk_nations");

                    b.ToTable("nations", (string)null);
                });

            modelBuilder.Entity("App.EntityModels.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<int>("NationId")
                        .HasColumnType("integer")
                        .HasColumnName("nation_id");

                    b.HasKey("Id")
                        .HasName("pk_races");

                    b.HasIndex("NationId")
                        .HasDatabaseName("ix_races_nation_id");

                    b.ToTable("races", (string)null);
                });

            modelBuilder.Entity("App.EntityModels.RaceEdition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("class_name");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date")
                        .HasColumnName("end_date");

                    b.Property<string>("RaceEditionType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("race_edition_type");

                    b.Property<int>("RaceId")
                        .HasColumnType("integer")
                        .HasColumnName("race_id");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date")
                        .HasColumnName("start_date");

                    b.Property<short>("Year")
                        .HasColumnType("Int2")
                        .HasColumnName("year");

                    b.HasKey("Id")
                        .HasName("pk_race_editions");

                    b.HasIndex("RaceId")
                        .HasDatabaseName("ix_race_editions_race_id");

                    b.ToTable("race_editions", (string)null);
                });

            modelBuilder.Entity("App.EntityModels.Rider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("birth_date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("last_name");

                    b.Property<int>("NationId")
                        .HasColumnType("integer")
                        .HasColumnName("nation_id");

                    b.HasKey("Id")
                        .HasName("pk_riders");

                    b.HasIndex("NationId")
                        .HasDatabaseName("ix_riders_nation_id");

                    b.ToTable("riders", (string)null);
                });

            modelBuilder.Entity("App.EntityModels.RiderTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("End")
                        .HasColumnType("date")
                        .HasColumnName("end");

                    b.Property<int>("RiderId")
                        .HasColumnType("integer")
                        .HasColumnName("rider_id");

                    b.Property<DateOnly>("Start")
                        .HasColumnType("date")
                        .HasColumnName("start");

                    b.Property<int>("TeamId")
                        .HasColumnType("integer")
                        .HasColumnName("team_id");

                    b.HasKey("Id")
                        .HasName("pk_rider_teams");

                    b.HasIndex("RiderId")
                        .HasDatabaseName("ix_rider_teams_rider_id");

                    b.HasIndex("TeamId")
                        .HasDatabaseName("ix_rider_teams_team_id");

                    b.ToTable("rider_teams", (string)null);
                });

            modelBuilder.Entity("App.EntityModels.Stage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<int>("Distance")
                        .HasColumnType("integer")
                        .HasColumnName("distance");

                    b.Property<int>("RaceEditionId")
                        .HasColumnType("integer")
                        .HasColumnName("race_edition_id");

                    b.Property<short>("StageNumber")
                        .HasColumnType("Int2")
                        .HasColumnName("stage_number");

                    b.Property<string>("StageType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("stage_type");

                    b.HasKey("Id")
                        .HasName("pk_stages");

                    b.HasIndex("RaceEditionId")
                        .HasDatabaseName("ix_stages_race_edition_id");

                    b.ToTable("stages", (string)null);
                });

            modelBuilder.Entity("App.EntityModels.StageRiderResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<short>("BonusPointObtained")
                        .HasColumnType("Int2")
                        .HasColumnName("bonus_point_obtained");

                    b.Property<short>("ClimbingPointObtained")
                        .HasColumnType("Int2")
                        .HasColumnName("climbing_point_obtained");

                    b.Property<int>("FinishTime")
                        .HasColumnType("integer")
                        .HasColumnName("finish_time");

                    b.Property<short>("Placement")
                        .HasColumnType("Int2")
                        .HasColumnName("placement");

                    b.Property<int>("RiderId")
                        .HasColumnType("integer")
                        .HasColumnName("rider_id");

                    b.Property<short>("SprintPointObtained")
                        .HasColumnType("Int2")
                        .HasColumnName("sprint_point_obtained");

                    b.Property<int>("StageFinishStatusId")
                        .HasColumnType("integer")
                        .HasColumnName("stage_finish_status_id");

                    b.Property<int>("StageId")
                        .HasColumnType("integer")
                        .HasColumnName("stage_id");

                    b.Property<short>("TimePenalty")
                        .HasColumnType("Int2")
                        .HasColumnName("time_penalty");

                    b.HasKey("Id")
                        .HasName("pk_stage_rider_results");

                    b.HasIndex("RiderId")
                        .HasDatabaseName("ix_stage_rider_results_rider_id");

                    b.HasIndex("StageFinishStatusId")
                        .HasDatabaseName("ix_stage_rider_results_stage_finish_status_id");

                    b.HasIndex("StageId")
                        .HasDatabaseName("ix_stage_rider_results_stage_id");

                    b.ToTable("stage_rider_results", (string)null);
                });

            modelBuilder.Entity("App.EntityModels.StageTeamResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FinishTime")
                        .HasColumnType("integer")
                        .HasColumnName("finish_time");

                    b.Property<short>("Placement")
                        .HasColumnType("Int2")
                        .HasColumnName("placement");

                    b.Property<int>("StageId")
                        .HasColumnType("integer")
                        .HasColumnName("stage_id");

                    b.Property<int>("TeamId")
                        .HasColumnType("integer")
                        .HasColumnName("team_id");

                    b.Property<short>("TimePenalty")
                        .HasColumnType("Int2")
                        .HasColumnName("time_penalty");

                    b.HasKey("Id")
                        .HasName("pk_stage_team_results");

                    b.HasIndex("StageId")
                        .HasDatabaseName("ix_stage_team_results_stage_id");

                    b.HasIndex("TeamId")
                        .HasDatabaseName("ix_stage_team_results_team_id");

                    b.ToTable("stage_team_results", (string)null);
                });

            modelBuilder.Entity("App.EntityModels.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MetaTeamId")
                        .HasColumnType("integer")
                        .HasColumnName("meta_team_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<short>("Year")
                        .HasColumnType("Int2")
                        .HasColumnName("year");

                    b.HasKey("Id")
                        .HasName("pk_teams");

                    b.HasIndex("MetaTeamId")
                        .HasDatabaseName("ix_teams_meta_team_id");

                    b.ToTable("teams", (string)null);
                });

            modelBuilder.Entity("app.EntityModels.OldRaceName", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("key");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Key"));

                    b.Property<int>("RaceId")
                        .HasColumnType("integer")
                        .HasColumnName("race_id");

                    b.HasKey("Key")
                        .HasName("pk_old_race_name");

                    b.HasIndex("RaceId")
                        .HasDatabaseName("ix_old_race_name_race_id");

                    b.ToTable("old_race_name", (string)null);
                });

            modelBuilder.Entity("app.EntityModels.StageFinishStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_stage_finish_statuses");

                    b.ToTable("stage_finish_statuses", (string)null);
                });

            modelBuilder.Entity("App.EntityModels.Race", b =>
                {
                    b.HasOne("App.EntityModels.Nation", "Nation")
                        .WithMany()
                        .HasForeignKey("NationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_races_nations_nation_id");

                    b.Navigation("Nation");
                });

            modelBuilder.Entity("App.EntityModels.RaceEdition", b =>
                {
                    b.HasOne("App.EntityModels.Race", "Race")
                        .WithMany("RaceEditions")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_race_editions_races_race_id");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("App.EntityModels.Rider", b =>
                {
                    b.HasOne("App.EntityModels.Nation", "Nation")
                        .WithMany()
                        .HasForeignKey("NationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_riders_nations_nation_id");

                    b.Navigation("Nation");
                });

            modelBuilder.Entity("App.EntityModels.RiderTeam", b =>
                {
                    b.HasOne("App.EntityModels.Rider", "Rider")
                        .WithMany("RiderTeam")
                        .HasForeignKey("RiderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_rider_teams_riders_rider_id");

                    b.HasOne("App.EntityModels.Team", "Team")
                        .WithMany("RiderTeam")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_rider_teams_teams_team_id");

                    b.Navigation("Rider");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("App.EntityModels.Stage", b =>
                {
                    b.HasOne("App.EntityModels.RaceEdition", "RaceEdition")
                        .WithMany()
                        .HasForeignKey("RaceEditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_stages_race_editions_race_edition_id");

                    b.Navigation("RaceEdition");
                });

            modelBuilder.Entity("App.EntityModels.StageRiderResult", b =>
                {
                    b.HasOne("App.EntityModels.Rider", "Rider")
                        .WithMany()
                        .HasForeignKey("RiderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_stage_rider_results_riders_rider_id");

                    b.HasOne("app.EntityModels.StageFinishStatus", "StageFinishStatus")
                        .WithMany()
                        .HasForeignKey("StageFinishStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_stage_rider_results_stage_finish_statuses_stage_finish_stat");

                    b.HasOne("App.EntityModels.Stage", "Stage")
                        .WithMany()
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_stage_rider_results_stages_stage_id");

                    b.Navigation("Rider");

                    b.Navigation("Stage");

                    b.Navigation("StageFinishStatus");
                });

            modelBuilder.Entity("App.EntityModels.StageTeamResult", b =>
                {
                    b.HasOne("App.EntityModels.Stage", "Stage")
                        .WithMany()
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_stage_team_results_stages_stage_id");

                    b.HasOne("App.EntityModels.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_stage_team_results_teams_team_id");

                    b.Navigation("Stage");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("App.EntityModels.Team", b =>
                {
                    b.HasOne("App.EntityModels.MetaTeam", "MetaTeam")
                        .WithMany("Teams")
                        .HasForeignKey("MetaTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_teams_meta_teams_meta_team_id");

                    b.Navigation("MetaTeam");
                });

            modelBuilder.Entity("app.EntityModels.OldRaceName", b =>
                {
                    b.HasOne("App.EntityModels.Race", "Race")
                        .WithMany("OldRaceNames")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_old_race_name_races_race_id");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("App.EntityModels.MetaTeam", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("App.EntityModels.Race", b =>
                {
                    b.Navigation("OldRaceNames");

                    b.Navigation("RaceEditions");
                });

            modelBuilder.Entity("App.EntityModels.Rider", b =>
                {
                    b.Navigation("RiderTeam");
                });

            modelBuilder.Entity("App.EntityModels.Team", b =>
                {
                    b.Navigation("RiderTeam");
                });
#pragma warning restore 612, 618
        }
    }
}
