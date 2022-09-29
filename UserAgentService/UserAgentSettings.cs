using System;
using System.Collections.Generic;

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

        /// <summary>
        /// Gets a dictionary containing mappings for platforms.
        /// </summary>
        public Dictionary<string, string> Platforms { get; } = new()
        {
            {"windows nt 10.0", "Windows 10"},
            {"windows nt 6.3", "Windows 8.1"},
            {"windows nt 6.2", "Windows 8"},
            {"windows nt 6.1", "Windows 7"},
            {"windows nt 6.0", "Windows Vista"},
            {"windows nt 5.2", "Windows 2003"},
            {"windows nt 5.1", "Windows XP"},
            {"windows nt 5.0", "Windows 2000"},
            {"windows nt 4.0", "Windows NT 4.0"},
            {"winnt4.0", "Windows NT 4.0"},
            {"winnt 4.0", "Windows NT"},
            {"winnt", "Windows NT"},
            {"windows 98", "Windows 98"},
            {"win98", "Windows 98"},
            {"windows 95", "Windows 95"},
            {"win95", "Windows 95"},
            {"windows phone", "Windows Phone"},
            {"windows", "Unknown Windows OS"},
            {"android", "Android"},
            {"blackberry", "BlackBerry"},
            {"iphone", "iOS"},
            {"ipad", "iOS"},
            {"ipod", "iOS"},
            {"os x", "Mac OS X"},
            {"ppc mac", "Power PC Mac"},
            {"freebsd", "FreeBSD"},
            {"ppc", "Macintosh"},
            {"linux", "Linux"},
            {"debian", "Debian"},
            {"sunos", "Sun Solaris"},
            {"beos", "BeOS"},
            {"apachebench", "ApacheBench"},
            {"aix", "AIX"},
            {"irix", "Irix"},
            {"osf", "DEC OSF"},
            {"hp-ux", "HP-UX"},
            {"netbsd", "NetBSD"},
            {"bsdi", "BSDi"},
            {"openbsd", "OpenBSD"},
            {"gnu", "GNU/Linux"},
            {"unix", "Unknown Unix OS"},
            {"symbian", "Symbian OS"},
        };

        /// <summary>
        /// Gets a dictionary containing mappings for browsers.
        /// </summary>
        public Dictionary<string, string> Browsers { get; } = new()
        {
            {"Microsoft Outlook", "Microsoft Outlook"},
            {"OPR", "Opera"},
            {"Flock", "Flock"},
            {"Edge", "Edge"},
            {"Edg", "Edge"},
            {"Chrome", "Chrome"},
            {"Opera.*?Version", "Opera"},
            {"Opera", "Opera"},
            {"MSIE", "Internet Explorer"},
            {"Internet Explorer", "Internet Explorer"},
            {"Trident.* rv" , "Internet Explorer"},
            {"Shiira", "Shiira"},
            {"Firefox", "Firefox"},
            {"Chimera", "Chimera"},
            {"Phoenix", "Phoenix"},
            {"Firebird", "Firebird"},
            {"Camino", "Camino"},
            {"Netscape", "Netscape"},
            {"OmniWeb", "OmniWeb"},
            {"Safari", "Safari"},
            {"Mozilla", "Mozilla"},
            {"Konqueror", "Konqueror"},
            {"icab", "iCab"},
            {"Lynx", "Lynx"},
            {"Links", "Links"},
            {"hotjava", "HotJava"},
            {"amaya", "Amaya"},
            {"IBrowse", "IBrowse"},
            {"Maxthon", "Maxthon"},
            {"Ubuntu", "Ubuntu Web Browser"},
            {"Vivaldi", "Vivaldi"},
        };

        /// <summary>
        /// Gets a dictionary containing mappings for mobiles.
        /// </summary>
        public Dictionary<string, string> Mobiles { get; } = new()
        {
            // Legacy
            {"mobileexplorer", "Mobile Explorer"},
            {"palmsource", "Palm"},
            {"palmscape", "Palmscape"},
            // Phones and Manufacturers
            {"motorola", "Motorola"},
            {"nokia", "Nokia"},
            {"palm", "Palm"},
            {"iphone", "Apple iPhone"},
            {"ipad", "iPad"},
            {"ipod", "Apple iPod Touch"},
            {"sony", "Sony Ericsson"},
            {"ericsson", "Sony Ericsson"},
            {"blackberry", "BlackBerry"},
            {"cocoon", "O2 Cocoon"},
            {"blazer", "Treo"},
            {"lg", "LG"},
            {"amoi", "Amoi"},
            {"xda", "XDA"},
            {"mda", "MDA"},
            {"vario", "Vario"},
            {"htc", "HTC"},
            {"samsung", "Samsung"},
            {"sharp", "Sharp"},
            {"sie-", "Siemens"},
            {"alcatel", "Alcatel"},
            {"benq", "BenQ"},
            {"ipaq", "HP iPaq"},
            {"mot-", "Motorola"},
            {"playstation portable", "PlayStation Portable"},
            {"playstation 3", "PlayStation 3"},
            {"playstation vita", "PlayStation Vita"},
            {"hiptop", "Danger Hiptop"},
            {"nec-", "NEC"},
            {"panasonic", "Panasonic"},
            {"philips", "Philips"},
            {"sagem", "Sagem"},
            {"sanyo", "Sanyo"},
            {"spv", "SPV"},
            {"zte", "ZTE"},
            {"sendo", "Sendo"},
            {"nintendo dsi", "Nintendo DSi"},
            {"nintendo ds", "Nintendo DS"},
            {"nintendo 3ds", "Nintendo 3DS"},
            {"wii", "Nintendo Wii"},
            {"open web", "Open Web"},
            {"openweb", "OpenWeb"},
            // Operating Systems
            {"android", "Android"},
            {"symbian", "Symbian"},
            {"SymbianOS", "SymbianOS"},
            {"elaine", "Palm"},
            {"series60", "Symbian S60"},
            {"windows ce", "Windows CE"},
            // Browsers
            {"obigo", "Obigo"},
            {"netfront", "Netfront Browser"},
            {"openwave", "Openwave Browser"},
            {"mobilexplorer", "Mobile Explorer"},
            {"operamini", "Opera Mini"},
            {"opera mini", "Opera Mini"},
            {"opera mobi", "Opera Mobile"},
            {"fennec", "Firefox Mobile"},
            // Other
            {"digital paths", "Digital Paths"},
            {"avantgo", "AvantGo"},
            {"xiino", "Xiino"},
            {"novarra", "Novarra Transcoder"},
            {"vodafone", "Vodafone"},
            {"docomo", "NTT DoCoMo"},
            {"o2", "O2"},
            // Fallback
            {"mobile", "Generic Mobile"},
            {"wireless", "Generic Mobile"},
            {"j2me", "Generic Mobile"},
            {"midp", "Generic Mobile"},
            {"cldc", "Generic Mobile"},
            {"up.link", "Generic Mobile"},
            {"up.browser", "Generic Mobile"},
            {"smartphone", "Generic Mobile"},
            {"cellphone", "Generic Mobile"},
        };

        /// <summary>
        /// Gets a dictionary containing mappings for robots.
        /// </summary>
        public Dictionary<string, string> Robots { get; } = new()
        {
            {"googlebot", "Googlebot"},
            {"msnbot", "MSNBot"},
            {"baiduspider", "Baiduspider"},
            {"bingbot", "Bing"},
            {"slurp", "Inktomi Slurp"},
            {"yahoo", "Yahoo"},
            {"ask jeeves", "Ask Jeeves"},
            {"fastcrawler", "FastCrawler"},
            {"infoseek", "InfoSeek Robot 1.0"},
            {"lycos", "Lycos"},
            {"yandex", "YandexBot"},
            {"mediapartners-google", "MediaPartners Google"},
            {"CRAZYWEBCRAWLER", "Crazy Webcrawler"},
            {"adsbot-google", "AdsBot Google"},
            {"feedfetcher-google", "Feedfetcher Google"},
            {"curious george", "Curious George"},
            {"ia_archiver", "Alexa Crawler"},
            {"MJ12bot", "Majestic-12"},
            {"Uptimebot", "Uptimebot"},
        };
    }
}
