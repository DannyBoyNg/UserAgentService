using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Ng.Services
{
    /// <summary>
    /// Parsed UserAgent object
    /// </summary>
    public class UserAgent
    {
        private readonly UserAgentSettings settings;

        internal string Agent = "";

        /// <summary>
        /// Gets or sets a value indicating whether this UserAgent is a browser.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this UserAgent is a browser; otherwise, <c>false</c>.
        /// </value>
        public bool IsBrowser { get; set; } = false;
        /// <summary>
        /// Gets or sets a value indicating whether this UserAgent is a robot.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this UserAgent is a robot; otherwise, <c>false</c>.
        /// </value>
        public bool IsRobot { get; set; } = false;
        /// <summary>
        /// Gets or sets a value indicating whether this UserAgent is a mobile device.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this UserAgent is a mobile device; otherwise, <c>false</c>.
        /// </value>
        public bool IsMobile { get; set; } = false;
        /// <summary>
        /// Gets or sets the platform.
        /// </summary>
        /// <value>
        /// The platform or operating system.
        /// </value>
        public string Platform { get; set; } = "";
        /// <summary>
        /// Gets or sets the browser.
        /// </summary>
        /// <value>
        /// The browser.
        /// </value>
        public string Browser { get; set; } = "";
        /// <summary>
        /// Gets or sets the browser version.
        /// </summary>
        /// <value>
        /// The browser version.
        /// </value>
        public string BrowserVersion { get; set; } = "";
        /// <summary>
        /// Gets or sets the mobile device.
        /// </summary>
        /// <value>
        /// The mobile device.
        /// </value>
        public string Mobile { get; set; } = "";
        /// <summary>
        /// Gets or sets the robot.
        /// </summary>
        /// <value>
        /// The robot.
        /// </value>
        public string Robot { get; set; } = "";

        internal UserAgent(UserAgentSettings settings, string? userAgentString = null)
        {
            this.settings = settings;

            if (userAgentString != null)
            {
                Agent = userAgentString.Trim();
                SetPlatform();
                if (SetRobot()) return;
                if (SetBrowser()) return;
                if (SetMobile()) return;
            }
        }

        internal bool SetPlatform()
        {
            foreach (var item in settings.Platforms)
            {
                if (Regex.IsMatch(Agent, $"{Regex.Escape(item.Key)}", RegexOptions.IgnoreCase))
                {
                    Platform = item.Value;
                    return true;
                }
            }
            Platform = "Unknown Platform";
            return false;
        }

        internal bool SetBrowser()
        {
            foreach (var item in settings.Browsers)
            {
                var match = Regex.Match(Agent, $@"{item.Key}.*?([0-9\.]+)", RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    IsBrowser = true;
                    BrowserVersion = match.Groups[1].Value;
                    Browser = item.Value;
                    SetMobile();
                    return true;
                }
            }
            return false;
        }

        internal bool SetRobot()
        {
            foreach (var item in settings.Robots)
            {
                if (Regex.IsMatch(Agent, $"{Regex.Escape(item.Key)}", RegexOptions.IgnoreCase))
                {
                    IsRobot = true;
                    Robot = item.Value;
                    SetMobile();
                    return true;
                }
            }
            return false;
        }

        internal bool SetMobile()
        {
            foreach (var item in settings.Mobiles)
            {
                if (Agent?.IndexOf(item.Key, StringComparison.OrdinalIgnoreCase) != -1)
                {
                    IsMobile = true;
                    Mobile = item.Value;
                    return true;
                }
            }
            return false;
        }
    }
}
