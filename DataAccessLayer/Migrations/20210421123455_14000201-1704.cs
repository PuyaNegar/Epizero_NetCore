using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _140002011704 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DifficultyLevelTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifficultyLevelTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErrorLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OccureDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ErrorSource = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LevelGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    TitleEN = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeekDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NameEN = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekDays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LevelGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Levels_LevelGroups_LevelGroupId",
                        column: x => x.LevelGroupId,
                        principalTable: "LevelGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    PasswoerdHash = table.Column<string>(type: "varchar(max)", nullable: false),
                    PersonalPicPath = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    IsConfirm = table.Column<bool>(type: "bit", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    UserGroupId = table.Column<int>(nullable: false),
                    PresentersId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserGroups_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CouponCode = table.Column<string>(type: "varchar(30)", nullable: false),
                    FromDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ToDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DiscountPercent = table.Column<int>(type: "int", nullable: false),
                    MinSubTotal = table.Column<int>(type: "int", nullable: false),
                    MaxDiscount = table.Column<int>(type: "int", nullable: true),
                    IsGlobal = table.Column<bool>(type: "bit", nullable: false),
                    IsForFirstOrder = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(2000)", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegUserId = table.Column<int>(type: "int", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coupons_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Coupons_Users_RegUserId",
                        column: x => x.RegUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    UnitCount = table.Column<int>(type: "int", nullable: false),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    FieldId = table.Column<int>(type: "int", nullable: true),
                    LessonTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lessons_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lessons_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OnlineExams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    AllowedTimeToEnter = table.Column<int>(type: "int", nullable: true),
                    IsRandomQuestions = table.Column<bool>(type: "bit", nullable: false),
                    IsRandomOption = table.Column<bool>(type: "bit", nullable: false),
                    HasNegativePoint = table.Column<bool>(type: "bit", nullable: false),
                    MaxGrade = table.Column<int>(type: "int", nullable: false),
                    TeacherUserId = table.Column<int>(nullable: false),
                    QuestionTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineExams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineExams_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnlineExams_QuestionTypes_QuestionTypeId",
                        column: x => x.QuestionTypeId,
                        principalTable: "QuestionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnlineExams_Users_TeacherUserId",
                        column: x => x.TeacherUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Alt = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PicPath = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Inx = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sliders_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FatherName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    BirthDay = table.Column<DateTime>(type: "date", nullable: true),
                    BirthPlace = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PassPortNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    HighSchoolName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    OldSystemAverage = table.Column<double>(type: "float", nullable: true),
                    NewSystemAverage = table.Column<double>(type: "float", nullable: true),
                    HighSchoolGraduationDate = table.Column<DateTime>(type: "date", nullable: true),
                    HighSchoolStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    TurkeyAddress = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    RegisterFormPath = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    RegisterFormUploadDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    StudentNo = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LessonTopics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Inx = table.Column<int>(nullable: false),
                    LessonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonTopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonTopics_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LessonTopics_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OnlineExamQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    QuestionContext = table.Column<string>(nullable: true),
                    ResponseTime = table.Column<int>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    Inx = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<int>(nullable: false),
                    OnlineExamId = table.Column<int>(nullable: false),
                    QuestionTypeId = table.Column<int>(nullable: false),
                    DifficultyLevelTypeId = table.Column<int>(nullable: false),
                    QuestionMakerUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineExamQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineExamQuestions_DifficultyLevelTypes_DifficultyLevelTypeId",
                        column: x => x.DifficultyLevelTypeId,
                        principalTable: "DifficultyLevelTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnlineExamQuestions_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnlineExamQuestions_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnlineExamQuestions_OnlineExams_OnlineExamId",
                        column: x => x.OnlineExamId,
                        principalTable: "OnlineExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnlineExamQuestions_Users_QuestionMakerUserId",
                        column: x => x.QuestionMakerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnlineExamQuestions_QuestionTypes_QuestionTypeId",
                        column: x => x.QuestionTypeId,
                        principalTable: "QuestionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OnlineExamStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    IsFinalized = table.Column<bool>(type: "bit", nullable: false),
                    EnterDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    OnlineExamId = table.Column<int>(type: "int", nullable: false),
                    StudentUserId = table.Column<int>(type: "int", nullable: false),
                    FinalizedDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineExamStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineExamStudents_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnlineExamStudents_OnlineExams_OnlineExamId",
                        column: x => x.OnlineExamId,
                        principalTable: "OnlineExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnlineExamStudents_Users_StudentUserId",
                        column: x => x.StudentUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    QuestionContext = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionContext_Html = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponseTime = table.Column<int>(type: "int", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(2000)", nullable: true),
                    QuestionTypeId = table.Column<int>(nullable: false),
                    DifficultyLevelTypeId = table.Column<int>(nullable: false),
                    QuestionMakerUserId = table.Column<int>(nullable: false),
                    LessonTopicId = table.Column<int>(type: "int", nullable: true),
                    LessonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_DifficultyLevelTypes_DifficultyLevelTypeId",
                        column: x => x.DifficultyLevelTypeId,
                        principalTable: "DifficultyLevelTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questions_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questions_LessonTopics_LessonTopicId",
                        column: x => x.LessonTopicId,
                        principalTable: "LessonTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questions_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questions_Users_QuestionMakerUserId",
                        column: x => x.QuestionMakerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questions_QuestionTypes_QuestionTypeId",
                        column: x => x.QuestionTypeId,
                        principalTable: "QuestionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OnlineExamDescriptiveQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    QuestionAnswerContext = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnlineExamQuestionsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineExamDescriptiveQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineExamDescriptiveQuestions_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnlineExamDescriptiveQuestions_OnlineExamQuestions_OnlineExamQuestionsId",
                        column: x => x.OnlineExamQuestionsId,
                        principalTable: "OnlineExamQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OnlineExamMultipleChoiceQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Option1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrectOption = table.Column<int>(type: "int", nullable: false),
                    OnlineExamQuestionsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineExamMultipleChoiceQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineExamMultipleChoiceQuestions_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnlineExamMultipleChoiceQuestions_OnlineExamQuestions_OnlineExamQuestionsId",
                        column: x => x.OnlineExamQuestionsId,
                        principalTable: "OnlineExamQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OnlineExamStudentAnswerFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    OnlineExamStudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineExamStudentAnswerFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineExamStudentAnswerFiles_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnlineExamStudentAnswerFiles_OnlineExamStudents_OnlineExamStudentId",
                        column: x => x.OnlineExamStudentId,
                        principalTable: "OnlineExamStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OnlineExamStudentAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    OnlineExamStudentId = table.Column<int>(nullable: false),
                    OnlineExamQuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineExamStudentAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineExamStudentAnswers_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnlineExamStudentAnswers_OnlineExamQuestions_OnlineExamQuestionId",
                        column: x => x.OnlineExamQuestionId,
                        principalTable: "OnlineExamQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnlineExamStudentAnswers_OnlineExamStudents_OnlineExamStudentId",
                        column: x => x.OnlineExamStudentId,
                        principalTable: "OnlineExamStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentOnlineExamResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unanswered = table.Column<int>(type: "int", nullable: false),
                    CorrectAnswered = table.Column<int>(type: "int", nullable: false),
                    IncorrectAnswered = table.Column<int>(type: "int", nullable: false),
                    RawScore = table.Column<double>(type: "float", nullable: false),
                    MaxScore = table.Column<double>(type: "float", nullable: false),
                    MinScore = table.Column<double>(type: "float", nullable: false),
                    LessonRank = table.Column<int>(type: "int", nullable: false),
                    ParticipantsCount = table.Column<int>(type: "int", nullable: false),
                    AvrageScore = table.Column<double>(type: "float", nullable: false),
                    TotalRank = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<int>(nullable: false),
                    OnlineExamStudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentOnlineExamResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentOnlineExamResults_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentOnlineExamResults_OnlineExamStudents_OnlineExamStudentId",
                        column: x => x.OnlineExamStudentId,
                        principalTable: "OnlineExamStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DescriptiveQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    QuestionAnswerContext = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionAnswerContext_Html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptiveQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DescriptiveQuestions_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DescriptiveQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MultipleChoiceQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    Option1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option1_Html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option2_Html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option3_Html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option4_Html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Option5_Html = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrectOption = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceQuestions_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DescrptiveQuestionAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    AnswerContext = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnlineExamStudentAnswerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescrptiveQuestionAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DescrptiveQuestionAnswers_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DescrptiveQuestionAnswers_OnlineExamStudentAnswers_OnlineExamStudentAnswerId",
                        column: x => x.OnlineExamStudentAnswerId,
                        principalTable: "OnlineExamStudentAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MultipleChoiceQuestionAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RegDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModUserId = table.Column<int>(type: "int", nullable: false),
                    SelectedOption = table.Column<int>(type: "int", nullable: false),
                    OnlineExamStudentAnswerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceQuestionAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceQuestionAnswers_Users_ModUserId",
                        column: x => x.ModUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceQuestionAnswers_OnlineExamStudentAnswers_OnlineExamStudentAnswerId",
                        column: x => x.OnlineExamStudentAnswerId,
                        principalTable: "OnlineExamStudentAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_ModUserId",
                table: "Coupons",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_RegUserId",
                table: "Coupons",
                column: "RegUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptiveQuestions_ModUserId",
                table: "DescriptiveQuestions",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptiveQuestions_QuestionId",
                table: "DescriptiveQuestions",
                column: "QuestionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DescrptiveQuestionAnswers_ModUserId",
                table: "DescrptiveQuestionAnswers",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DescrptiveQuestionAnswers_OnlineExamStudentAnswerId",
                table: "DescrptiveQuestionAnswers",
                column: "OnlineExamStudentAnswerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_FieldId",
                table: "Lessons",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_LevelId",
                table: "Lessons",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ModUserId",
                table: "Lessons",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonTopics_LessonId",
                table: "LessonTopics",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonTopics_ModUserId",
                table: "LessonTopics",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Levels_LevelGroupId",
                table: "Levels",
                column: "LevelGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceQuestionAnswers_ModUserId",
                table: "MultipleChoiceQuestionAnswers",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceQuestionAnswers_OnlineExamStudentAnswerId",
                table: "MultipleChoiceQuestionAnswers",
                column: "OnlineExamStudentAnswerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceQuestions_ModUserId",
                table: "MultipleChoiceQuestions",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceQuestions_QuestionId",
                table: "MultipleChoiceQuestions",
                column: "QuestionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamDescriptiveQuestions_ModUserId",
                table: "OnlineExamDescriptiveQuestions",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamDescriptiveQuestions_OnlineExamQuestionsId",
                table: "OnlineExamDescriptiveQuestions",
                column: "OnlineExamQuestionsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamMultipleChoiceQuestions_ModUserId",
                table: "OnlineExamMultipleChoiceQuestions",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamMultipleChoiceQuestions_OnlineExamQuestionsId",
                table: "OnlineExamMultipleChoiceQuestions",
                column: "OnlineExamQuestionsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamQuestions_DifficultyLevelTypeId",
                table: "OnlineExamQuestions",
                column: "DifficultyLevelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamQuestions_LessonId",
                table: "OnlineExamQuestions",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamQuestions_ModUserId",
                table: "OnlineExamQuestions",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamQuestions_OnlineExamId",
                table: "OnlineExamQuestions",
                column: "OnlineExamId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamQuestions_QuestionMakerUserId",
                table: "OnlineExamQuestions",
                column: "QuestionMakerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamQuestions_QuestionTypeId",
                table: "OnlineExamQuestions",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExams_ModUserId",
                table: "OnlineExams",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExams_QuestionTypeId",
                table: "OnlineExams",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExams_TeacherUserId",
                table: "OnlineExams",
                column: "TeacherUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamStudentAnswerFiles_ModUserId",
                table: "OnlineExamStudentAnswerFiles",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamStudentAnswerFiles_OnlineExamStudentId",
                table: "OnlineExamStudentAnswerFiles",
                column: "OnlineExamStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamStudentAnswers_ModUserId",
                table: "OnlineExamStudentAnswers",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamStudentAnswers_OnlineExamStudentId",
                table: "OnlineExamStudentAnswers",
                column: "OnlineExamStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamStudentAnswers_OnlineExamQuestionId_OnlineExamStudentId",
                table: "OnlineExamStudentAnswers",
                columns: new[] { "OnlineExamQuestionId", "OnlineExamStudentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamStudents_ModUserId",
                table: "OnlineExamStudents",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamStudents_StudentUserId",
                table: "OnlineExamStudents",
                column: "StudentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExamStudents_OnlineExamId_StudentUserId",
                table: "OnlineExamStudents",
                columns: new[] { "OnlineExamId", "StudentUserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_DifficultyLevelTypeId",
                table: "Questions",
                column: "DifficultyLevelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_LessonId",
                table: "Questions",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_LessonTopicId",
                table: "Questions",
                column: "LessonTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ModUserId",
                table: "Questions",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionMakerUserId",
                table: "Questions",
                column: "QuestionMakerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionTypeId",
                table: "Questions",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sliders_ModUserId",
                table: "Sliders",
                column: "ModUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentOnlineExamResults_OnlineExamStudentId",
                table: "StudentOnlineExamResults",
                column: "OnlineExamStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentOnlineExamResults_LessonId_OnlineExamStudentId",
                table: "StudentOnlineExamResults",
                columns: new[] { "LessonId", "OnlineExamStudentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_StudentNo",
                table: "UserProfiles",
                column: "StudentNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserGroupId",
                table: "Users",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName_UserGroupId",
                table: "Users",
                columns: new[] { "UserName", "UserGroupId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "DescriptiveQuestions");

            migrationBuilder.DropTable(
                name: "DescrptiveQuestionAnswers");

            migrationBuilder.DropTable(
                name: "ErrorLogs");

            migrationBuilder.DropTable(
                name: "MultipleChoiceQuestionAnswers");

            migrationBuilder.DropTable(
                name: "MultipleChoiceQuestions");

            migrationBuilder.DropTable(
                name: "OnlineExamDescriptiveQuestions");

            migrationBuilder.DropTable(
                name: "OnlineExamMultipleChoiceQuestions");

            migrationBuilder.DropTable(
                name: "OnlineExamStudentAnswerFiles");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "StudentOnlineExamResults");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "WeekDays");

            migrationBuilder.DropTable(
                name: "OnlineExamStudentAnswers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "OnlineExamQuestions");

            migrationBuilder.DropTable(
                name: "OnlineExamStudents");

            migrationBuilder.DropTable(
                name: "LessonTopics");

            migrationBuilder.DropTable(
                name: "DifficultyLevelTypes");

            migrationBuilder.DropTable(
                name: "OnlineExams");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "QuestionTypes");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "LevelGroups");

            migrationBuilder.DropTable(
                name: "UserGroups");
        }
    }
}
