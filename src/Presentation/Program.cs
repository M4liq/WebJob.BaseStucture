using System.Threading.Tasks;

namespace Presentation
{
    class Program
    {
        static async Task Main()
        {
            var startup = new Startup();
            await startup.Run(startup.Init());
        }
    }
}