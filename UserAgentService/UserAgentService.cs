using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace DannyBoyNg.Services
{
    /// <summary>
    /// The UserAgent service
    /// </summary>
    /// <seealso cref="DannyBoyNg.Services.IUserAgentService" />
    public class UserAgentService : IUserAgentService
    {
        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        public UserAgentSettings Settings { get; set; }
        private MemoryCacheOptions CacheOptions { get; set; } = new MemoryCacheOptions();
        private IMemoryCache Cache { get; set; } = new MemoryCache(new MemoryCacheOptions());

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAgentService"/> class.
        /// </summary>
        public UserAgentService()
        {
            Settings = new UserAgentSettings();
            CacheOptions.SizeLimit = Settings.CacheSizeLimit;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAgentService"/> class.
        /// </summary>
        /// <param name="settings">UserAgent settings.</param>
        public UserAgentService(UserAgentSettings settings)
        {
            Settings = settings ?? new UserAgentSettings();
            CacheOptions.SizeLimit = Settings.CacheSizeLimit;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAgentService"/> class.
        /// </summary>
        /// <param name="settings">UserAgent settings.</param>
        public UserAgentService(IOptions<UserAgentSettings> settings)
        {
            Settings = settings?.Value ?? new UserAgentSettings();
            CacheOptions.SizeLimit = Settings.CacheSizeLimit;
        }

        /// <summary>
        /// Parses the specified user agent string.
        /// </summary>
        /// <param name="userAgentString">The user agent string.</param>
        /// <returns>
        /// An UserAgent object
        /// </returns>
        public UserAgent Parse(string? userAgentString)
        {
            userAgentString = (userAgentString?.Length > Settings.UaStringSizeLimit) ? userAgentString?.Trim().Substring(0, Settings.UaStringSizeLimit) : userAgentString?.Trim();
            return Cache.GetOrCreate(userAgentString, entry =>
            {
                entry.SlidingExpiration = Settings.CacheSlidingExpiration;
                if (Settings.AbsoluteExpirationRelativeToNow != null) entry.AbsoluteExpirationRelativeToNow = Settings.AbsoluteExpirationRelativeToNow;
                entry.Size = 1;
                return new UserAgent(userAgentString);
            });
        }

    }
}
