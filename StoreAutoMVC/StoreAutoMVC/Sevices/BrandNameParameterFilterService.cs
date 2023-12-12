using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using StoreAutoMVC.Entity;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace StoreAutoMVC.Sevices
{
    public class BrandNameParameterFilterService : IParameterFilter
    {
        readonly IServiceScopeFactory _serviceScopeFactory;

        public BrandNameParameterFilterService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
        {
            if (parameter.Name.Equals("brandName", StringComparison.InvariantCultureIgnoreCase))
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<DBContext>();
                    IEnumerable<string> brandNames = dbContext.Brands.Select(brand => brand.NameBrand).ToList();

                    parameter.Schema.Enum = brandNames.Select(name => new OpenApiString(name)).ToList<IOpenApiAny>();

                    parameter.Required = true;
                }
            }
        }
    }
}
