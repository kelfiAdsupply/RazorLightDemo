using RazorLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using RazorLight.Extensions;

namespace TemplateEngine
{
    public class FileWithPartialScenario
    {
        private readonly RazorLightEngine _engine;

        public static string Template
        {
            get
            {
                string fileTemplate;
                using (var stream = new StreamReader($"{Environment.CurrentDirectory}\\Views\\TemplateWithPartial.cshtml"))
                {
                    fileTemplate = stream.ReadToEnd();
                }
                return fileTemplate;
            }
        }

        public static string Partial
        {
            get
            {
                string fileTemplate;
                using (var stream = new StreamReader($"{Environment.CurrentDirectory}\\Views\\Partial.cshtml"))
                {
                    fileTemplate = stream.ReadToEnd();
                }
                return fileTemplate;
            }
        }

        public FileWithPartialScenario(RazorLightEngine engine)
        {
            _engine = engine;
        }

        public async Task<string> GetTemplate(object model)
        {
            var compiled = await _engine.CompileRenderAsync("TemplateWithPartial.cshtml", new{}, model.ToExpando());
            return compiled;
        }
    }
}
