using ecommerce.data.CustomerMapper;
using ecommerce.repo.Execution;
using ecommerce.repo.Interface;
using ecommerce.service.Execution;
using ecommerce.service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace ecommerce.api
{
    public static class RegisterAllServices
    {
        public static void RegisterServiceLayer(IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IUserService, UserService>();
        }

        public static void RegisterRepoLayer(IServiceCollection services)
        {
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
        }

        public static void RegisterDtosMappings(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CustomerMapping));
        }
    }
}
