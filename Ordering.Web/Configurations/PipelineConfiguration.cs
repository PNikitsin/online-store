﻿using Ordering.Web.Grpc;
using Ordering.Web.Middleware;

namespace Ordering.Web.Configurations
{
    public static class PipelineConfiguration
    {
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.MapGrpcService<GrpcUserService>();

            return app;
        }
    }
}