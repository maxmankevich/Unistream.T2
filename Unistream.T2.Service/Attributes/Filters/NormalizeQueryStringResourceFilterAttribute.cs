using Microsoft.AspNetCore.Mvc.Filters;

namespace Unistream.T2.Service.Attributes.Filters
{
    public class NormalizeQueryStringResourceFilterAttribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            // изменяем обработку символа "+" в QueryString по умолчанию.
            var qs = context.HttpContext.Request.QueryString;
            context.HttpContext.Request.QueryString = new QueryString(qs.Value?.Replace("+", "%2b"));
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }
}