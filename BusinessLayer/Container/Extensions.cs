using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {

            builder.Services.AddScoped<IServiceService, ServiceManager>();
            builder.Services.AddScoped<IServiceDal, EfServiceDal>();
            builder.Services.AddScoped<ITeamService, TeamManager>();
            builder.Services.AddScoped<ITeamDal, EfTeamDal>();
            builder.Services.AddScoped<IAnnouncementService, AnnouncementManager>();
            builder.Services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
            builder.Services.AddScoped<IImageService, ImageManager>();
            builder.Services.AddScoped<IImageDal, EfImageDal>();
            builder.Services.AddScoped<IAddressService, AddressManager>();
            builder.Services.AddScoped<IAddressDal, EfAddressDal>();
            builder.Services.AddScoped<IContactService, ContactManager>();
            builder.Services.AddScoped<IContactDal, EfContactDal>();
            builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
            builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
            builder.Services.AddScoped<IAboutService, AboutManager>();
            builder.Services.AddScoped<IAboutDal, EfAboutDal>();
            builder.Services.AddScoped<IAdminService, AdminManager>();
            builder.Services.AddScoped<IAdminDal, EfAdminDal>();
        }


    }
}
