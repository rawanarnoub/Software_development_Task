using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using WebApplication4.Data;
using WebApplication4.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddAuthentication(option =>
{
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(option =>
{
    var secretKey = Encoding.UTF8.GetBytes(builder.Configuration["Auth:secretKey"]);

    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true, //validate token is not expired
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        ValidIssuer = builder.Configuration["Auth:issuer"],
        ValidAudience = builder.Configuration["Auth:audience"]
    };
});
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("testAuthorization", policyBuilder =>
    {
        policyBuilder.RequireAuthenticatedUser();
        policyBuilder.RequireClaim(ClaimTypes.Name, "Rawan");
        policyBuilder.RequireClaim(ClaimTypes.Email, "rawan@example.com");
        //policyBuilder.RequireClaim(ClaimTypes.SubscriptionType, "software");
        policyBuilder.RequireClaim(ClaimTypes.Role, "Eng");
    });

    option.AddPolicy("testAuthorization2", policyBuilder =>
    {
        policyBuilder.RequireClaim(ClaimTypes.Name, "Rawan");
        //policyBuilder.RequireClaim(ClaimTypes.SubscriptionType, "software");
    });

});
builder.Services.AddTransient<ITokenService, TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();