﻿using GraphQL.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Products.Application.configurations;
using Products.Infrastructure.Configuration;
using Products.Infrastructure.Persistence.Context;

namespace Products.Persentation.Configurations;

public static class AddConfigurationService
{
    public static IServiceCollection AddCustomService(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ProductContext>(option =>
        {
            option.UseNpgsql(builder.Configuration.GetConnectionString("ProductsString"));
        });
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen(c =>
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Products", Version = "v1" })
        );
        builder.Services.AddInfrastructureServices();
        builder.Services.AddApplicationServices();


        builder.Services.
            AddGraphQL().
            AddSystemTextJson();

        return builder.Services;
    }

}
