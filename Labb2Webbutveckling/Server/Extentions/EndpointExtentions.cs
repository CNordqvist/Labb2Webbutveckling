namespace Labb2Webbutveckling.Server.Extentions
{
    public static class EndpointExtentions
    {
        public static WebApplication MapCustomerEndpoints(this WebApplication app)
        {
            app.MapGet("/customer", CustomerHandler)
        }
    }
}
