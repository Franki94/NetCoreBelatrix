using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Belatrix.WebApi.Filters
{
    public class CustomerResultFilterAttribute : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var resultFromAction = context.Result as ObjectResult;

            if (resultFromAction?.Value == null
                || resultFromAction.StatusCode < (int)HttpStatusCode.OK
                || resultFromAction.StatusCode >= (int)HttpStatusCode.MultipleChoices)
            {
                await next();
                return;
            }
            resultFromAction.Value = Mapper.Map<IEnumerable<ViewModels.Customer>>(resultFromAction.Value);
            await next();
        }
    }
}
