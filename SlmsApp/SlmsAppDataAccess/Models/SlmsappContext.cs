using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SlmsAppDataAccess.Models;

public partial class SlmsAppContext : DbContext
{
    public SlmsAppContext()
    {
    }

    public SlmsAppContext(DbContextOptions<SlmsAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddVideo> AddVideos { get; set; }

    public virtual DbSet<AspNetMenuItem> AspNetMenuItems { get; set; }

    public virtual DbSet<AspNetModule> AspNetModules { get; set; }

    public virtual DbSet<AspNetRoleMenuItem> AspNetRoleMenuItems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CourseEnrollment> CourseEnrollments { get; set; }

    public virtual DbSet<CourseFaq> CourseFaqs { get; set; }

    public virtual DbSet<CourseSectionsOrder> CourseSectionsOrders { get; set; }

    public virtual DbSet<CreateCourse> CreateCourses { get; set; }

    public virtual DbSet<CreateQuiz> CreateQuizzes { get; set; }

    public virtual DbSet<LessonsOrder> LessonsOrders { get; set; }

    public virtual DbSet<Myprofile> Myprofiles { get; set; }

    public virtual DbSet<QuizAnswer> QuizAnswers { get; set; }

    public virtual DbSet<QuizQuestion> QuizQuestions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<SubCategory> SubCategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserInterest> UserInterests { get; set; }

    public virtual DbSet<UserWishlistAndVisited> UserWishlistAndVisiteds { get; set; }

    public virtual DbSet<Video> Videos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SPRINTPARK\\SQLEXPRESS;Database=SlmsApp;User Id=sa;Password=a;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddVideo>(entity =>
        {
            entity.HasKey(e => e.AddVideoId).HasName("PK__AddVideo__999478F12342C724");

            entity.ToTable("AddVideo");

            entity.Property(e => e.VideoContent).IsUnicode(false);
            entity.Property(e => e.VideoCreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.VideoUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.AddVideos)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AddVideo_Users");

            entity.HasOne(d => d.Section).WithMany(p => p.AddVideos)
                .HasForeignKey(d => d.SectionId)
                .HasConstraintName("FK_AddVideo_Sections");
        });

        modelBuilder.Entity<AspNetMenuItem>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PK__AspNetMe__C99ED230805FD185");

            entity.Property(e => e.Icon)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MenuItemName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Module).WithMany(p => p.AspNetMenuItems)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AspNetMenuItems_AspNetModules");
        });

        modelBuilder.Entity<AspNetModule>(entity =>
        {
            entity.HasKey(e => e.ModuleId).HasName("PK__AspNetMo__2B7477A7F2DE704F");

            entity.Property(e => e.Icon).IsUnicode(false);
            entity.Property(e => e.ModuleName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.Url)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AspNetRoleMenuItem>(entity =>
        {
            entity.HasKey(e => e.RoleMenuId).HasName("PK__AspNetRo__F86287B6B36B9E72");

            entity.HasOne(d => d.Menu).WithMany(p => p.AspNetRoleMenuItems)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AspNetRoleMenuItems_AspNetMenuItems");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleMenuItems)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AspNetRoleMenuItems_AspNetRoles");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoriesId).HasName("PK__Categori__EFF9079054E878E2");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<CourseEnrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PK__CourseEn__7F68771B14D3CEC0");

            entity.HasIndex(e => new { e.UserId, e.CreateCourseId }, "UQ_Enroll").IsUnique();

            entity.Property(e => e.EnrollmentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.CreateCourse).WithMany(p => p.CourseEnrollments)
                .HasForeignKey(d => d.CreateCourseId)
                .HasConstraintName("FK_Enroll_Course");

            entity.HasOne(d => d.User).WithMany(p => p.CourseEnrollments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enroll_User");
        });

        modelBuilder.Entity<CourseFaq>(entity =>
        {
            entity.HasKey(e => e.CourseFaqsId).HasName("PK__CourseFa__2BBED703A61D5CA1");

            entity.Property(e => e.FaqCreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FaqQuestion).IsRequired();
            entity.Property(e => e.FaqUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreateCourse).WithMany(p => p.CourseFaqs)
                .HasForeignKey(d => d.CreateCourseId)
                .HasConstraintName("FK_CourseFaqs_CreateCourse");
        });

        modelBuilder.Entity<CourseSectionsOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CourseSe__3214EC07C83E8485");

            entity.ToTable("CourseSectionsOrder");

            entity.HasIndex(e => new { e.CreateCourseId, e.SectionOrder }, "UQ_Course_SectionOrder").IsUnique();

            entity.HasIndex(e => new { e.UserId, e.CreateCourseId, e.SectionId }, "UQ_User_Course_Section").IsUnique();

            entity.HasOne(d => d.CreateCourse).WithMany(p => p.CourseSectionsOrders)
                .HasForeignKey(d => d.CreateCourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseSectionsOrder_CreateCourse");

            entity.HasOne(d => d.Section).WithMany(p => p.CourseSectionsOrders)
                .HasForeignKey(d => d.SectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseSectionsOrder_Sections");

            entity.HasOne(d => d.User).WithMany(p => p.CourseSectionsOrders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_CourseSectionsOrder_Users");
        });

        modelBuilder.Entity<CreateCourse>(entity =>
        {
            entity.HasKey(e => e.CreateCourseId).HasName("PK__CreateCo__3F453349892C6680");

            entity.ToTable("CreateCourse");

            entity.HasIndex(e => e.CourseTitle, "UQ_CreateCourse_CourseTitle").IsUnique();

            entity.Property(e => e.CourseCreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CourseStatus).HasDefaultValue(true);
            entity.Property(e => e.CourseTitle)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.CourseUpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Duration).HasMaxLength(50);
            entity.Property(e => e.Level)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.CreateCourses)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CreateCourse_Category");

            entity.HasOne(d => d.SubCategory).WithMany(p => p.CreateCourses)
                .HasForeignKey(d => d.SubCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CreateCourse_SubCategory");

            entity.HasOne(d => d.User).WithMany(p => p.CreateCourses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_CreateCourse_User");
        });

        modelBuilder.Entity<CreateQuiz>(entity =>
        {
            entity.HasKey(e => e.CreateQuizId).HasName("PK__CreateQu__4F79ECF0340A37F9");

            entity.ToTable("CreateQuiz");

            entity.Property(e => e.QuizCreationTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.QuizTitle)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.QuizUpdateTime).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.CreateQuizzes)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CreateQuiz_Users");

            entity.HasOne(d => d.Section).WithMany(p => p.CreateQuizzes)
                .HasForeignKey(d => d.SectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CreateQuiz_Sections");
        });

        modelBuilder.Entity<LessonsOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LessonsO__3214EC077CF7115B");

            entity.ToTable("LessonsOrder");

            entity.HasIndex(e => new { e.CourseId, e.OrderId }, "UQ_LessonsOrder_Course_OrderId").IsUnique();

            entity.HasOne(d => d.Course).WithMany(p => p.LessonsOrders)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LessonsOrder_Course");

            entity.HasOne(d => d.Quiz).WithMany(p => p.LessonsOrders)
                .HasForeignKey(d => d.QuizId)
                .HasConstraintName("FK_LessonsOrder_Quiz");

            entity.HasOne(d => d.Section).WithMany(p => p.LessonsOrders)
                .HasForeignKey(d => d.SectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LessonsOrder_Section");

            entity.HasOne(d => d.User).WithMany(p => p.LessonsOrders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LessonsOrder_User");

            entity.HasOne(d => d.Video).WithMany(p => p.LessonsOrders)
                .HasForeignKey(d => d.VideoId)
                .HasConstraintName("FK_LessonsOrder_Video");
        });

        modelBuilder.Entity<Myprofile>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__myprofil__1788CC4CDC44C05B");

            entity.ToTable("myprofiles");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.AlternateMobileNumber).HasMaxLength(20);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.CollegeName).HasMaxLength(255);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Designation).HasMaxLength(100);
            entity.Property(e => e.Experience).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.GitHubUrl).HasMaxLength(255);
            entity.Property(e => e.HighestQualification).HasMaxLength(100);
            entity.Property(e => e.JobTitle).HasMaxLength(100);
            entity.Property(e => e.LinkedInUrl).HasMaxLength(255);
            entity.Property(e => e.MaritalStatus).HasMaxLength(20);
            entity.Property(e => e.QualificationStream).HasMaxLength(100);
            entity.Property(e => e.State).HasMaxLength(100);
            entity.Property(e => e.UpdateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Roles).WithMany(p => p.Myprofiles)
                .HasForeignKey(d => d.RolesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__myprofile__Roles__17F790F9");

            entity.HasOne(d => d.User).WithOne(p => p.Myprofile)
                .HasForeignKey<Myprofile>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__myprofile__UserI__18EBB532");
        });

        modelBuilder.Entity<QuizAnswer>(entity =>
        {
            entity.HasKey(e => e.QuizAnswerId).HasName("PK__QuizAnsw__37547546A33A3672");

            entity.Property(e => e.AnswerCreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AnswerUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.QuizAnswerText).IsRequired();

            entity.HasOne(d => d.QuizQuestion).WithMany(p => p.QuizAnswers)
                .HasForeignKey(d => d.QuizQuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QuizAnswers_QuizQuestions");
        });

        modelBuilder.Entity<QuizQuestion>(entity =>
        {
            entity.HasKey(e => e.QuizQuestionId).HasName("PK__QuizQues__45E34D3EBF306BC4");

            entity.Property(e => e.QuestionCreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.QuestionTime).HasDefaultValue(1);
            entity.Property(e => e.QuestionUpdatedDate)
                .HasDefaultValueSql("(NULL)")
                .HasColumnType("datetime");
            entity.Property(e => e.QuizQuestionText).IsRequired();

            entity.HasOne(d => d.CreateQuiz).WithMany(p => p.QuizQuestions)
                .HasForeignKey(d => d.CreateQuizId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QuizQuestions_CreateQuiz");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolesId).HasName("PK__Roles__C4B2784006AAEF4F");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.SectionId).HasName("PK__Sections__80EF0872A398CD0C");

            entity.Property(e => e.SectionCreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SectionName)
                .IsRequired()
                .HasMaxLength(500);
            entity.Property(e => e.SectionUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreateCourse).WithMany(p => p.Sections)
                .HasForeignKey(d => d.CreateCourseId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Sections_CreateCourse");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Sections)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sections_Users");
        });

        modelBuilder.Entity<SubCategory>(entity =>
        {
            entity.HasKey(e => e.SubCategoriesId).HasName("PK__SubCateg__537FEC9FF49BC859");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.SubCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SubCatego__Categ__1DB06A4F");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07DF238B7B");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D1053415CD239B").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.PasswordHash).IsRequired();
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.ResetCode).HasMaxLength(10);
            entity.Property(e => e.ResetCodeExpiration).HasColumnType("datetime");
            entity.Property(e => e.RolesId).HasDefaultValue(1);
            entity.Property(e => e.UserStatus).HasDefaultValue(true);

            entity.HasOne(d => d.Roles).WithMany(p => p.Users)
                .HasForeignKey(d => d.RolesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");
        });

        modelBuilder.Entity<UserInterest>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.CategoryId, e.SubCategoryId }).HasName("PK__UserInte__AE3EE1B75B2C7444");

            entity.HasOne(d => d.Category).WithMany(p => p.UserInterests)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserInter__Categ__1F98B2C1");

            entity.HasOne(d => d.SubCategory).WithMany(p => p.UserInterests)
                .HasForeignKey(d => d.SubCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserInter__SubCa__2180FB33");

            entity.HasOne(d => d.User).WithMany(p => p.UserInterests)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserInter__UserI__236943A5");
        });

        modelBuilder.Entity<UserWishlistAndVisited>(entity =>
        {
            entity.HasKey(e => e.UserInteractionId);

            entity.ToTable("UserWishlistAndVisited");

            entity.Property(e => e.CourseVisitedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CourseWishlistDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.CreateCourse).WithMany(p => p.UserWishlistAndVisiteds)
                .HasForeignKey(d => d.CreateCourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserWishlistAndVisited_CreateCourse");

            entity.HasOne(d => d.User).WithMany(p => p.UserWishlistAndVisiteds)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserWishlistAndVisited_Users");
        });

        modelBuilder.Entity<Video>(entity =>
        {
            entity.HasKey(e => e.VideoId).HasName("PK__Videos__BAE5126AE0A953E1");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FileType).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.VideoDuration).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.VideoName)
                .IsRequired()
                .HasMaxLength(255);

            entity.HasOne(d => d.Section).WithMany(p => p.Videos)
                .HasForeignKey(d => d.SectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Videos__SectionI__2645B050");

            entity.HasOne(d => d.User).WithMany(p => p.Videos)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Videos_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
