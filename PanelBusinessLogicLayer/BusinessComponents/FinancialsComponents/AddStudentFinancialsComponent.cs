using Common.Enums;
using Common.Extentions;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using DataModels.IdentitiesModels;
using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using PanelBusinessLogicLayer.UtilityComponents.SmsComponents;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class AddStudentFinancialsComponent : IDisposable
    {
        private MainDBContext mainDbContext;
        private Repository<StudentFinancialPaymentsModel> studentFinancialPaymentsRepository;
        //===========================================
        public AddStudentFinancialsComponent()
        {
            mainDbContext = new MainDBContext();
            studentFinancialPaymentsRepository = new Repository<StudentFinancialPaymentsModel>(mainDbContext);
        }
        //===========================================
        public void Operation(AddStudentFinancialsViewModel viewModel, List<int> StudentUsersIds, int currentUserId, CourseMeetingStudentType courseMeetingStudentType)
        {
            using (var transaction = mainDbContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    int courseOrCourseMeetingId = 0;
                    int price = 0;
                    float discountPercent = 0;


                    if (courseMeetingStudentType == CourseMeetingStudentType.Course)
                    {
                        var course = GetCourse(viewModel);
                        courseOrCourseMeetingId = course.Id;
                        price = course.Price;
                        discountPercent = course.DiscountPercent;
                    }
                    else
                    {
                        var courseMeeting = GetCourseMeeting(viewModel);
                        courseOrCourseMeetingId = courseMeeting.Id;
                        price = courseMeeting.Price;
                        discountPercent = courseMeeting.DiscountPercent;
                    }

                    ValidateCourseMeetingStudents(StudentUsersIds, courseOrCourseMeetingId, courseMeetingStudentType);
                    int calculatePrice = Convert.ToInt32(price - (price * discountPercent / 100));

                    var calculateDiscountPrice = 0;
                    if (viewModel.StudentDiscount != null)
                        StudentDiscountsComponent.CalculatePriceAndDiscountPrice(viewModel.StudentDiscount, ref calculatePrice, ref calculateDiscountPrice, /*viewModel.AddSalesPartnerUserShares == null ?*/ 0 /*: viewModel.AddSalesPartnerUserShares.Amount*/);

                    foreach (int studentId in StudentUsersIds)
                    {
                        var studentCourseMeetingId = AddStudentCourseMeeting(viewModel, currentUserId, price, calculatePrice, calculateDiscountPrice, studentId, courseMeetingStudentType);
                        if (viewModel.BankTransfer != null)
                            AddBankTransfer(viewModel, currentUserId, studentId, studentCourseMeetingId);
                        if (viewModel.PosPayments != null)
                            AddPosPayment(viewModel, currentUserId, studentId, studentCourseMeetingId);
                        if (viewModel.Cash != null)
                            AddCashPayment(viewModel, currentUserId, studentId, studentCourseMeetingId);
                        if (viewModel.Cheques != null && viewModel.Cheques.Any())
                            AddCheques(viewModel, currentUserId, studentId, studentCourseMeetingId);
                        if (viewModel.StudentPaymentLink != null)
                            AddStudentPaymentLink(viewModel, currentUserId, studentCourseMeetingId);
                        if (viewModel.ManualDebt != null)
                            AddManualDebt(viewModel, currentUserId, studentId, studentCourseMeetingId);
                    }
                    transaction.Commit();
                    try
                    {
                        if (courseMeetingStudentType == CourseMeetingStudentType.Course)
                            StudentRegisterInCourseSmsComponent.Operation(courseOrCourseMeetingId, StudentUsersIds);
                    }
                    catch (Exception ex) { }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
        //============================================================================
        void AddStudentPaymentLink(AddStudentFinancialsViewModel viewModel, int currentUserId, int studentCourseMeetingId)
        {
            using (var studentPaymentLinksRepository = new Repository<StudentPaymentLinksModel>(mainDbContext))
            {
                studentPaymentLinksRepository.Add(new StudentPaymentLinksModel()
                {
                    AmountPayable = viewModel.StudentPaymentLink.AmountPayable,
                    RegDateTime = DateTime.UtcNow,
                    ModDateTime = DateTime.UtcNow,
                    IsPaid = false,
                    ModUserId = currentUserId,
                    CourseMeetingStudentId = studentCourseMeetingId
                });
                studentPaymentLinksRepository.SaveChanges();
            }
        }
        //============================================================================
        void AddCheques(AddStudentFinancialsViewModel viewModel, int currentUserId, int studentId, int studentCourseMeetingId)
        {
            using (var studentChequesRepository = new Repository<StudentChequesModel>(mainDbContext))
            {
                // 
                var model = viewModel.Cheques.Select(c => new StudentChequesModel()
                {
                    PaidChequeId = c.PaidChequeId,
                    ModUserId = currentUserId,
                    RegDateTime = DateTime.UtcNow,
                    ModDateTime = DateTime.UtcNow,
                    StudentFinancialPayment = new StudentFinancialPaymentsModel()
                    {
                        RegDateTime = DateTime.UtcNow,
                        ModDateTime = DateTime.UtcNow,
                        ModUserId = currentUserId,
                        StudentFinancialPaymentTypeId = (int)StudentFinancialPaymentTypes.Cheque,
                        StudentUserId = studentId,
                        Description = c.Description,
                        AmountPaid = ValidatePaidChequesAmount(c.PaidChequeId, c.AmountPaid),
                        CourseMeetingStudentId = studentCourseMeetingId,
                    }
                }).ToList();
                studentChequesRepository.AddRange(model);
                studentChequesRepository.SaveChanges();
            }
        }
        //===========================================================================
        void AddCashPayment(AddStudentFinancialsViewModel viewModel, int currentUserId, int studentId, int studentCourseMeetingId)
        {
            studentFinancialPaymentsRepository.Add(new StudentFinancialPaymentsModel()
            {
                StudentUserId = studentId,
                AmountPaid = viewModel.Cash.AmountPaid,
                Description = viewModel.Cash.Description,
                RegDateTime = viewModel.Cash.RegDateTime.ToDate(),
                ModUserId = currentUserId,
                ModDateTime = DateTime.UtcNow,
                StudentFinancialPaymentTypeId = (int)StudentFinancialPaymentTypes.Cash,
                CourseMeetingStudentId = studentCourseMeetingId,
            });
            studentFinancialPaymentsRepository.SaveChanges();
        }
        //===========================================================================
        void AddManualDebt(AddStudentFinancialsViewModel viewModel, int currentUserId, int studentId, int studentCourseMeetingId)
        {
            using (var studentFinancialManualDebtsRepository = new Repository<StudentFinancialManualDebtsModel>(mainDbContext))
            {
                studentFinancialManualDebtsRepository.Add(new StudentFinancialManualDebtsModel()
                {
                    ModDateTime = DateTime.UtcNow,
                    CourseMeetingStudentId = studentCourseMeetingId,
                    DebtAmount = viewModel.ManualDebt.DebtAmount,
                    Description = viewModel.ManualDebt.Description,
                    RegDateTime = viewModel.ManualDebt.RegDateTime.ToDate(),
                    ModUserId = currentUserId
                });
                studentFinancialManualDebtsRepository.SaveChanges();
            }
        }
        //===========================================================================
        void AddPosPayment(AddStudentFinancialsViewModel viewModel, int currentUserId, int studentId, int studentCourseMeetingId)
        {
            using (var studentPosPaymentsRepository = new Repository<StudentPosPaymentsModel>(mainDbContext))
            {
                studentPosPaymentsRepository.Add(new StudentPosPaymentsModel()
                {
                    BankPosDeviceId = viewModel.PosPayments.BankPosDeviceId,
                    ModUserId = currentUserId,
                    TrackingNo = viewModel.PosPayments.TrackingNo,
                    RegDateTime = viewModel.PosPayments.RegDateTime.ToDate(),
                    ModDateTime = DateTime.UtcNow,
                    StudentFinancialPayment = new StudentFinancialPaymentsModel()
                    {
                        ModDateTime = DateTime.UtcNow,
                        RegDateTime = viewModel.PosPayments.RegDateTime.ToDate(),
                        ModUserId = currentUserId,
                        StudentFinancialPaymentTypeId = (int)StudentFinancialPaymentTypes.Pos,
                        StudentUserId = studentId,
                        Description = viewModel.PosPayments.Description,
                        AmountPaid = viewModel.PosPayments.AmountPaid,
                        CourseMeetingStudentId = studentCourseMeetingId,
                    }
                });
                studentPosPaymentsRepository.SaveChanges();
            }
        }
        //===========================================================================
        void AddBankTransfer(AddStudentFinancialsViewModel viewModel, int currentUserId, int studentId, int studentCourseMeetingId)
        {
            studentFinancialPaymentsRepository.Add(new StudentFinancialPaymentsModel()
            {
                StudentUserId = studentId,
                AmountPaid = viewModel.BankTransfer.AmountPaid,
                Description = viewModel.BankTransfer.Description,
                RegDateTime = viewModel.BankTransfer.RegDateTime.ToDate(),
                ModDateTime = DateTime.UtcNow,
                ModUserId = currentUserId,
                StudentFinancialPaymentTypeId = (int)StudentFinancialPaymentTypes.BankTransfer,
                CourseMeetingStudentId = studentCourseMeetingId,
                RequestReferenceNumber  = viewModel.BankTransfer.RequestReferenceNumber
            });
            studentFinancialPaymentsRepository.SaveChanges();
        }
        //==================================================================
        int AddStudentCourseMeeting(AddStudentFinancialsViewModel viewModel, int currentUserId, int rawPrice, int calculatePrice, int calculateDiscountPrice, int studentId, CourseMeetingStudentType courseMeetingStudentType)
        {
            using (var courseMeetingStudentsRepository = new Repository<CourseMeetingStudentsModel>(mainDbContext))
            {
                ///=========
                var model = new CourseMeetingStudentsModel()
                {
                    CourseId = viewModel.CourseId,
                    IsActive = true,
                    IsOnlineRegistrated = false,
                    IsTemporaryRegistration = false,
                    StudentUserId = studentId,
                    RegDateTime = DateTime.UtcNow,
                    RawPrice = rawPrice,
                    Price = calculatePrice,
                    SalePartnerPrice = 0, // viewModel.AddSalesPartnerUserShares == null ? 0 : viewModel.AddSalesPartnerUserShares.Amount,
                    DiscountAmount = calculateDiscountPrice,
                    ModUserId = currentUserId,
                    CourseMeetingId = courseMeetingStudentType == CourseMeetingStudentType.CourseMeeting ? viewModel.CourseMeetingId : (int?)null,
                    CourseMeetingStudentTypeId = (int)courseMeetingStudentType,
                    StudentFinancialDebts = new StudentFinancialDebtsModel()
                    {
                        IsCanceled = false,
                        RegDateTime = DateTime.UtcNow,
                        ModUserId = currentUserId,
                        DiscountDiscription = viewModel.StudentDiscount == null || string.IsNullOrEmpty(viewModel.StudentDiscount.Description) ? "" : viewModel.StudentDiscount.Description,
                    },
                };
                courseMeetingStudentsRepository.Add(model);
                courseMeetingStudentsRepository.SaveChanges();
                return model.Id;
            }
        }
        //==================================================================
        CoursesModel GetCourse(AddStudentFinancialsViewModel viewModel)
        {
            using (var coursesRepository = new Repository<CoursesModel>())
            {
                var result = coursesRepository.SingleOrDefault(c => c.Id == viewModel.CourseId);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                return result;
            }
        }
        //==================================================================
        CourseMeetingsModel GetCourseMeeting(AddStudentFinancialsViewModel viewModel)
        {
            using (var courseMeetingsRepository = new Repository<CourseMeetingsModel>())
            {
                var result = courseMeetingsRepository.SingleOrDefault(c => c.Id == viewModel.CourseMeetingId, c => c.Course);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                return result;
            }
        }
        //===========================================
        void ValidateCourseMeetingStudents(List<int> StudentIds, int courseIdOrCourseMeetingId, CourseMeetingStudentType courseMeetingStudentType)
        {
            using (var courseMeetingStudentsRepository = new Repository<CourseMeetingStudentsModel>(mainDbContext))
            {
                var result = courseMeetingStudentsRepository.Where(c => !c.IsTemporaryRegistration && StudentIds.Contains(c.StudentUserId) && c.IsActive && c.CourseId == courseIdOrCourseMeetingId && c.CourseMeetingStudentTypeId == (int)courseMeetingStudentType, c => c.StudentUsers).Select(c => new CourseMeetingStudentsModel()
                {
                    StudentUsers = new UsersModel()
                    {
                        FirstName = c.StudentUsers.FirstName,
                        LastName = c.StudentUsers.LastName,
                    }
                }).ToList();
                if (result.Any())
                {
                    var student = result.First().StudentUsers;
                    throw new CustomException("# قبلا به این ! افزوده شده است".Replace("#", student.FirstName + " " + student.LastName).Replace("!", courseMeetingStudentType == CourseMeetingStudentType.Course ? "دوره" : "جلسه"));
                }
                courseMeetingStudentsRepository.Delete(c => c.IsTemporaryRegistration && StudentIds.Contains(c.StudentUserId) && c.IsActive && c.CourseId == courseIdOrCourseMeetingId && c.CourseMeetingStudentTypeId == (int)courseMeetingStudentType);
                courseMeetingStudentsRepository.SaveChanges();
            }
        }
        //=============================================================================== 
        int ValidatePaidChequesAmount(int paidChequeId, int amountPaid)
        {
            PaidChequesComponent.Validate(paidChequeId, amountPaid);
            return amountPaid;
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            mainDbContext?.Dispose();
            studentFinancialPaymentsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
