using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace UserInfo.middlewares
{
    public class actionfilter : ActionFilterAttribute
    {
      
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           
            Console.WriteLine($"[custom ActionFilter] {context.ActionDescriptor.DisplayName} executing...");
        }

    public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"[custom ActionFilter] {context.ActionDescriptor.DisplayName} executed...");
        }


    }
}
