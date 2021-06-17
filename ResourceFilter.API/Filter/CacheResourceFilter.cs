using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;

namespace ResourceFilter.API.Filter
{
    /// <summary>
    /// CacheResourceFilter
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IResourceFilter" />
    public class CacheResourceFilter : IResourceFilter
    {
        private static readonly Dictionary<string, object> _cache = new Dictionary<string, object>();
        string _cacheKey = string.Empty;

        /// <summary>
        /// Executes the resource filter. Called before execution of the remainder of the pipeline.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext" />.</param>
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            _cacheKey = context.HttpContext.Request.Path.ToString();
            if (_cache.ContainsKey(_cacheKey))
            {
                _cache.TryGetValue(_cacheKey, out object cachedObject);
                var cachedValue = cachedObject as object;
                if (cachedValue != null)
                {
                    context.Result = new ObjectResult(cachedObject);                    
                }
            }
        }

        /// <summary>
        /// Executes the resource filter. Called after execution of the remainder of the pipeline.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ResourceExecutedContext" />.</param>
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            if (!string.IsNullOrEmpty(_cacheKey) && !_cache.ContainsKey(_cacheKey))
            {
                var result = context.Result as ObjectResult;
                if (result != null)
                {
                    _cache.Add(_cacheKey, result.Value);
                }
            }
        }
    }
}
