using System.IO;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LifeSpot
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();

            // ��������� ��������� �������� ��� ������� � ������: ������� ���� � �����
            string footerHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Views", "Shared", "footer.html"));
            string sideBarHtml = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "Views", "Shared", "sideBar.html"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "index.html");

                    // ��������� ������ ��������, �������� � ���� ��������
                    var html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
                        .Replace("<!--SIDEBAR-->", sideBarHtml)
                        .Replace("<!--FOOTER-->", footerHtml);

                    await context.Response.WriteAsync(html.ToString());
                });

                endpoints.MapGet("/testing", async context =>
                {
                    var viewPath = Path.Combine(Directory.GetCurrentDirectory(), "Views", "testing.html");

                    // ��������� ������ ��������, �������� � ���� ��������
                    var html = new StringBuilder(await File.ReadAllTextAsync(viewPath))
                        .Replace("<!--SIDEBAR-->", sideBarHtml)
                        .Replace("<!--FOOTER-->", footerHtml);

                    await context.Response.WriteAsync(html.ToString());
                });

                endpoints.MapGet("/Static/CSS/index.css", async context =>
                {
                    var cssPath = Path.Combine(Directory.GetCurrentDirectory(), "Static", "CSS", "index.css");
                    var css = await File.ReadAllTextAsync(cssPath);
                    await context.Response.WriteAsync(css);
                });

                endpoints.MapGet("/Static/JS/index.js", async context =>
                {
                    var jsPath = Path.Combine(Directory.GetCurrentDirectory(), "Static", "JS", "index.js");
                    var js = await File.ReadAllTextAsync(jsPath);
                    await context.Response.WriteAsync(js);
                });
                endpoints.MapGet("/Static/JS/testing.js", async context =>
                {
                    var jsPath = Path.Combine(Directory.GetCurrentDirectory(), "Static", "JS", "testing.js");
                    var js = await File.ReadAllTextAsync(jsPath);
                    await context.Response.WriteAsync(js);
                });
            });
        }
    }
}