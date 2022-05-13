using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SISL.Core.Constants;
using SISL.Core.DTOs;
using SISL.Core.DTOs.Response;

namespace SISL.API.Filters
{
    public class ModelStateValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                //context.Result = new BadRequestObjectResult(context.ModelState);

                context.Result = new BadRequestObjectResult(
                    new GenericApiResponse<ModelStateDictionary>()
                    {
                        ResponseCode = RESPONSE_CODE.FAILURE,
                        ResponseDescription = "Some required fields were empty",
                        Data = context.ModelState
                    });

                await Task.FromResult(false);
                return;
            }

            await next();
        }
    }
}