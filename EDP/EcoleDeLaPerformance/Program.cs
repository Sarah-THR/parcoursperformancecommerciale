using EcoleDeLaPerformance.Ui.Interfaces;
using EcoleDeLaPerformance.Ui.Services;
using MudBlazor.Services;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using MudBlazor;
using Microsoft.AspNetCore;
using EcoleDeLaPerformance.Ui.Helper;
using ApexCharts;
using Microsoft.AspNetCore.Http.Features;
using BlazorDownloadFile;
var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddEnvironmentVariables();

var initialScopes = builder.Configuration.GetValue<string>("DownstreamApi:Scopes")?.Split(' ');

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"))
        .EnableTokenAcquisitionToCallDownstreamApi(initialScopes)
            .AddMicrosoftGraph(builder.Configuration.GetSection("DownstreamApi"))
            .AddInMemoryTokenCaches();

builder.Services.AddControllersWithViews()
    .AddMicrosoftIdentityUI();

builder.Services.AddAuthorization(options =>
{
    //options.FallbackPolicy = options.DefaultPolicy;
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
    config.SnackbarConfiguration.VisibleStateDuration = 5000;
});
builder.Services.AddMudServices();
builder.Services.AddMudBlazorDialog();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISignedContractService, SignedContractService>();
builder.Services.AddScoped<IBriefNoteService, BriefNoteService>();
builder.Services.AddScoped<IWeekService, WeekService>();    
builder.Services.AddScoped<IHalfDayPlanningService, HalfDayPlanningService>();    
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<ITaskPlanningService, TaskPlanningService>();
builder.Services.AddScoped<IContractService, ContractService>();
builder.Services.AddScoped<StateContainerService>();
builder.Services.AddScoped<CRMService>();
builder.Services.AddScoped<MailHelper>();
builder.Services.AddSingleton<PdfService>();
builder.Services.AddBlazorDownloadFile();

builder.WebHost.UseSentry(options =>
{
    options.Dsn = "https://d3206b5ba6c2079d67ae5da39880a79c@sentry.xefi.fr/4";
    options.Debug = true;
    options.AutoSessionTracking = true;
    options.IsGlobalModeEnabled = false;
    options.TracesSampleRate = 0.1;
});

//redirect to home after signout
builder.Services.Configure<OpenIdConnectOptions>(OpenIdConnectDefaults.AuthenticationScheme, options =>
{
    options.Events = new OpenIdConnectEvents
    {
        OnRedirectToIdentityProviderForSignOut = context =>
        {
            context.ProtocolMessage.PostLogoutRedirectUri = context.Request.Scheme + "://" + context.Request.Host + "/";
            return Task.FromResult(0);
        }
    };
});

var app = builder.Build();

var contentRootPath = app.Environment.ContentRootPath;
Aspose.Words.License license = new Aspose.Words.License();
try
{
    license.SetLicense(contentRootPath + @"\wwwroot\License\Aspose.Wordsfor.NET.lic");
    Console.WriteLine("License set successfully.");
}
catch (Exception e)
{
    Console.WriteLine("\nThere was an error setting the license: " + e.Message);
}

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.MapRazorPages();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
