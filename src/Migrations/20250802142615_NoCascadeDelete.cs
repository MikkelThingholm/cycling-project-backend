using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cycling_project_web_api.Migrations
{
    /// <inheritdoc />
    public partial class NoCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_mountain_climb_results_mountain_climbs_mountain_climb_id",
                table: "mountain_climb_results");

            migrationBuilder.DropForeignKey(
                name: "fk_mountain_climbs_mountains_mountain_id",
                table: "mountain_climbs");

            migrationBuilder.DropForeignKey(
                name: "fk_mountain_climbs_stages_stage_id",
                table: "mountain_climbs");

            migrationBuilder.DropForeignKey(
                name: "fk_race_editions_races_race_id",
                table: "race_editions");

            migrationBuilder.DropForeignKey(
                name: "fk_race_rider_participations_race_team_participations_race_tea",
                table: "race_rider_participations");

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
                name: "fk_riders_nations_nation_id",
                table: "riders");

            migrationBuilder.DropForeignKey(
                name: "fk_riders_teams_riders_rider_id",
                table: "riders_teams");

            migrationBuilder.DropForeignKey(
                name: "fk_riders_teams_teams_team_id",
                table: "riders_teams");

            migrationBuilder.DropForeignKey(
                name: "fk_sprint_results_race_rider_participations_race_rider_partici",
                table: "sprint_results");

            migrationBuilder.DropForeignKey(
                name: "fk_sprint_results_sprints_sprint_id",
                table: "sprint_results");

            migrationBuilder.DropForeignKey(
                name: "fk_sprints_stages_stage_id",
                table: "sprints");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_combativity_awards_race_rider_participations_race_rid",
                table: "stage_combativity_awards");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_combativity_awards_stages_stage_id",
                table: "stage_combativity_awards");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_non_finishes_race_rider_participations_race_rider_par",
                table: "stage_non_finishes");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_non_finishes_stages_stage_id",
                table: "stage_non_finishes");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_rider_results_race_rider_participations_race_rider_pa",
                table: "stage_rider_results");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_rider_results_stages_stage_id",
                table: "stage_rider_results");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_rider_standings_race_rider_participations_race_rider_",
                table: "stage_rider_standings");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_rider_standings_stages_stage_id",
                table: "stage_rider_standings");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_team_results_race_team_participations_race_team_parti",
                table: "stage_team_results");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_team_results_stages_stage_id",
                table: "stage_team_results");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_team_standings_race_team_participations_race_team_par",
                table: "stage_team_standings");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_team_standings_stages_stage_id",
                table: "stage_team_standings");

            migrationBuilder.DropForeignKey(
                name: "fk_stages_race_editions_race_edition_id",
                table: "stages");

            migrationBuilder.DropForeignKey(
                name: "fk_teams_team_organizations_team_organization_id",
                table: "teams");

            migrationBuilder.AddForeignKey(
                name: "fk_mountain_climb_results_mountain_climbs_mountain_climb_id",
                table: "mountain_climb_results",
                column: "mountain_climb_id",
                principalTable: "mountain_climbs",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_mountain_climbs_mountains_mountain_id",
                table: "mountain_climbs",
                column: "mountain_id",
                principalTable: "mountains",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_mountain_climbs_stages_stage_id",
                table: "mountain_climbs",
                column: "stage_id",
                principalTable: "stages",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_race_editions_races_race_id",
                table: "race_editions",
                column: "race_id",
                principalTable: "races",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_race_rider_participations_race_team_participations_race_tea",
                table: "race_rider_participations",
                column: "race_team_participation_id",
                principalTable: "race_team_participations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_race_rider_participations_riders_rider_id",
                table: "race_rider_participations",
                column: "rider_id",
                principalTable: "riders",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_race_team_participations_race_editions_race_edition_id",
                table: "race_team_participations",
                column: "race_edition_id",
                principalTable: "race_editions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_race_team_participations_teams_team_id",
                table: "race_team_participations",
                column: "team_id",
                principalTable: "teams",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_races_nations_nation_id",
                table: "races",
                column: "nation_id",
                principalTable: "nations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_riders_nations_nation_id",
                table: "riders",
                column: "nation_id",
                principalTable: "nations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_riders_teams_riders_rider_id",
                table: "riders_teams",
                column: "rider_id",
                principalTable: "riders",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_riders_teams_teams_team_id",
                table: "riders_teams",
                column: "team_id",
                principalTable: "teams",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_sprint_results_race_rider_participations_race_rider_partici",
                table: "sprint_results",
                column: "race_rider_participation_id",
                principalTable: "race_rider_participations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_sprint_results_sprints_sprint_id",
                table: "sprint_results",
                column: "sprint_id",
                principalTable: "sprints",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_sprints_stages_stage_id",
                table: "sprints",
                column: "stage_id",
                principalTable: "stages",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_combativity_awards_race_rider_participations_race_rid",
                table: "stage_combativity_awards",
                column: "race_rider_participation_id",
                principalTable: "race_rider_participations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_combativity_awards_stages_stage_id",
                table: "stage_combativity_awards",
                column: "stage_id",
                principalTable: "stages",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_non_finishes_race_rider_participations_race_rider_par",
                table: "stage_non_finishes",
                column: "race_rider_participation_id",
                principalTable: "race_rider_participations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_non_finishes_stages_stage_id",
                table: "stage_non_finishes",
                column: "stage_id",
                principalTable: "stages",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_rider_results_race_rider_participations_race_rider_pa",
                table: "stage_rider_results",
                column: "race_rider_participation_id",
                principalTable: "race_rider_participations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_rider_results_stages_stage_id",
                table: "stage_rider_results",
                column: "stage_id",
                principalTable: "stages",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_rider_standings_race_rider_participations_race_rider_",
                table: "stage_rider_standings",
                column: "race_rider_participation_id",
                principalTable: "race_rider_participations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_rider_standings_stages_stage_id",
                table: "stage_rider_standings",
                column: "stage_id",
                principalTable: "stages",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_team_results_race_team_participations_race_team_parti",
                table: "stage_team_results",
                column: "race_team_participation_id",
                principalTable: "race_team_participations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_team_results_stages_stage_id",
                table: "stage_team_results",
                column: "stage_id",
                principalTable: "stages",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_team_standings_race_team_participations_race_team_par",
                table: "stage_team_standings",
                column: "race_team_participation_id",
                principalTable: "race_team_participations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_team_standings_stages_stage_id",
                table: "stage_team_standings",
                column: "stage_id",
                principalTable: "stages",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_stages_race_editions_race_edition_id",
                table: "stages",
                column: "race_edition_id",
                principalTable: "race_editions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_teams_team_organizations_team_organization_id",
                table: "teams",
                column: "team_organization_id",
                principalTable: "team_organizations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_mountain_climb_results_mountain_climbs_mountain_climb_id",
                table: "mountain_climb_results");

            migrationBuilder.DropForeignKey(
                name: "fk_mountain_climbs_mountains_mountain_id",
                table: "mountain_climbs");

            migrationBuilder.DropForeignKey(
                name: "fk_mountain_climbs_stages_stage_id",
                table: "mountain_climbs");

            migrationBuilder.DropForeignKey(
                name: "fk_race_editions_races_race_id",
                table: "race_editions");

            migrationBuilder.DropForeignKey(
                name: "fk_race_rider_participations_race_team_participations_race_tea",
                table: "race_rider_participations");

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
                name: "fk_riders_nations_nation_id",
                table: "riders");

            migrationBuilder.DropForeignKey(
                name: "fk_riders_teams_riders_rider_id",
                table: "riders_teams");

            migrationBuilder.DropForeignKey(
                name: "fk_riders_teams_teams_team_id",
                table: "riders_teams");

            migrationBuilder.DropForeignKey(
                name: "fk_sprint_results_race_rider_participations_race_rider_partici",
                table: "sprint_results");

            migrationBuilder.DropForeignKey(
                name: "fk_sprint_results_sprints_sprint_id",
                table: "sprint_results");

            migrationBuilder.DropForeignKey(
                name: "fk_sprints_stages_stage_id",
                table: "sprints");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_combativity_awards_race_rider_participations_race_rid",
                table: "stage_combativity_awards");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_combativity_awards_stages_stage_id",
                table: "stage_combativity_awards");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_non_finishes_race_rider_participations_race_rider_par",
                table: "stage_non_finishes");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_non_finishes_stages_stage_id",
                table: "stage_non_finishes");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_rider_results_race_rider_participations_race_rider_pa",
                table: "stage_rider_results");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_rider_results_stages_stage_id",
                table: "stage_rider_results");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_rider_standings_race_rider_participations_race_rider_",
                table: "stage_rider_standings");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_rider_standings_stages_stage_id",
                table: "stage_rider_standings");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_team_results_race_team_participations_race_team_parti",
                table: "stage_team_results");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_team_results_stages_stage_id",
                table: "stage_team_results");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_team_standings_race_team_participations_race_team_par",
                table: "stage_team_standings");

            migrationBuilder.DropForeignKey(
                name: "fk_stage_team_standings_stages_stage_id",
                table: "stage_team_standings");

            migrationBuilder.DropForeignKey(
                name: "fk_stages_race_editions_race_edition_id",
                table: "stages");

            migrationBuilder.DropForeignKey(
                name: "fk_teams_team_organizations_team_organization_id",
                table: "teams");

            migrationBuilder.AddForeignKey(
                name: "fk_mountain_climb_results_mountain_climbs_mountain_climb_id",
                table: "mountain_climb_results",
                column: "mountain_climb_id",
                principalTable: "mountain_climbs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_mountain_climbs_mountains_mountain_id",
                table: "mountain_climbs",
                column: "mountain_id",
                principalTable: "mountains",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_mountain_climbs_stages_stage_id",
                table: "mountain_climbs",
                column: "stage_id",
                principalTable: "stages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_race_editions_races_race_id",
                table: "race_editions",
                column: "race_id",
                principalTable: "races",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_race_rider_participations_race_team_participations_race_tea",
                table: "race_rider_participations",
                column: "race_team_participation_id",
                principalTable: "race_team_participations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
                name: "fk_riders_nations_nation_id",
                table: "riders",
                column: "nation_id",
                principalTable: "nations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_riders_teams_riders_rider_id",
                table: "riders_teams",
                column: "rider_id",
                principalTable: "riders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_riders_teams_teams_team_id",
                table: "riders_teams",
                column: "team_id",
                principalTable: "teams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sprint_results_race_rider_participations_race_rider_partici",
                table: "sprint_results",
                column: "race_rider_participation_id",
                principalTable: "race_rider_participations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sprint_results_sprints_sprint_id",
                table: "sprint_results",
                column: "sprint_id",
                principalTable: "sprints",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sprints_stages_stage_id",
                table: "sprints",
                column: "stage_id",
                principalTable: "stages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_combativity_awards_race_rider_participations_race_rid",
                table: "stage_combativity_awards",
                column: "race_rider_participation_id",
                principalTable: "race_rider_participations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_combativity_awards_stages_stage_id",
                table: "stage_combativity_awards",
                column: "stage_id",
                principalTable: "stages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_non_finishes_race_rider_participations_race_rider_par",
                table: "stage_non_finishes",
                column: "race_rider_participation_id",
                principalTable: "race_rider_participations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_non_finishes_stages_stage_id",
                table: "stage_non_finishes",
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
                name: "fk_stage_rider_results_stages_stage_id",
                table: "stage_rider_results",
                column: "stage_id",
                principalTable: "stages",
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
                name: "fk_stage_rider_standings_stages_stage_id",
                table: "stage_rider_standings",
                column: "stage_id",
                principalTable: "stages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_team_results_race_team_participations_race_team_parti",
                table: "stage_team_results",
                column: "race_team_participation_id",
                principalTable: "race_team_participations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_stage_team_results_stages_stage_id",
                table: "stage_team_results",
                column: "stage_id",
                principalTable: "stages",
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
                name: "fk_stage_team_standings_stages_stage_id",
                table: "stage_team_standings",
                column: "stage_id",
                principalTable: "stages",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_stages_race_editions_race_edition_id",
                table: "stages",
                column: "race_edition_id",
                principalTable: "race_editions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_teams_team_organizations_team_organization_id",
                table: "teams",
                column: "team_organization_id",
                principalTable: "team_organizations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
