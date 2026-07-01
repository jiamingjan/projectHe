using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebAppCore.DbModel;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using WebAppCore.AutofacExtensions;
using Microsoft.AspNetCore.Mvc.Controllers;
using WebAppCore.Profiles;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebAppCore.ViewModels;
using WebAppCore.Service;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

//add by helm start:
//写到这句下面
//⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇

var ConnString = builder.Configuration["ConnectionStrings:MySQLConnection"];
//注入
//builder.Services.AddDbContext<LbRadarMngContext>(x => x.UseMySql(ConnString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.28-mysql")));
//LbRadarMngContext.dbconnString = ConnString!;
//builder.Services.AddDbContext<LbRadarMngContext>();

builder.Services.AddDbContext<VueworkdbTeachContext>(options =>
	options.UseMySql(ConnString, ServerVersion.Parse("9.2.0-mysql")));

//stock_recommendContext.dbconnString = ConnString!;
//builder.Services.AddDbContext<VueworkdbTeachContext>();
//在dbcontext中注入：
//add by helm end

//添加AutoMapper服务注入：
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

// Add services to the container.
builder.Services.AddControllersWithViews();

//session
//builder.Services.AddSession();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(120);//session超时时间
    options.Cookie.HttpOnly = false;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(option =>
{
	option.SwaggerDoc("v1", new OpenApiInfo
	{
		Title = "My API",
		Version = "v1",
		Description = "A simple example API"
	});
});

//获取鉴权配置
//⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇
//依赖注入
builder.Services.AddTransient<AuthService>();
builder.Services.AddOptions();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

//启用功能
builder.Services.AddAuthentication();//启用身份验证功能--认证主要是指，用户米、密码是否正确
builder.Services.AddAuthorization();//启用授权功能---授权主要是看有没有权限

//读取配置文件的数据
//这儿自定义了一个JwtSettings类，类里面的属性要与配置文件中的一致
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
GlobalStateService.jwtSettings = jwtSettings; //暂时先这样处理
if (jwtSettings != null)
{
	//builder.Services.AddSingleton<GlobalStateService>();//放入全局状态，以便以后使用
	builder.Services.AddAuthentication(options =>
	{
		// 设置默认的认证方案为 JWT
		options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
		options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	})
.AddJwtBearer(options =>
{
	// 配置 JWT 认证参数
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = false, // 验证令牌的签发者
		ValidateAudience = false, // 验证令牌的接收者
		ValidateLifetime = false, // 验证令牌的有效期
		ValidateIssuerSigningKey = true, // 验证签名密钥
		 //ValidIssuer = jwtSettings.Issuer, // 设定合法的签发者
		//ValidAudience = jwtSettings.Audience, // 设定合法的接收者	
		
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)) // 设置签名密钥
	};
});

	//启动鉴权
	//声明指定名称的认证策略
	builder.Services.AddAuthorization(options =>
	{
		//定义一个名为 "Admin" 的授权策略。
		//该策略要求 JWT 令牌中必须包含一个 "userRole" 声明，其值为 "admin"。
		//options.AddPolicy("Admin", policy => policy.RequireClaim("userRole", "admin"));
		//定义一个名为 "User" 的授权策略。
		//该策略要求 JWT 令牌中必须包含一个 "userRole" 声明，其值为 "user"。
		//options.AddPolicy("User", policy => policy.RequireClaim("userRole", "user"));
	});
}
//⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇⬇



#region 整合 Autofac
//注入Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
.ConfigureContainer<ContainerBuilder>(builder =>
{   
    builder.RegisterModule(new AutofacModuleRegister());
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();	
}

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	//app.UseSwaggerUI();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
	});
}
	

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//启用跨域
app.UseCors(builder =>
{
	builder.AllowAnyOrigin()
		   .AllowAnyMethod()
		   .AllowAnyHeader();
});

app.UseAuthentication();// 启用身份验证,即鉴权
app.UseAuthorization();// 启用授权 / 批准，这两个中间件的位置不能错，必须是：鉴权在前。

//session
app.UseSession();

//支持2级
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//支持模块名（3级）//例如/system/dict/type?dictType=sys_user_sex  其中dict是Controller
app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    pattern: "{businessModel}/{controller=Home}/{action=Index}/{id?}");

//支持模块名+子模块（4级）//例如system/dict/data/type?dictType=sys_user_sex 其中dict是Controller，type是接口函数
app.MapControllerRoute(
	name: "default",
	//pattern: "{controller=Home}/{action=Index}/{id?}");
	pattern: "{businessModel}/{controller=Home}/{area=Model}/{action=Index}/{id?}");


//登录或者session过期判断
//app.UseMiddleware<SpMiddleware>();

app.Run();
