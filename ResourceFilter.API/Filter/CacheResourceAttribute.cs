using Microsoft.AspNetCore.Mvc;

namespace ResourceFilter.API.Filter
{
    /// <summary>
    /// CacheAttribute
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.TypeFilterAttribute" />
    public class CacheResourceAttribute :TypeFilterAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CacheResourceAttribute"/> class.
        /// </summary>
        public CacheResourceAttribute() : base(typeof(CacheResourceFilter))
        {

        }
    }
}
