using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace UserInfo.middlewares
{
    public class sampleResourceMiddleware : IResourceFilter
    {
      
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine($"[custom middleware] {context.ActionDescriptor.DisplayName} executing...");
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"[custom middleware] {context.ActionDescriptor.DisplayName} executed...");
        }
    }
}
