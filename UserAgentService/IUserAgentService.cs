namespace Ng.Services
{
    /// <summary>Default interface for UserAgentService</summary>
    public interface IUserAgentService
    {
        /// <summary>Gets or sets the settings.</summary>
        public UserAgentSettings Settings { get; set; }

        /// <summary>Parses the specified user agent string.</summary>
        /// <param name="userAgentString">The user agent string.</param>
        /// <returns>An UserAgent object</returns>
        UserAgent Parse(string userAgentString);
    }
}
