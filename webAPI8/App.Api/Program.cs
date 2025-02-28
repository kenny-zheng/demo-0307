using App.Api;
using Microsoft.OpenApi.Models;
using NLog.Web;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//NLog
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
// use nlog or Serilog
//builder.Host.UseSerilog((ctx, config) =>
//{
//    //config.WriteTo.File("Log\\api.log", rollingInterval: RollingInterval.Day);
//    //https://github.com/serilog/serilog-sinks-elasticsearch#handling-errors
//    config.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(AppSettingHelper.GetSection("ELKUrl").Value))
//    {
//        IndexFormat = "api-elk-index-{0:yyyy.MM}",
//        AutoRegisterTemplate = true,
//        OverwriteTemplate = true,
//        DetectElasticsearchVersion = true,
//        AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
//        NumberOfReplicas = 1,
//        NumberOfShards = 2,
//        BufferBaseFilename = "./buffer",
//        RegisterTemplateFailure = RegisterTemplateRecovery.FailSink,
//        FailureCallback = e => Console.WriteLine("Unable to submit event " + e.MessageTemplate),
//        EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog |
//                       EmitEventFailureHandling.WriteToFailureSink |
//                       EmitEventFailureHandling.RaiseCallback,
//        //�׶}���Ҧ�ñ����
//        ModifyConnectionSettings = c => c
//                    .ConnectionLimit(-1)
//                    .ServerCertificateValidationCallback((o, certificate, arg3, arg4) => { return true; }),
//        MinimumLogEventLevel = Serilog.Events.LogEventLevel.Error

//    });
//});
builder.Host.UseNLog();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});
builder.Services.AddControllers(config =>
{
    config.Filters.Add(typeof(GlobalExceptionFilter));
    config.Filters.Add(typeof(ValidateModelAttribute));
    config.Filters.Add(typeof(ValidateJsonPropertiesFilter));
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description =
"JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityDefinition("reCAPTCHA", new OpenApiSecurityScheme
    {
        Description =
"Google ReCaptcha",
        Name = "reCAPTCHA",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "reCAPTCHA"
                            },
                            Scheme = "oauth2",
                            Name = "reCAPTCHA",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
    // Ū�� XML �ɮײ��� API ����
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

});
builder.Services.AddEntityFrameworkSqlServer();
builder.Services.AddScoped<IBase, Base>();
builder.Services.AddScoped<IUser, User>();
builder.Services.AddScoped<IUserGroup, UserGroup>();
builder.Services.AddScoped<IAuthService, App.BLL.AuthService>();
//#AutoID
//builder.Services.AddScoped<ISample, Sample>();

//���oIP Accessor
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();




var app = builder.Build();
app.UseMiddleware<RequestBodyCachingMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors("CorsPolicy");
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.MapControllers();

app.Run();
