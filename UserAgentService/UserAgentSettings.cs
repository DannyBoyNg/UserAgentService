using System;

namespace Ng.Services
{
    /// <summary>
    /// UserAgent settings container.
    /// </summary>
    public class UserAgentSettings
    {
        /// <summary>
        /// Gets or sets the maximum size of the cache. 10000 means it will store 10000 different useragent strings in cache. It doesn't mean bytes.
        /// </summary>
        public int CacheSizeLimit { get; set; } = 10000;
        /// <summary>
        /// Gets or sets an absolute expiration time for a cache entry, relative to now.
        /// </summary>
        public TimeSpan? AbsoluteExpirationRelativeToNow { get; set; } = null;
        /// <summary>
        /// Gets or sets how long a cache entry can be inactive (e.g. not accessed) before it will be removed. This will not extend the entry lifetime beyond the absolute expiration (if set).
        /// </summary>
        public TimeSpan CacheSlidingExpiration { get; set; } = TimeSpan.FromDays(3);
        /// <summary>
        /// Gets or sets the maximum size of the useragent string. Limiting the length of the useragent string protects from hackers sending in extremely long user agent strings.
        /// </summary>
        public int UaStringSizeLimit { get; set; } = 512;
    }
}
