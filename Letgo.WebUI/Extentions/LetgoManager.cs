using Algolia.Search.Clients;
using Letgo.BusinessLayer.Abstract;
using Letgo.BusinessLayer.Concrete;
using Letgo.DataAccess.Repositories.Abstract;
using Letgo.DataAccess.Repositories.Concrete;

namespace Letgo.WebUI.Extentions
{
    public static class LetgoManager
    {
        public static IServiceCollection AddLetgoServices(this IServiceCollection services)
        {
            services.AddScoped<IAdvertRepository, AdvertRepository>();
            services.AddScoped<IAdvertManager, AdvertManager>();

            services.AddScoped<IAdvertStatusRepository, AdvertStatusRepository>();
            services.AddScoped<IAdvertStatusManager, AdvertStatusManager>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryManager, CategoryManager>();

            services.AddScoped<IFavoriteAdvertRepository, FavoriteAdvertRepository>();
            services.AddScoped<IFavoriteAdvertManager, FavoriteAdvertManager>();

            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IReviewManager, ReviewManager>();

            return services;
        }
    }
}
