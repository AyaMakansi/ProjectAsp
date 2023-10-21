using Microsoft.EntityFrameworkCore;
using ProjectAsp.Services.branch;
using ProjectAsp.Services.company;
using ProjectAsp.Services.operation;
using ProjectAsp.Services.product;

var builder = WebApplication.CreateBuilder(args);
var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseNpgsql(connectionstring));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSwaggerGen(option=>
    option.CustomSchemaIds(t=>$"{t.FullName!.Replace("+",".")}"));
builder.Services.AddTransient<ICompanyServices, CompanyServices>();
builder.Services.AddTransient<IBranchServices, BranchServices>();
builder.Services.AddTransient<IProductServices,ProductServices>();
builder.Services.AddTransient<IOperationServices, OpeationsServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();