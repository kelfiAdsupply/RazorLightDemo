// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Newtonsoft.Json;
using RazorLight;
using TemplateEngine;


var templateRootFolder = $"{Environment.CurrentDirectory}/Views/";

var engine = new RazorLightEngineBuilder()
    // required to have a default RazorLightProject type,
    // but not required to create a template from string.
    .UseEmbeddedResourcesProject(typeof(Program))
    .SetOperatingAssembly(typeof(Program).Assembly)
    .UseFileSystemProject(templateRootFolder)
    .UseMemoryCachingProvider()
    .Build();

var sw = new Stopwatch();

Console.WriteLine("String Scenario");
var stringScenario = new StringScenario(engine);
Console.WriteLine($"Template: \n{StringScenario.Template}");
Console.WriteLine("----------------------------------------\n");

Console.WriteLine("Start Compiled");
var stringModel = new StringViewModel {Name = "John Doe"};
sw.Restart();
var stringCompiled = stringScenario.GetTemplate(stringModel).Result;
sw.Stop();
Console.WriteLine($"End: {sw.ElapsedMilliseconds} ms");
Console.WriteLine($"Model:\n{JsonConvert.SerializeObject(stringModel)}");
Console.WriteLine($"Result:\n{stringCompiled}");
Console.WriteLine("----------------------------------------\n");

Console.WriteLine("Start Cached");
var stringModel2 = new StringViewModel {Name = "Marie Doe"};
sw.Restart();
var stringCached = stringScenario.GetTemplate(stringModel2).Result;
sw.Stop();
Console.WriteLine($"End: {sw.ElapsedMilliseconds} ms");
Console.WriteLine($"Model:\n{JsonConvert.SerializeObject(stringModel2)}");
Console.WriteLine($"Result:\n{stringCached}");
Console.WriteLine("----------------------------------------\n");

Console.WriteLine("\n\n\n\n");

Console.WriteLine("File Scenario");
var fileScenario = new FileScenario(engine);
Console.WriteLine($"Template: \n{FileScenario.Template}");
Console.WriteLine("----------------------------------------\n");

Console.WriteLine("Start Compiled");
var fileModel = new TemplateWithoutPartialViewModel()
{
    CompanyName = "AdSupply",
    SiteNames = new[] { "Site1", "Site2" },
    SupportEmail = "support@adsupply.com",
    UserName = "User1"
};
sw.Restart();
var fileCompiled = fileScenario.GetTemplate(fileModel).Result;
sw.Stop();
Console.WriteLine($"End: {sw.ElapsedMilliseconds} ms");
Console.WriteLine($"Model:\n{JsonConvert.SerializeObject(fileModel)}");
Console.WriteLine($"Result:\n{fileCompiled}");
Console.WriteLine("----------------------------------------\n");

Console.WriteLine("Start Cached");
var fileModel2 = new TemplateWithoutPartialViewModel()
{
    CompanyName = "TwinRed",
    SiteNames = new[] { "Site3" },
    SupportEmail = "support@twinred.com",
    UserName = "User2"
};
sw.Restart();
var fileCached = fileScenario.GetTemplate(fileModel2).Result;
sw.Stop();
Console.WriteLine($"End: {sw.ElapsedMilliseconds} ms");
Console.WriteLine($"Model:\n{JsonConvert.SerializeObject(fileModel2)}");
Console.WriteLine($"Result:\n{fileCached}");
Console.WriteLine("----------------------------------------\n");

Console.WriteLine("\n\n\n\n");

Console.WriteLine("File With Partial Scenario");
var fileWithPartialScenario = new FileWithPartialScenario(engine);
Console.WriteLine($"Template: \n{FileWithPartialScenario.Template}");
Console.WriteLine($"Partial: \n{FileWithPartialScenario.Partial}");
Console.WriteLine("----------------------------------------\n");

Console.WriteLine("Start Compiled");
var fileWithPartialModel = new
{
    CompanyName = "AdSupply",
    Users = new[] { "User1", "User2", "User3" },
};
sw.Restart();
var fileWithPartialCompiled = fileWithPartialScenario.GetTemplate(fileWithPartialModel).Result;
sw.Stop();
Console.WriteLine($"End: {sw.ElapsedMilliseconds} ms");
Console.WriteLine($"Model:\n{JsonConvert.SerializeObject(fileWithPartialModel)}");
Console.WriteLine($"Result:\n{fileWithPartialCompiled}");
Console.WriteLine("----------------------------------------\n");

Console.WriteLine("Start Cached");
var fileWithPartialModel2 = new
{
    CompanyName = "TwinRed",
    Users = new[] { "User4", "User5" },
};
sw.Restart();
var fileWithPartialCached = fileWithPartialScenario.GetTemplate(fileWithPartialModel2).Result;
sw.Stop();
Console.WriteLine($"End: {sw.ElapsedMilliseconds} ms");
Console.WriteLine($"Model:\n{JsonConvert.SerializeObject(fileWithPartialModel2)}");
Console.WriteLine($"Result:\n{fileWithPartialCached}");
Console.WriteLine("----------------------------------------\n");