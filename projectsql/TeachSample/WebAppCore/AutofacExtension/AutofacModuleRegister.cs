using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using WebAppCore.AutofacExtensions;
using System.Reflection;
using WebAppCore.ViewModels;
using WebAppCore.Service;
using WebAppCore.Service.Samples;
using WebAppCore.DbModel;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using IRepository;
using Repository;

namespace WebAppCore.AutofacExtensions
{
    public class AutofacModuleRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //ModuleRegister(builder);
            SingleRegister(builder);
        }

        /// <summary>
        /// /*****下面是按照模块注入的方法*****/
        ///  //调用程序集注册存入方法
        /// </summary>
        protected void ModuleRegister(ContainerBuilder builder)
        {
            //注册Service
            var assemblysServices = Assembly.Load("WebAppCore.Services");
            builder.RegisterAssemblyTypes(assemblysServices)
                .InstancePerDependency()//瞬时单例
               .AsImplementedInterfaces()//自动以其实现的所有接口类型暴露（包括IDisposable接口）
                   .EnableInterfaceInterceptors(); //引用Autofac.Extras.DynamicProxy;

            //注册Repository
            //var assemblysRepository = Assembly.Load("Web.Core.Repository");
            //builder.RegisterAssemblyTypes(assemblysRepository)
            //    .InstancePerDependency()//瞬时单例
            //   .AsImplementedInterfaces()//自动以其实现的所有接口类型暴露（包括IDisposable接口）
            //       .EnableInterfaceInterceptors(); //引用Autofac.Extras.DynamicProxy;
        }

        protected void SingleRegister(ContainerBuilder builder)
        {
            //下面是service
			//builder.RegisterType<LoginService>().As<ILoginService>();
			builder.RegisterType<SysDictTypeService>().As<ISysDictTypeService>();
			builder.RegisterType<SysDictDatumService>().As<ISysDictDatumService>();
			builder.RegisterType<SysUsersService>().As<ISysUsersService>();
			builder.RegisterType<QueryInfoService>().As<IQueryInfoService>();
			builder.RegisterType<SysDeptsService>().As<ISysDeptsService>();
			builder.RegisterType<SysRolesService>().As<ISysRolesService>();
			builder.RegisterType<SysMenusService>().As<ISysMenusService>();
			builder.RegisterType<SysPostsService>().As<ISysPostsService>();
			builder.RegisterType<SysApisService>().As<ISysApisService>();
			builder.RegisterType<SysConfigsService>().As<ISysConfigsService>();			
			builder.RegisterType<FalldownDeviceService>().As<IFalldownDeviceService>();
            builder.RegisterType<ProjectInfoService>().As<IProjectInfoService>();
            builder.RegisterType<AuthService>().As<AuthService>(); //没写IAuthService
			builder.RegisterType<AiAppService>().As<IAiAppService>();
			builder.RegisterType<ColorDiffService>().As<IColorDiffService>();

			//下面是DAL
			builder.RegisterType<SysDictTypeDAL>().As<ISysDictTypeDAL>();			
			builder.RegisterType<SysDictDatumDAL>().As<ISysDictDatumDAL>();			
            builder.RegisterType<QueryInfoDAL>().As<IQueryInfoDAL>();			
			builder.RegisterType<SysUsersDAL>().As<ISysUsersDAL>();
			builder.RegisterType<SysDeptsDAL>().As<ISysDeptsDAL>();			
			builder.RegisterType<SysRoleDeptDAL>().As<ISysRoleDeptDAL>();			
			builder.RegisterType<SysMenusDAL>().As<ISysMenusDAL>();			
			builder.RegisterType<SysRolesDAL>().As<ISysRolesDAL>();			
			builder.RegisterType<SysRoleMenusDAL>().As<ISysRoleMenusDAL>();
			builder.RegisterType<CasbinRuleDAL>().As<ICasbinRuleDAL>();
			builder.RegisterType<SysPostsDAL>().As<ISysPostsDAL>();
			builder.RegisterType<SysApisDAL>().As<ISysApisDAL>();
			builder.RegisterType<SysConfigsDAL>().As<ISysConfigsDAL>();
			builder.RegisterType<FalldownDeviceDAL>().As<IFalldownDeviceDAL>();
            builder.RegisterType<ProjectInfoDAL>().As<IProjectInfoDAL>();
            builder.RegisterType<ColorDiffDAL>().As<IColorDiffDAL>();


			builder.RegisterType<SinglePerson>();

            #region 服务类型支持属性注入，红色表示是对属性注入的支持，哪个类型需要属性注入，在注册的时候使用 PropertiesAutowired()方法，里面参数是属性选择器。
            builder.RegisterType<PropertyPerson>().As<IPropertyPerson>().PropertiesAutowired(new CustomPropertySelector());
            builder.RegisterType<PropertyTwoPerson>().As<IPropertyTwoPerson>();
            //builder.RegisterType<PropertyThreePerson>().As<IPropertyThreePerson>();
            builder.RegisterType<SinglePerson>();

            #endregion

            #region AOP支持，红色标注的是关键实现。
            builder.RegisterType<AOPPerson>().As<IAOPPerson>().EnableInterfaceInterceptors();
            //builder.RegisterType<AOPClassPerson>().As<IAOPClassPerson>().EnableClassInterceptors(new ProxyGenerationOptions()
            //{
            //    Selector = new CustomInterceptorSelector()
            //});
            //builder.RegisterType<AOPCachePerson>().As<IAOPCachePerson>().EnableClassInterceptors();
            builder.RegisterType<CustomClassInterceptor>();
            builder.RegisterType<CustomInterfaceInterceptor>();
            //builder.RegisterType<CustomCacheInterceptor>();

            #endregion

            #region 单接口多实例
            //builder.RegisterType<MultiPerson>().Keyed<IMultiPerson>("MultiPerson");
            //builder.RegisterType<MultiTwoPerson>().Keyed<IMultiPerson>("MultiTwoPerson");
            //builder.RegisterType<MultiThreePerson>().Keyed<IMultiPerson>("MultiThreePerson");

            #endregion

            #region 让控制器支持属性注入
            var controllerBaseType = typeof(ControllerBase);
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
            .Where(t => controllerBaseType.IsAssignableFrom(t) && controllerBaseType != t)
            .PropertiesAutowired(new CustomPropertySelector());
            builder.RegisterType<ServiceBasedControllerActivator>().As<IControllerActivator>();

            #endregion
        }
    }
}