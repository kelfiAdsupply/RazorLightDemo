using System;
using System.IO;
using RazorLight;
using System.Threading.Tasks;

namespace TemplateEngine
{
    public class FileWithoutPartialScenario
    {
        private readonly RazorLightEngine _engine;

        public static string Template
        {
            get
            {
                string fileTemplate;
                using (var stream = new StreamReader($"{Environment.CurrentDirectory}\\Views\\TemplateWithoutPartial.cshtml"))
                {
                    fileTemplate = stream.ReadToEnd();
                }
                return fileTemplate;
            }
        }

        public FileWithoutPartialScenario(RazorLightEngine engine)
        {
            _engine = engine;
        }

        public async Task<string> GetTemplate(TemplateWithoutPartialViewModel model)
        {
            var compiled = await _engine.CompileRenderAsync("TemplateWithoutPartial.cshtml", model);
            return compiled;
        }
    }
}
