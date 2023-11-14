using Common.Functions;
using DataAccessLayer.EntityMap.BasicDefinitions;
using DataAccessLayer.EntityMaps.BasicDefinitionsMaps;
using DataAccessLayer.EntityMaps.ContentsMaps;
using DataAccessLayer.EntityMaps.FinancialsMaps;
using DataAccessLayer.EntityMaps.HomeworksMaps;
using DataAccessLayer.EntityMaps.IdentitiesMaps;
using DataAccessLayer.EntityMaps.OnlineExamMaps;
using DataAccessLayer.EntityMaps.OrdersMaps;
using DataAccessLayer.EntityMaps.SystemsMaps;
using DataAccessLayer.EntityMaps.TrainingManagementMaps;
using DataModels.BasicDefinitionsModels;
using DataModels.ContentsModels;
using DataModels.FinancialsModels;
using DataModels.HomeworksModels;
using DataModels.IdentitiesModels;
using DataModels.OnlineExamModels;
using DataModels.OrdersModels;
using DataModels.SystemsModels;
using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.ApplicationDatabase
{
    public class MainDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppConfigProvider.GetConnectionString());
        }
        //*************************************************************** Application DBset Start

        #region Identities
        public DbSet<UserGroupsModel> UserGroups { get; set; }
        public DbSet<UsersModel> UsersModels { get; set; }
        public DbSet<StudentUserProfilesModel> StudentUserProfiles { get; set; }
        public DbSet<TeacherUserProfilesModel> TeacherUserProfiles { get; set; }
        public DbSet<TeacherPrefixesModel> TeacherUserPrefixes { get; set; }
        public DbSet<TeacherUserTypesModel> TeacherUserTypes { get; set; }
        public DbSet<ProductsModel> Products { get; set; }
        public DbSet<ProductTypesModel> ProductTypes { get; set; }
        public DbSet<MessagesModel> Messages { get; set; }
        public DbSet<MessageTypesModel> MessageTypes { get; set; }
        public DbSet<MessageReceiverUsersModel> MessageReceiverUsers { get; set; }
        public DbSet<IdentifierChargeSettingsModel> IdentifierChargeSettings { get; set; }
        public DbSet<StudentUserSmsOptionsModel> StudentUserSmsOptions { get; set; }
        public DbSet<SendSMSTargetsModel> SendSMSTargets { get; set; }
        public DbSet<UserLoginLogsModel> UserLoginLogs { get; set; }
        public DbSet<MessageTagsModel> MessageTags { get; set; }
        public DbSet<TagsModel> Tags { get; set; }
        public DbSet<UserLoginHistoriesModel> UserLoginHistories { get; set; }
        public DbSet<StudentUserMessagesModel> StudentUserMessages { get; set; }
        #endregion

        #region Contents
        public DbSet<AboutUsModel> AboutUs { get; set; }
        public DbSet<SlidersModel> Slider { get; set; }
        public DbSet<CoursePromoSectionsModel> CoursePromoSectionGroups { get; set; }
        public DbSet<CoursePromosModel> CoursePromoSections { get; set; }
        public DbSet<OnlineExamPromoSectionsModel> OnlineExamPromoSectionGroups { get; set; }
        public DbSet<OnlineExamPromosModel> OnlineExamPromoSections { get; set; }
        public DbSet<ProductPromoSectionsModel> ProductPromoSectionGroups { get; set; }
        public DbSet<ProductPromosModel> ProductPromoSections { get; set; }
        public DbSet<SuggestionTeachersModel> SuggestionTeachers { get; set; }
        public DbSet<ConfirmationCodesModel> ConfirmationCodes { get; set; }
        public DbSet<TeacherSampleVideosModel> TeacherSampleVideos { get; set; }
        public DbSet<ContactUsModel> ContactUs { get; set; }
        public DbSet<AcceptedStudentInEntranceExamsModel> AcceptedStudentInEntranceExams { get; set; }
        public DbSet<OlympiadMedalTypesModel> OlympiadMedalTypes { get; set; }
        public DbSet<EntranceExamTypesModel> EntranceExamTypes { get; set; }
        public DbSet<TeacherResumesModel> TeacherResumes { get; set; }
        public DbSet<BlogsModel> Blogs { get; set; }
        public DbSet<BlogGroupsModel> BlogGroups { get; set; }
        public DbSet<TeacherCommentsModel> TeacherComments { get; set; }
        public DbSet<HomePageNotificationsModel> HomePageNotifications { get; set; }
        public DbSet<CourseNotificationsModel> CourseNotifications { get; set; }
        public DbSet<NotificationsModel> Notifications { get; set; }
        public DbSet<FAQModel> FAQ { get; set; }
        public DbSet<OldStudentCommentsModel> OldStudentComments { get; set; }
        public DbSet<CommentTypesModel> CommentTypes { get; set; }
        #endregion

        #region Homework
        public DbSet<HomeworksModel> HomeWorks { get; set; }
        public DbSet<HomeworkAnswersModel> HomeworkAnswers { get; set; }
        #endregion

        #region TraningManagements  
        public DbSet<CourseTypesModel> CourseTypes { get; set; }
        public DbSet<CoursesModel> Courses { get; set; }
        public DbSet<LevelsModel> Levels { get; set; }
        public DbSet<FieldsModel> Fields { get; set; }
        public DbSet<LessonsModel> Lessons { get; set; }
        public DbSet<LevelGroupsModel> LevelGroups { get; set; }
        public DbSet<CourseMeetingsModel> CourseMeetings { get; set; }
        public DbSet<CourseMeetingBookletsModel> CourseMeetingBooklets { get; set; }
        public DbSet<CourseMeetingVideosModel> CourseMeetingVideos { get; set; }
        public DbSet<CourseMeetingStudentsModel> CourseMeetingStudents { get; set; }
        public DbSet<CourseSampleVideosModel> CourseSampleVideos { get; set; }
        public DbSet<CourseMeetingStudentTypesModel> CourseMeetingStudentTypes { get; set; }
        public DbSet<MeetingAbsentationsModel> MeetingAbsentations { get; set; }
        public DbSet<OnlineClassesModel> OnlineClasses { get; set; }
        public DbSet<CourseStudentQuestionsModel> StudentQuestions { get; set; }
        public DbSet<CourseStudentQuestionAnswersModel> StudentQuestionAnswers { get; set; }
        public DbSet<CourseBookletsModel> CourseBooklets { get; set; }
        public DbSet<AbsentationsModel> Absentations { get; set; }
        public DbSet<CourseMeetingDedicatedTeachersModel> CourseMeetingDedicatedTeachers { get; set; }
        public DbSet<CourseDescriptionVideosModel> CourseDescriptionVideos { get; set; }
        public DbSet<CourseFAQsModel> CourseFAQs { get; set; }
        public DbSet<CommentOldStudentCoursesModel> CommentOldStudentCourses { get; set; }
        public DbSet<CourseStudentQuestionLikesModel> CourseStudentQuestionLikes { get; set; }
        public DbSet<CourseStudentNewCommentsModel> CourseStudentNewComments { get; set; }
        #endregion

        #region Financials
        public DbSet<TeacherSattlementSchedulesModel> TeacherSattlementSchedules { get; set; }
        public DbSet<TeacherSattlementsModel> TeacherSattlements { get; set; }
        public DbSet<TeacherMeetingFeesModel> TeacherMeetingFees { get; set; }
        public DbSet<TeacherPaymentMethodsModel> TeacherPaymentMethods { get; set; }
        public DbSet<TeacherPercentagesModel> TeacherPercentages { get; set; }
        public DbSet<TeacherPaymentMethodTypesModel> TeacherPaymentMethodTypes { get; set; }
        public DbSet<CourseMultiTeacherShareTypesModel> CourseMultiTeacherShareTypes { get; set; }
        public DbSet<CourseMultiTeacherSharesModel> CourseMultiTeacherShares { get; set; }
        public DbSet<BanksModel> Banks { get; set; }
        public DbSet<StudentChequesModel> Cheques { get; set; }
        public DbSet<PaidChequesModel> PaidCheques { get; set; }
        public DbSet<ChequesStatusTypesModel> ChequesStatusTypes { get; set; }
        public DbSet<StudentFinancialDebtsModel> StudentFinancialDebts { get; set; }
        public DbSet<StudentFinancialPaymentsModel> StudentFinancialPayments { get; set; }
        public DbSet<StudentFinancialPaymentTypesModel> StudentFinancialPaymentTypes { get; set; }
        public DbSet<StudentPosPaymentsModel> PosPayments { get; set; }
        public DbSet<BankPosDevicesModel> BankPosDevices { get; set; }
        public DbSet<StudentFinancialReturnPaymentsModel> StudentReturnPayments { get; set; }
        public DbSet<ReturnPaymentTypesModel> ReturnPaymentTypes { get; set; }
        public DbSet<DiscountCodesModel> DiscountCodes { get; set; }
        public DbSet<DiscountCodeTypesModel> DiscountCodeTypes { get; set; }
        public DbSet<DiscountCodeAcademyProductsModel> DiscountCodeAcademyProducts { get; set; }
        public DbSet<SalesPartnerShareTypesModel> SalesPartnerShareTypes { get; set; }
        public DbSet<SalesPartnerUserSharesModel> SalesPartnerShares { get; set; }
        public DbSet<SalesPartnerUserOptionsModel> SalesPartnerUserOptions { get; set; }
        public DbSet<StudentFinesModel> StudentFines { get; set; }
        public DbSet<FinancialTransactionsModel> FinancialTransactions { get; set; }
        public DbSet<InvoicesModel> Invoices { get; set; }
        public DbSet<PaymentsModel> Payments { get; set; }
        public DbSet<StudentPaymentLinksModel> StudentPaymentLinks { get; set; }
        public DbSet<StudentFinancialManualDebtsModel> StudentFinancialManualDebts { get; set; }
        public DbSet<StudentUserScoresModel> UserScores { get; set; }
        #endregion

        #region Orders 
        public DbSet<OrdersModel> Orders { get; set; }
        public DbSet<OrderDetailsModel> OrderDetails { get; set; }
        #endregion

        #region SystemsAndBasicDefination
        public DbSet<ErrorLogsModel> ErrorLogs { get; set; }
        public DbSet<CountriesModel> Countries { get; set; }
        public DbSet<ProvincesModel> Provinces { get; set; }
        public DbSet<WeekDaysModel> WeekDays { get; set; }
        public DbSet<LanguagesModel> Languages { get; set; }
        public DbSet<CitiesModel> Cities { get; set; }
        public DbSet<SchoolTypesModel> SchoolTypes { get; set; }
        public DbSet<OrderStatusTypesModel> OrderStatusTypes { get; set; }
        public DbSet<InvoiceStatusTypesModel> InvoiceStatusTypes { get; set; }
        public DbSet<InvoiceTypesModel> InvoiceTypes { get; set; }
        public DbSet<PaymentGatewaysModel> PaymentGateways { get; set; }
        public DbSet<AcademyProductTypesModel> AcademyProductTypes { get; set; }
        public DbSet<IntroductionWithAcademyTypesModel> IntroductionWithAcademyTypes { get; set; }
        public DbSet<SmsOptionsModel> SmsOptions { get; set; }
        public DbSet<CourseCategoryTypesModel> CourseCategoryTypes { get; set; }
        public DbSet<StudentUserScoreTypesModel> UserScoreTypes { get; set; }
        public DbSet<BaseInfosModel> BaseInfos { get; set; }
        public DbSet<ScoringTariffsModel> ScoringTariffs { get; set; }
        #endregion

        #region OnlineExam
        public DbSet<LessonTopicsModel> LessonTopics { get; set; }
        public DbSet<DifficultyLevelTypesModel> DifficultyLevelTypes { get; set; }
        public DbSet<OnlineExamsModel> OnlineExams { get; set; }
        public DbSet<OnlineExamQuestionsModel> OnlineExamQuestions { get; set; }
        public DbSet<QuestionTypesModel> QuestionTypes { get; set; }
        public DbSet<QuestionsModel> Questions { get; set; }
        public DbSet<DescriptiveQuestionsModel> DescriptiveQuestions { get; set; }
        public DbSet<MultipleChoiceQuestionsModel> MultipleChoiceQuestions { get; set; }
        public DbSet<OnlineExamMultipleChoiceQuestionsModel> OnlineExamMultipleChoiceQuestions { get; set; }
        public DbSet<OnlineExamDescriptiveQuestionsModel> OnlineExamDescriptiveQuestions { get; set; }
        public DbSet<OnlineExamStudentsModel> OnlineExamStudents { get; set; }
        public DbSet<OnlineExamStudentAnswersModel> OnlineExamStudentAnswers { get; set; }
        public DbSet<DescrptiveQuestionAnswersModel> DescrptiveQuestionAnswers { get; set; }
        public DbSet<MultipleChoiceQuestionAnswersModel> MultipleChoiceQuestionAnswers { get; set; }
        public DbSet<OnlineExamStudentAnswerFilesModel> OnlineExamStudentAnswerFiles { get; set; }
        public DbSet<StudentOnlineExamResultsModel> StudentOnlineExamResults { get; set; }
        public DbSet<OnlineExamTypesModel> OnlineExamTypes { get; set; }
        public DbSet<CourseMeetingOnlineExamsModel> CourseMeetingOnlineExams { get; set; }
        public DbSet<QuestionReferencesModel> QuestionReferences { get; set; }
        public DbSet<OnlineExamAnalysisModel> OnlineExamAnalysis { get; set; }
        public DbSet<OnlineExamFieldsModel> OnlineExamFields { get; set; }
        #endregion

        //*************************************************************** Application DBset End

        //*************************************************************** Model Creating Start
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Identities
            new UserGroupsMap(modelBuilder.Entity<UserGroupsModel>());
            new StudentUserProfilesMap(modelBuilder.Entity<StudentUserProfilesModel>());
            new UsersMap(modelBuilder.Entity<UsersModel>());
            new TeacherUserPrefixesMap(modelBuilder.Entity<TeacherPrefixesModel>());
            new TeacherUserProfilesMap(modelBuilder.Entity<TeacherUserProfilesModel>());
            new MessagesMap(modelBuilder.Entity<MessagesModel>());
            new MessageTypesMap(modelBuilder.Entity<MessageTypesModel>());
            new MessageReceiverUsersMap(modelBuilder.Entity<MessageReceiverUsersModel>());
            new IdentifierChargeSettingsMap(modelBuilder.Entity<IdentifierChargeSettingsModel>());
            new StudentUserSmsOptionsMap(modelBuilder.Entity<StudentUserSmsOptionsModel>());
            new SendSMSTargetsMap(modelBuilder.Entity<SendSMSTargetsModel>());
            new UserLoginLogsMap(modelBuilder.Entity<UserLoginLogsModel>());
            new MessageTagsMap(modelBuilder.Entity<MessageTagsModel>());
            new TagsMap(modelBuilder.Entity<TagsModel>());
            new UserLoginHistoriesMap(modelBuilder.Entity<UserLoginHistoriesModel>());
            new TeacherUserTypesMap(modelBuilder.Entity<TeacherUserTypesModel>());
            new StudentUserMessagesMap(modelBuilder.Entity<StudentUserMessagesModel>());
            #endregion

            #region Contents
            new AboutUsMap(modelBuilder.Entity<AboutUsModel>());
            new SlidersMap(modelBuilder.Entity<SlidersModel>());
            new CoursePromoSectionsMap(modelBuilder.Entity<CoursePromoSectionsModel>());
            new CoursePromosMap(modelBuilder.Entity<CoursePromosModel>());
            new OnlineExamPromoSectionsMap(modelBuilder.Entity<OnlineExamPromoSectionsModel>());
            new OnlineExamPromosMap(modelBuilder.Entity<OnlineExamPromosModel>());
            new ProductPromoSectionsMap(modelBuilder.Entity<ProductPromoSectionsModel>());
            new ProductPromosMap(modelBuilder.Entity<ProductPromosModel>());
            new SuggestionTeachersMap(modelBuilder.Entity<SuggestionTeachersModel>());
            new ConfirmationCodesMap(modelBuilder.Entity<ConfirmationCodesModel>());
            new TeacherSampleVideosMap(modelBuilder.Entity<TeacherSampleVideosModel>());
            new ContactUsMap(modelBuilder.Entity<ContactUsModel>());
            new TeacherResumesMap(modelBuilder.Entity<TeacherResumesModel>());
            new AcceptedStudentInEntranceExamsMap(modelBuilder.Entity<AcceptedStudentInEntranceExamsModel>());
            new EntranceExamTypesMap(modelBuilder.Entity<EntranceExamTypesModel>());
            new OlympiadMedalTypesMap(modelBuilder.Entity<OlympiadMedalTypesModel>());
            new BlogsMap(modelBuilder.Entity<BlogsModel>());
            new BlogGroupsMap(modelBuilder.Entity<BlogGroupsModel>());
            new TeacherCommentsMap(modelBuilder.Entity<TeacherCommentsModel>());
            new CourseNotificationsMap(modelBuilder.Entity<CourseNotificationsModel>());
            new HomePageNotificationsMap(modelBuilder.Entity<HomePageNotificationsModel>());
            new NotificationsMap(modelBuilder.Entity<NotificationsModel>());
            new FAQMap(modelBuilder.Entity<FAQModel>());

            new OldStudentCommentsMap(modelBuilder.Entity<OldStudentCommentsModel>());
            new CommentTypesMap(modelBuilder.Entity<CommentTypesModel>());
            #endregion

            #region Orders

            new OrdersMap(modelBuilder.Entity<OrdersModel>());
            new OrderDetailsMap(modelBuilder.Entity<OrderDetailsModel>());

            #endregion

            #region Homework
            new HomeworkAnswersMap(modelBuilder.Entity<HomeworkAnswersModel>());
            new HomeworksMap(modelBuilder.Entity<HomeworksModel>());
            #endregion

            #region TraningManagements
            new CourseTypesMap(modelBuilder.Entity<CourseTypesModel>());
            new CoursesMap(modelBuilder.Entity<CoursesModel>());
            new LevelGroupsMap(modelBuilder.Entity<LevelGroupsModel>());
            new LevelsMap(modelBuilder.Entity<LevelsModel>());
            new FieldsMap(modelBuilder.Entity<FieldsModel>());
            new LessonsMap(modelBuilder.Entity<LessonsModel>());
            new CourseMeetingsMap(modelBuilder.Entity<CourseMeetingsModel>());
            new CourseMeetingBookletsMap(modelBuilder.Entity<CourseMeetingBookletsModel>());
            new CourseMeetingVideosMap(modelBuilder.Entity<CourseMeetingVideosModel>());
            new CourseMeetingStudentsMap(modelBuilder.Entity<CourseMeetingStudentsModel>());
            new ProductsMap(modelBuilder.Entity<ProductsModel>());
            new ProductTypesMap(modelBuilder.Entity<ProductTypesModel>());
            new CourseSampleVideosMap(modelBuilder.Entity<CourseSampleVideosModel>());
            new CourseMeetingStudentTypesMap(modelBuilder.Entity<CourseMeetingStudentTypesModel>());
            new MeetingAbsentationsMap(modelBuilder.Entity<MeetingAbsentationsModel>());
            new OnlineClassesMap(modelBuilder.Entity<OnlineClassesModel>());
            new CourseStudentQuestionsMap(modelBuilder.Entity<CourseStudentQuestionsModel>());
            new CourseStudentQuestionAnswersMap(modelBuilder.Entity<CourseStudentQuestionAnswersModel>());
            new CourseBookletsMap(modelBuilder.Entity<CourseBookletsModel>());
            new AbsentationsMap(modelBuilder.Entity<AbsentationsModel>());
            new CourseMeetingDedicatedTeachersMap(modelBuilder.Entity<CourseMeetingDedicatedTeachersModel>());
            new CourseDescriptionVideosMap(modelBuilder.Entity<CourseDescriptionVideosModel>());
            new CourseFAQsMap(modelBuilder.Entity<CourseFAQsModel>());
            new CommentOldStudentCoursesMap(modelBuilder.Entity<CommentOldStudentCoursesModel>());
            new CourseStudentQuestionLikesMap(modelBuilder.Entity<CourseStudentQuestionLikesModel>());
            new CourseStudentNewCommentsMap(modelBuilder.Entity<CourseStudentNewCommentsModel>());
            #endregion

            #region Financials
            new FinancialTransactionsMap(modelBuilder.Entity<FinancialTransactionsModel>());
            new InvoicesMap(modelBuilder.Entity<InvoicesModel>());
            new PaymentsMap(modelBuilder.Entity<PaymentsModel>());
            new TeacherSattlementSchedulesMap(modelBuilder.Entity<TeacherSattlementSchedulesModel>());
            new TeacherSattlementsMap(modelBuilder.Entity<TeacherSattlementsModel>());
            new TeacherPaymentMethodsMap(modelBuilder.Entity<TeacherPaymentMethodsModel>());
            new TeacherPercentagesMap(modelBuilder.Entity<TeacherPercentagesModel>());
            new TeacherPaymentMethodTypesMap(modelBuilder.Entity<TeacherPaymentMethodTypesModel>());
            new TeacherMeetingFeesMap(modelBuilder.Entity<TeacherMeetingFeesModel>());
            new BanksMap(modelBuilder.Entity<BanksModel>());
            new StudentChequesMap(modelBuilder.Entity<StudentChequesModel>());
            new ChequesStatusTypesMap(modelBuilder.Entity<ChequesStatusTypesModel>());
            new StudentFinancialDebtsMap(modelBuilder.Entity<StudentFinancialDebtsModel>());
            new StudentFinancialPaymentsMap(modelBuilder.Entity<StudentFinancialPaymentsModel>());
            new StudentFinancialPaymentTypesMap(modelBuilder.Entity<StudentFinancialPaymentTypesModel>());
            new StudentPosPaymentsMap(modelBuilder.Entity<StudentPosPaymentsModel>());
            new BankPosDevicesMap(modelBuilder.Entity<BankPosDevicesModel>());
            new ReturnPaymentTypesMap(modelBuilder.Entity<ReturnPaymentTypesModel>());
            new StudentFinancialReturnPaymentsMap(modelBuilder.Entity<StudentFinancialReturnPaymentsModel>());
            new StudentFinesMap(modelBuilder.Entity<StudentFinesModel>());
            new DiscountCodesMap(modelBuilder.Entity<DiscountCodesModel>());
            new DiscountCodeTypesMap(modelBuilder.Entity<DiscountCodeTypesModel>());
            new DiscountCodeAcademyProductsMap(modelBuilder.Entity<DiscountCodeAcademyProductsModel>());
            new SalesPartnerShareTypesMap(modelBuilder.Entity<SalesPartnerShareTypesModel>());
            new SalesPartnerUserSharesMap(modelBuilder.Entity<SalesPartnerUserSharesModel>());
            new SalesPartnerUserOptionsMap(modelBuilder.Entity<SalesPartnerUserOptionsModel>());
            new StudentPaymentLinksMap(modelBuilder.Entity<StudentPaymentLinksModel>());
            new PaidChequesMap(modelBuilder.Entity<PaidChequesModel>());
            new CourseMultiTeacherShareTypesMap(modelBuilder.Entity<CourseMultiTeacherShareTypesModel>());
            new CourseMultiTeacherSharesMap(modelBuilder.Entity<CourseMultiTeacherSharesModel>());
            new StudentFinancialManualDebtsMap(modelBuilder.Entity<StudentFinancialManualDebtsModel>());
            new StudentUserScoresMap(modelBuilder.Entity<StudentUserScoresModel>());
            #endregion

            #region SystemsAndBasicDefination

            new ErrorLogsMap(modelBuilder.Entity<ErrorLogsModel>());
            new CountriesMap(modelBuilder.Entity<CountriesModel>());
            new ProvincesMap(modelBuilder.Entity<ProvincesModel>());
            new CitiesMap(modelBuilder.Entity<CitiesModel>());
            new WeekDaysMap(modelBuilder.Entity<WeekDaysModel>());
            new LanguagesMap(modelBuilder.Entity<LanguagesModel>());
            new SchoolTypesMap(modelBuilder.Entity<SchoolTypesModel>());
            new InvoiceStatusTypesMap(modelBuilder.Entity<InvoiceStatusTypesModel>());
            new InvoiceTypesMap(modelBuilder.Entity<InvoiceTypesModel>());
            new PaymentGatewaysMap(modelBuilder.Entity<PaymentGatewaysModel>());
            new OrderStatusTypesMap(modelBuilder.Entity<OrderStatusTypesModel>());
            new AcademyProductTypesMap(modelBuilder.Entity<AcademyProductTypesModel>());
            new IntroductionWithAcademyTypesMap(modelBuilder.Entity<IntroductionWithAcademyTypesModel>());
            new SmsOptionsMap(modelBuilder.Entity<SmsOptionsModel>());
            new CourseCategoryTypesMap(modelBuilder.Entity<CourseCategoryTypesModel>());
            new StudentUserScoreTypesMap(modelBuilder.Entity<StudentUserScoreTypesModel>());
            new BaseInfosMap(modelBuilder.Entity<BaseInfosModel>());
            new ScoringTariffsMap(modelBuilder.Entity<ScoringTariffsModel>());
            #endregion

            #region OnlineExam
            new LessonTopicsMap(modelBuilder.Entity<LessonTopicsModel>());
            new LessonsMap(modelBuilder.Entity<LessonsModel>());
            new QuestionTypesMap(modelBuilder.Entity<QuestionTypesModel>());
            new DifficultyLevelTypesMap(modelBuilder.Entity<DifficultyLevelTypesModel>());
            new QuestionsMap(modelBuilder.Entity<QuestionsModel>());
            new MultipleChoiceQuestionsMap(modelBuilder.Entity<MultipleChoiceQuestionsModel>());
            new DescriptiveQuestionsMap(modelBuilder.Entity<DescriptiveQuestionsModel>());
            new OnlineExamsMap(modelBuilder.Entity<OnlineExamsModel>());
            new OnlineExamQuestionsMap(modelBuilder.Entity<OnlineExamQuestionsModel>());
            new OnlineExamMultipleChoiceQuestionsMap(modelBuilder.Entity<OnlineExamMultipleChoiceQuestionsModel>());
            new OnlineExamDescriptiveQuestionsMap(modelBuilder.Entity<OnlineExamDescriptiveQuestionsModel>());
            new OnlineExamStudentsMap(modelBuilder.Entity<OnlineExamStudentsModel>());
            new OnlineExamStudentAnswersMap(modelBuilder.Entity<OnlineExamStudentAnswersModel>());
            new MultipleChoiceQuestionAnswersMap(modelBuilder.Entity<MultipleChoiceQuestionAnswersModel>());
            new DescrptiveQuestionAnswersMap(modelBuilder.Entity<DescrptiveQuestionAnswersModel>());
            new OnlineExamStudentAnswerFilesMap(modelBuilder.Entity<OnlineExamStudentAnswerFilesModel>());
            new StudentOnlineExamResultsMap(modelBuilder.Entity<StudentOnlineExamResultsModel>());
            new OnlineExamTypesMap(modelBuilder.Entity<OnlineExamTypesModel>());
            new CourseMeetingOnlineExamsMap(modelBuilder.Entity<CourseMeetingOnlineExamsModel>());
            new QuestionReferencesMap(modelBuilder.Entity<QuestionReferencesModel>());
            new OnlineExamAnalysisMap(modelBuilder.Entity<OnlineExamAnalysisModel>());
            new OnlineExamFieldsMap(modelBuilder.Entity<OnlineExamFieldsModel>());
            #endregion

        }
        //*************************************************************** Model Creating End
    }
}
