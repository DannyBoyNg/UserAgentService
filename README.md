# UserAgentService

<a href="https://www.nuget.org/packages/Ng.UserAgentService"><img src="https://img.shields.io/nuget/v/Ng.UserAgentService.svg" alt="NuGet Version" /></a> 
<a href="https://www.nuget.org/packages/Ng.UserAgentService"><img src="https://img.shields.io/nuget/dt/Ng.UserAgentService.svg" alt="NuGet Download Count" /></a>

A service to parse user-agent strings in C#. UserAgentService is extremely fast because it uses in-memory caching. UserAgentService only looks at the first 512 characters of the useragent string, it ignores the rest of the string. Most user-agent strings are within this limit but this limitation is introduced to protect itself from malicious, extremely long, hand crafted, user-agent strings.

## Dependancies

Microsoft.Extensions.Caching.Memory  
Microsoft.Extensions.Options  

## Installing

Install from Nuget
```
Install-Package Ng.UserAgentService
```

## Usage

Console application

```csharp
using Ng.Services;
...
//You do not have to specify any settings if you want to use the defaults
var settings = new UserAgentSettings
{
    CacheSizeLimit = 20000, //Default: 10000
    CacheSlidingExpiration = TimeSpan.FromDays(1), //Default: TimeSpan.FromDays(3)
    UaStringSizeLimit = 256, //Default: 512
};
var userAgentService = new UserAgentService(settings);

var ua = userAgentService.Parse("Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0");

var isBrowser = ua.IsBrowser; // true
var isRobot = ua.IsRobot; // false
var isMobile = ua.IsMobile; // false

var platform = ua.Platform; // Windows 7
var bowser = ua.Browser; // Firefox
var version = ua.BrowserVersion; // 47.0
var mobile = ua.Mobile; // empty string
var robot = ua.Robot; // empty string
```

ASP.NET Core

Register service with dependency injection in Startup.cs
```csharp
using Ng.Services;
...
public void ConfigureServices(IServiceCollection services)
{
    services.AddUserAgentService(); //Is equivalent to services.AddSingleton<IUserAgentService, UserAgentService>();

    or

    services.AddUserAgentService(options => {
        options.CacheSizeLimit = 20000; //Default: 10000
        options.CacheSlidingExpiration = TimeSpan.FromDays(1); //Default: TimeSpan.FromDays(3)
        options.UaStringSizeLimit = 256; //Default: 512
    });

    or
    
    services.AddSingleton<IUserAgentService, UserAgentService>(); //Is equivalent to services.AddUserAgentService();
}
```

Inject IUserAgentService into a Controller or wherever you like
```csharp
using Ng.Services;
...
public class MyController
{
    public MyController(IUserAgentService userAgentService) // <-- Inject IUserAgentService here
    {
        string userAgentString = Request.Headers["User-Agent"].ToString();
        UserAgent ua = userAgentService.Parse(userAgentString);
    }
}
```

## License

This project is licensed under the MIT License.

## Contributions

Contributions are welcome.
