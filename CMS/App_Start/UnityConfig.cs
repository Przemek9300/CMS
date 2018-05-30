using CMS.CMSContext;
using CMS.Controllers;
using CMS.Models;
using CMS.Repositories;
using CMS.Services;
using CMS.UnitOfWork;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace CMS
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService
            container.RegisterType<IRoleSerivce, RoleSerivce>();
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<RolesAdminController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            container.RegisterType<IPostRepository, PostRepository>();
            container.RegisterType<IGeneralSettingsRepository, GeneralSettingsRepository>();
            container.RegisterType<ITagRepository, TagRepository>();
            container.RegisterType<IGeneralSettingsSerivce, GeneralSettingsService>();
            container.RegisterType<IUoW, UoW>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }
    }
}