using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cycling_project_web_api.Migrations
{
    /// <inheritdoc />
    public partial class FixedForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "ak_stage_combative_awards_stage_id",
                table: "stage_combative_awards");

            migrationBuilder.DropColumn(
                name: "stage_type",
                table: "stages");

            migrationBuilder.AddColumn<int>(
                name: "stage_type_id",
                table: "stages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_stages_stage_type_id",
                table: "stages",
                column: "stage_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_stage_team_standings_race_team_participation_id",
                table: "stage_team_standings",
                column: "race_team_participation_id");

            migrationBuilder.CreateIndex(
                name: "ix_stage_rider_standings_race_rider_participation_id",
                table: "stage_rider_standings",
                column: "race_rider_participation_id");

            migrationBuilder.CreateIndex(
                name: "ix_stage_rider_results_race_rider_participation_id",
                table: "stage_rider_results",
                column: "race_rider_participation_id");

            migrationBuilder.CreateIndex(
                name: "ix_stage_did_not_starts_race_rider_participation_id",
                table: "stage_did_not_starts",
                column: "race_rider_participation_id");

            migrationBuilder.CreateIndex(
                name: "ix_stage_combative_awards_race_rider_participation_id",
                table: "stage_combative_awards",
                column: "race_rider_participation_id");

            migrationBuilder.CreateIndex(
                name: "ix_stage_combative_awards_stage_id",
                table: "stage_combative_awards",
                column: "stage_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_races_nation_id",
                table: "races",
                column: "nation_id");

            migrationBuilder.CreateIndex(
                name: "ix_race_team_participations_team_id",
                table: "race_team_participations",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "ix_race_rider_participations_rider_id",
                table: "race_rider_participations",
                column: "rider_id");

            migrationBuilder.AddForeignKey(
                name: "fk_race_rider_participations_riders_rider_id",
                table: "race_rider_participations",
                column: "rider_id",
                principalTable: "riders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_race_team_participations_race_editions_race_edition_id",
                table: "race_team_participations",
                column: "race_edition_id",
                principalTable: "race_editions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_race_team_participations_teams_team_id",
                table: "race_team_participations",
                column: "team_id",
                principalTable: "teams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_races_nations_nation_id",
                table: "races",
                column: "nation_id",
                principalTable: "nations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_combative_awards_race_rider_participations_race_rider",
                table: "stage_combative_awards",
                column: "race_rider_participation_id",
                principalTable: "race_rider_participations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_combative_awards_stages_stage_id",
                table: "stage_combative_awards",
                column: "stage_id",
                principalTable: "stages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_did_not_starts_race_rider_participations_race_rider_p",
                table: "stage_did_not_starts",
                column: "race_rider_participation_id",
                principalTable: "race_rider_participations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_did_not_starts_stages_stage_id",
                table: "stage_did_not_starts",
                column: "stage_id",
                principalTable: "stages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_rider_results_race_rider_participations_race_rider_pa",
                table: "stage_rider_results",
                column: "race_rider_participation_id",
                principalTable: "race_rider_participations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_rider_standings_race_rider_participations_race_rider_",
                table: "stage_rider_standings",
                column: "race_rider_participation_id",
                principalTable: "race_rider_participations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_team_standings_race_team_participations_race_team_par",
                table: "stage_team_standings",
                column: "race_team_participation_id",
                principalTable: "race_team_participations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_stages_stage_types_stage_type_id",
                table: "stages",
                column: "stage_type_id",
                principalTable: "stage_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_race_rider_participations_riders_rider_id",
                table: "race_rider_participations");

            migrationBuilder.DropForeignKey(
                name: "fk_race_team_participations_race_editions_race_edition_id",
                table: "race_team_participations");

            migrationBuilder.DropForeignKey(
                name: "fk_race_team_participations_teams_team_id",
                table: "race_team_participations");

            migrationBuilder.DropForeignKey(
                name: "fk_races_nations_nation_id",
                table: "races");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_combative_awards_race_rider_participations_race_rider",
                table: "stage_combative_awards");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_combative_awards_stages_stage_id",
                table: "stage_combative_awards");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_did_not_starts_race_rider_participations_race_rider_p",
                table: "stage_did_not_starts");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_did_not_starts_stages_stage_id",
                table: "stage_did_not_starts");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_rider_results_race_rider_participations_race_rider_pa",
                table: "stage_rider_results");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_rider_standings_race_rider_participations_race_rider_",
                table: "stage_rider_standings");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_team_standings_race_team_participations_race_team_par",
                table: "stage_team_standings");

            migrationBuilder.DropForeignKey(
                name: "fk_stages_stage_types_stage_type_id",
                table: "stages");

            migrationBuilder.DropIndex(
                name: "ix_stages_stage_type_id",
                table: "stages");

            migrationBuilder.DropIndex(
                name: "ix_stage_team_standings_race_team_participation_id",
                table: "stage_team_standings");

            migrationBuilder.DropIndex(
                name: "ix_stage_rider_standings_race_rider_participation_id",
                table: "stage_rider_standings");

            migrationBuilder.DropIndex(
                name: "ix_stage_rider_results_race_rider_participation_id",
                table: "stage_rider_results");

            migrationBuilder.DropIndex(
                name: "ix_stage_did_not_starts_race_rider_participation_id",
                table: "stage_did_not_starts");

            migrationBuilder.DropIndex(
                name: "ix_stage_combative_awards_race_rider_participation_id",
                table: "stage_combative_awards");

            migrationBuilder.DropIndex(
                name: "ix_stage_combative_awards_stage_id",
                table: "stage_combative_awards");

            migrationBuilder.DropIndex(
                name: "ix_races_nation_id",
                table: "races");

            migrationBuilder.DropIndex(
                name: "ix_race_team_participations_team_id",
                table: "race_team_participations");

            migrationBuilder.DropIndex(
                name: "ix_race_rider_participations_rider_id",
                table: "race_rider_participations");

            migrationBuilder.DropColumn(
                name: "stage_type_id",
                table: "stages");

            migrationBuilder.AddColumn<string>(
                name: "stage_type",
                table: "stages",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "ak_stage_combative_awards_stage_id",
                table: "stage_combative_awards",
                column: "stage_id");
        }
    }
}
