using Funq;
using ServiceStack;
using test.ServiceInterface;

[assembly: HostingStartup(typeof(test.AppHost))]

namespace test;

public class AppHost : AppHostBase, IHostingStartup
{
    public AppHost() : base("test", typeof(MyServices).Assembly) { }

    public override void Configure(Container container)
    {
        SetConfig(new HostConfig {
        });
    }

    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureServices((context, services) => 
            services.ConfigureNonBreakingSameSiteCookies(context.HostingEnvironment));
}
