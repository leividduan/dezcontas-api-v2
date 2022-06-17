using AutoMapper;
using DezContas.Infra.IoC;
using PlayPedidos.API.DTOs.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

#region [AutoMapper]

var mappingConfig = new MapperConfiguration(mc =>
{
	mc.AddProfile(new MappingProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MigrateDatabase();
app.Run();
