namespace eknowID.Repositories
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using eknowID.Repositories.Tables;

    public partial class eknowIDContext : DbContext
    {
        public eknowIDContext()
            : base("name=eknowIDContext")
        {
            Database.SetInitializer<eknowIDContext>(null);
        }

        public virtual DbSet<AccountRef> AccountRefs { get; set; }
        public virtual DbSet<AlacartReport> AlacartReports { get; set; }
        public virtual DbSet<AlacartReportType> AlacartReportTypes { get; set; }
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<CardList> CardLists { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<CMSHomePage> CMSHomePages { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<County> Counties { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<CouponDiscountType> CouponDiscountTypes { get; set; }
        public virtual DbSet<CourtLocation> CourtLocations { get; set; }
        public virtual DbSet<CourtType> CourtTypes { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<DrugVerification> DrugVerifications { get; set; }
        public virtual DbSet<DrugVerificationDetail> DrugVerificationDetails { get; set; }
        public virtual DbSet<EducationalDetail> EducationalDetails { get; set; }
        public virtual DbSet<ELMAH_Error> ELMAH_Error { get; set; }
        public virtual DbSet<EmailSendLog> EmailSendLogs { get; set; }
        public virtual DbSet<EmploymentDetail> EmploymentDetails { get; set; }
        public virtual DbSet<ForgotPassword> ForgotPasswords { get; set; }
        public virtual DbSet<IdentificationType> IdentificationTypes { get; set; }
        public virtual DbSet<LicenseInfo> LicenseInfoes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderAdditionalCharge> OrderAdditionalCharges { get; set; }
        public virtual DbSet<OrderOptReport> OrderOptReports { get; set; }
        public virtual DbSet<OrderState> OrderStates { get; set; }
        public virtual DbSet<OrderType> OrderTypes { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<PlanDetail> PlanDetails { get; set; }
        public virtual DbSet<PlanReport> PlanReports { get; set; }
        public virtual DbSet<PlanType> PlanTypes { get; set; }
        public virtual DbSet<PostGraduationDetail> PostGraduationDetails { get; set; }
        public virtual DbSet<Profession> Professions { get; set; }
        public virtual DbSet<ProfessionPlan> ProfessionPlans { get; set; }
        public virtual DbSet<ProfessionReport> ProfessionReports { get; set; }
        public virtual DbSet<ReferenceInfo> ReferenceInfoes { get; set; }
        public virtual DbSet<ReferenceType> ReferenceTypes { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<ReportType> ReportTypes { get; set; }
        public virtual DbSet<SecQuestion> SecQuestions { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<StateCriminalCourtFee> StateCriminalCourtFees { get; set; }
        public virtual DbSet<StateCountyCourtFee> StateCountyCourtFees { get; set; }
        public virtual DbSet<StateDistrictCourtFee> StateDistrictCourtFees { get; set; }
        public virtual DbSet<TransactionLog> TransactionLogs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAdditionalSkill> UserAdditionalSkills { get; set; }
        public virtual DbSet<UserEducationalDetail> UserEducationalDetails { get; set; }
        public virtual DbSet<UserEmploymentDetail> UserEmploymentDetails { get; set; }
        public virtual DbSet<UserLanuagesKnown> UserLanuagesKnowns { get; set; }
        public virtual DbSet<UserLicenseInfo> UserLicenseInfoes { get; set; }
        public virtual DbSet<UserPostGraduation> UserPostGraduations { get; set; }
        public virtual DbSet<UserReferenceInfo> UserReferenceInfoes { get; set; }
        public virtual DbSet<UserSkill> UserSkills { get; set; }
        public virtual DbSet<ValidationRule> ValidationRules { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<PaymentWalletHistory> PaymentWalletHistors { get; set; }
        public virtual DbSet<WalletBalance> WalletBalances { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountRef>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<AlacartReportType>()
                .Property(e => e.ReportType)
                .IsUnicode(false);

            modelBuilder.Entity<AlacartReportType>()
                .Property(e => e.ReportPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Candidate>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Candidate>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Candidate>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Candidate>()
                .Property(e => e.Description)
                .IsUnicode(false);            

            modelBuilder.Entity<CardList>()
                .Property(e => e.CardType)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.CompanyPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.CompanyTaxId)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Company>()
                .Property(e => e.JobTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Coupon>()
                .Property(e => e.DiscountValue)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CouponDiscountType>()
                .HasMany(e => e.Coupons)
                .WithRequired(e => e.CouponDiscountType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CourtLocation>()
                .Property(e => e.OfficeName)
                .IsUnicode(false);

            modelBuilder.Entity<EducationalDetail>()
                .Property(e => e.University)
                .IsUnicode(false);

            modelBuilder.Entity<EducationalDetail>()
                .HasMany(e => e.PostGraduationDetails)
                .WithRequired(e => e.EducationalDetail)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.DiscountAmt)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .Property(e => e.PaidAmt)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .Property(e => e.RefundAmt)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.EducationalDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.EmploymentDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.LicenseInfoes)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderOptReports)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderStates)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.ReferenceInfoes)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Plan>()
                .Property(e => e.Rate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Plan>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Plan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PostGraduationDetail>()
                .Property(e => e.University)
                .IsUnicode(false);

            modelBuilder.Entity<Profession>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Profession)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReferenceType>()
                .HasMany(e => e.ReferenceInfoes)
                .WithRequired(e => e.ReferenceType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Report>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Report>()
                .HasMany(e => e.OrderOptReports)
                .WithRequired(e => e.Report)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReportType>()
                .Property(e => e.ReportTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .HasMany(e => e.PostGraduationDetails)
                .WithRequired(e => e.State)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StateCriminalCourtFee>()
                .HasKey<int>(p=>p.StateId);

            modelBuilder.Entity<StateCountyCourtFee>()
                .HasKey<int>(p => p.Id);

            modelBuilder.Entity<StateDistrictCourtFee>()
                .HasKey<int>(p => p.Id);

            modelBuilder.Entity<OrderAdditionalCharge>()
                .HasKey<long>(p => p.Id);

            modelBuilder.Entity<TransactionLog>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionLog>()
                .Property(e => e.Request)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionLog>()
                .Property(e => e.Response)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ForgotPasswords)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserEducationalDetails)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserEmploymentDetails)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserLicenseInfoes)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserPostGraduations)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserReferenceInfoes)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserAdditionalSkill>()
                .Property(e => e.Skill)
                .IsUnicode(false);

            modelBuilder.Entity<UserEducationalDetail>()
                .Property(e => e.University)
                .IsUnicode(false);

            modelBuilder.Entity<UserLanuagesKnown>()
                .Property(e => e.Lanuage)
                .IsUnicode(false);

            modelBuilder.Entity<UserPostGraduation>()
                .Property(e => e.University)
                .IsUnicode(false);

            modelBuilder.Entity<Log>()
                .Property(e => e.Thread)
                .IsUnicode(false);

            modelBuilder.Entity<Log>()
                .Property(e => e.Level)
                .IsUnicode(false);

            modelBuilder.Entity<Log>()
                .Property(e => e.Logger)
                .IsUnicode(false);

            modelBuilder.Entity<Log>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<PaymentWalletHistory>()
                .Property(e => e.Deposite)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PaymentWalletHistory>()
                .Property(e => e.Withdrawal)
                .HasPrecision(19, 4);
        }
    }
}
