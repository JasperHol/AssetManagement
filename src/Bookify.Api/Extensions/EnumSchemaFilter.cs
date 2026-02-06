using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AssetManagement.Api.Extensions;

public sealed class EnumSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (!context.Type.IsEnum)
            return;

        schema.Enum.Clear();

        var enumNames = Enum.GetNames(context.Type);
        var enumValues = Enum.GetValues(context.Type).Cast<int>();

        foreach (var (value, name) in enumValues.Zip(enumNames))
        {
            schema.Enum.Add(new OpenApiString($"{value}: {name}"));
        }
    }
}
