using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using StoreAutoMVC.Entity;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace StoreAutoMVC.Sevices
{
    public class ModelNameParameterFilterService : IParameterFilter
    {
        readonly IServiceScopeFactory _serviceScopeFactory;

        public ModelNameParameterFilterService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
        {
            if (parameter.Name.Equals("modelName", StringComparison.InvariantCultureIgnoreCase))
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<DBContext>(); 
                    IEnumerable<string> modelNames = dbContext.Models.Select(model => model.NameModel).ToList();

                    parameter.Schema.Enum = modelNames.Select(name => new OpenApiString(name)).ToList<IOpenApiAny>();

                    parameter.Required = true;
                }
            }
        }
    }
}
