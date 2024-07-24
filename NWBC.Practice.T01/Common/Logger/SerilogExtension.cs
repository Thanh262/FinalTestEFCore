using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Json;

namespace Common.Logger;

public static class SerilogExtension
{
    public static void ConfigureSerilog(this IHostBuilder host)
    {
        host.UseSerilog((ctx, lc) 
            => { lc.WriteTo.Console();
            lc.WriteTo.File(new JsonFormatter(),"Log.txt"); });
    }
}