using RazorLight;
using System.Threading.Tasks;

namespace TemplateEngine
{
    public class StringScenario
    {
        private readonly RazorLightEngine _engine;
        public static string Template => "Hello, @Model.Name. Welcome to RazorLight repository";

        public StringScenario(RazorLightEngine engine)
        {
            _engine = engine;
        }

        public async Task<string> GetTemplate(StringViewModel model)
        {
            var compiled = await _engine.CompileRenderStringAsync("stringScenario", Template, model);
            return compiled;
        }
    }
}
