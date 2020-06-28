using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectPromotionEngine.CalculatePromotionPrice;
using ProjectPromotionEngine.CalculatePromotionPrice.PriceCaluclatorforSku;

namespace ProjectPromotionEngine
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddSingleton<IFinalPriceCalculatorService, FinalPriceCalculator>();
            services.AddSingleton<IModulePriceCalculator, ModulePriceCalculator>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0).ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext => {
                    //CustomErrorResponse is method that gets model validation errors     
                    //using ActionContext creates customized response,  
                    // and converts invalid model state dictionary    

                    return CustomErrorResponse(actionContext);
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        private BadRequestObjectResult CustomErrorResponse(ActionContext actionContext)
        {
            //BadRequestObjectResult is class found Microsoft.AspNetCore.Mvc and is inherited from ObjectResult.    
            //Rest code is linq.    
            return new BadRequestObjectResult(actionContext.ModelState
             .Where(modelError => modelError.Value.Errors.Count > 0)
             .Select(modelError => new CustomError
             {
                 ErrorField = modelError.Key,
                 ErrorDescription = modelError.Value.Errors.FirstOrDefault().ErrorMessage
             }).ToList());
        }
    }
}
