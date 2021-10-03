namespace Students
{
    using System;
    using System.Linq;
    using Microsoft.OpenApi.Any;

    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;

    public class EnumSchemaFilter : ISchemaFilter
    {
        #region Methods

        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (!context.Type.IsEnum)
            {
                return;
            }
            schema.Enum.Clear();
            schema.Type = PrimitiveType.String.ToString("G").ToLowerInvariant();
            schema.Format = schema.Type;
            var values = Enum.GetNames(context.Type)
                .Select(value => new OpenApiString(value))
                .ToList();
            values.ForEach(value =>
            {
                schema.Enum.Add(value);
            });
        }

        #endregion Methods
    }
}
