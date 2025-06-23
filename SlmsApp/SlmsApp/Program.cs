using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using SlmsAppBusiness.CategoriesServices;
using SlmsAppBusiness.CourseCardsServices;
using SlmsAppBusiness.CourseEnrollmentServices;
using SlmsAppBusiness.CoursesServices;
using SlmsAppBusiness.FaqSevicees;
using SlmsAppBusiness.GetCoursesServices;
using SlmsAppBusiness.LessonsOrderServices;
using SlmsAppBusiness.ProfileService;
using SlmsAppBusiness.QuizService;
using SlmsAppBusiness.Roles;
using SlmsAppBusiness.SectionServicesBuss;
using SlmsAppBusiness.UserRegistrationService;
using SlmsAppBusiness.UserWishlistServices;
using SlmsAppBusiness.VideoServices;
using SlmsAppDataAccess.Categories;
using SlmsAppDataAccess.CourseCards;
using SlmsAppDataAccess.CourseContent;
using SlmsAppDataAccess.CourseEnrollmentRepo;
using SlmsAppDataAccess.Faq;
using SlmsAppDataAccess.GetCourses;
using SlmsAppDataAccess.InstructorCourses;
using SlmsAppDataAccess.LessonsOrderRepo;
using SlmsAppDataAccess.Models;
using SlmsAppDataAccess.MyProfiles;
using SlmsAppDataAccess.Quiz;
using SlmsAppDataAccess.Roels;
using SlmsAppDataAccess.UserRegistration;
using SlmsAppDataAccess.UserWishlist;
using SlmsAppDataAccess.VideoRepos;
using SlmsAppUtilities.Email;
using SlmsAppUtilities.JwtToken;
using SlmsAppUtilities.Mapping;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.SetIsOriginAllowed(origin =>
        {
            if (!origin.StartsWith("http://localhost:"))
                return false;

            var portStr = origin.Substring("http://localhost:".Length);
            return int.TryParse(portStr, out var port) && port >= 1024 && port <= 49151;
        })
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
});


builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 2040 * 1024 * 1024;
});

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 2040 * 1024 * 1024;
});


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SlmsAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Register repositories
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ISectionRepository, SectionRepository>();
builder.Services.AddScoped<ICreateQuizRepository, CreateQuizRepository>();
builder.Services.AddScoped<IQuizQuestionsRepository, QuizQuestionsRepository>();
builder.Services.AddScoped<IQuizAnswerRepository, QuizAnswerRepository>();
builder.Services.AddScoped<IMyProfileRepository, MyProfileRepository>();
builder.Services.AddScoped<IVideoRepo, VideoRepo>();
builder.Services.AddScoped<ILessonsOrderRepository, LessonsOrderRepository>();
builder.Services.AddScoped<ICourseSectionsOrderRepository, CourseSectionsOrderRepository>();
builder.Services.AddScoped<ICourseFaqRepository , CourseFaqRepository>();
builder.Services.AddScoped<IGetCourseRepository, GetCourseRepository>();
builder.Services.AddScoped<ICourseEnrollmentRepository, CourseEnrollmentRepository>();
builder.Services.AddScoped<IUserWishlistRepository, UserWishlistRepository>();  
builder.Services.AddScoped<ICourseCardsRepository, CourseCardsRepository>();

// Register services
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddScoped<ICreateQuizService, CreateQuizService>();
builder.Services.AddScoped<IQuizQuestionsBusiness,  QuizQuestionsBusiness>();
builder.Services.AddScoped<IQuizAnswerService, QuizAnswerService>();
builder.Services.AddScoped<IMyProfileService, MyProfileService>();
builder.Services.AddScoped<IvideoService, VideoService>();
builder.Services.AddScoped<ILessonsOrderService, LessonsOrderService>();
builder.Services.AddScoped<ICourseSectionsOrderService, CourseSectionsOrderService>();
builder.Services.AddScoped<ICourseFaqService, CourseFaqService>();
builder.Services.AddScoped<IGetCourseService, GetCourseService>();
builder.Services.AddScoped<ICourseEnrollmentService, CourseEnrollmentService>();
builder.Services.AddScoped<IUserWishlistService, UserWishlistService>();
builder.Services.AddScoped<ICourseCardsService, CourseCardsService>();



// Register JwtService with the secret key
builder.Services.AddScoped<IJwtService>(provider =>
{
    // Get the secret key from configuration
    var secretKey = builder.Configuration.GetValue<string>("Jwt:SecretKey");

    // Get the SlmsAppContext from the DI container (it should already be registered)
    var context = provider.GetRequiredService<SlmsAppContext>();

    // Return the JwtService with both parameters
    return new JwtService(secretKey, context);
});


// Register AutoMapper profiles
builder.Services.AddAutoMapper(typeof(RoleMappingProfile));
builder.Services.AddAutoMapper(typeof(CategoryMappingProfile));
builder.Services.AddAutoMapper(typeof(CourseMappingProfile));
builder.Services.AddAutoMapper(typeof(SectionMappingProfile));
builder.Services.AddAutoMapper(typeof(QuizMappingProfile));
builder.Services.AddAutoMapper(typeof(VideoMappingProfile));
builder.Services.AddAutoMapper(typeof(MyProfileMappingProfile));
builder.Services.AddAutoMapper(typeof(FaqMappingProfile));
builder.Services.AddAutoMapper(typeof(CourseEnrollmentMappingProfile));
builder.Services.AddAutoMapper(typeof(UserWishlistAndVisitedMappingProfile));
builder.Services.AddAutoMapper(typeof(CourseCardMappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowAngularApp");


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
