using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AttendanceApi.Migrations
{
    public partial class CompleteSchemaV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LectureId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Students_Regno",
                table: "Students",
                column: "Regno");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassIdentifier = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseCode = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CourseName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CreditHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseCode);
                });

            migrationBuilder.CreateTable(
                name: "FeatureSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "varchar(max)", nullable: false),
                    Pose = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    StudentId = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeatureSet_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Regno",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LectureSlot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<string>(type: "varchar", nullable: false),
                    EndTime = table.Column<string>(type: "varchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureSlot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teaches",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CourseCode = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    Session = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teaches", x => new { x.ClassId, x.TeacherId, x.CourseCode, x.Session });
                    table.ForeignKey(
                        name: "FK_Teaches_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teaches_Course_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "Course",
                        principalColumn: "CourseCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teaches_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lecture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Session = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeldOnDate = table.Column<string>(type: "varchar", nullable: false),
                    LectureSlotId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CourseCode = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lecture_Course_CourseCode",
                        column: x => x.CourseCode,
                        principalTable: "Course",
                        principalColumn: "CourseCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lecture_LectureSlot_LectureSlotId",
                        column: x => x.LectureSlotId,
                        principalTable: "LectureSlot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lecture_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "varchar(200)", nullable: false),
                    LectureId = table.Column<int>(type: "int", nullable: false),
                    AttendanceNo = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttendanceTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => new { x.LectureId, x.StudentId, x.AttendanceNo });
                    table.ForeignKey(
                        name: "FK_Attendance_Lecture_LectureId",
                        column: x => x.LectureId,
                        principalTable: "Lecture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendance_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Regno",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassLecturePhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LectureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassLecturePhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassLecturePhotos_Lecture_LectureId",
                        column: x => x.LectureId,
                        principalTable: "Lecture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_LectureId",
                table: "Students",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ParentId",
                table: "Students",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_StudentId",
                table: "Attendance",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassLecturePhotos_LectureId",
                table: "ClassLecturePhotos",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureSet_StudentId",
                table: "FeatureSet",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecture_CourseCode_TeacherId_LectureSlotId",
                table: "Lecture",
                columns: new[] { "CourseCode", "TeacherId", "LectureSlotId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lecture_LectureSlotId",
                table: "Lecture",
                column: "LectureSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecture_TeacherId",
                table: "Lecture",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Teaches_CourseCode",
                table: "Teaches",
                column: "CourseCode");

            migrationBuilder.CreateIndex(
                name: "IX_Teaches_TeacherId",
                table: "Teaches",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Class_ClassId",
                table: "Students",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Lecture_LectureId",
                table: "Students",
                column: "LectureId",
                principalTable: "Lecture",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Parents_ParentId",
                table: "Students",
                column: "ParentId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Class_ClassId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Lecture_LectureId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Parents_ParentId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "ClassLecturePhotos");

            migrationBuilder.DropTable(
                name: "FeatureSet");

            migrationBuilder.DropTable(
                name: "Teaches");

            migrationBuilder.DropTable(
                name: "Lecture");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "LectureSlot");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Students_Regno",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ClassId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_LectureId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ParentId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LectureId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Students");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Regno");
        }
    }
}
