using Algolia.Search.Clients;
using Letgo.BusinessLayer.API.Abstract;
using Letgo.BusinessLayer.API.Concrete;
using Letgo.BusinessLayer.Db.Abstract;
using Letgo.BusinessLayer.Db.Concrete;
using Letgo.DataAccess.DbRepositories.Abstract;
using Letgo.DataAccess.DbRepositories.Concrete;
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

            services.AddScoped<IFavoriteAdvertRepository, FavoriteAdvertRepository>();
            services.AddScoped<IFavoriteAdvertManager, FavoriteAdvertManager>();

            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IReviewManager, ReviewManager>();

            services.AddScoped<IAdvertRepositoryDb, AdvertRepositoryDb>();
            services.AddScoped<IAdvertManagerDb, AdvertManagerDb>();

            services.AddScoped<IAdvertStatusRepositoryDb, AdvertStatusRepositoryDb>();
            services.AddScoped<IAdvertStatusManagerDb, AdvertStatusManagerDb>();

            services.AddScoped<IFavoriteAdvertRepositoryDb, FavoriteAdvertRepositoryDb>();
            services.AddScoped<IFavoriteAdvertManagerDb, FavoriteAdvertManagerDb>();

            services.AddScoped<IReviewRepositoryDb, ReviewRepositoryDb>();
            services.AddScoped<IReviewManagerDb, ReviewManagerDb>();

            return services;
        }
    }
}
