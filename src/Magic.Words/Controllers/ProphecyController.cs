using Magic.Words.Core.Interfaces;
using Magic.Words.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace Magic.Words.Web.Controllers {
    public class ProphecyController : Controller {

        private readonly IOpenAIService _prophecyService;

        public ProphecyController (IOpenAIService prophecyService) {
        _prophecyService = prophecyService;
                }
    public async Task<IActionResult> Index() {
            // Call the CheckProgramingLanguage method and get the result

            // var result = await _prophecyService.CheckProgramingLanguage("C# is"); // You can pass any programming language you want

            var openAi = new OpenAIAPI("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");

            var prompt = "Translate the following English text to French: 'Hello, how are you?'";

            // Create a completion request
            var completionRequest = new CompletionRequest
            {
                Model = "text-davinci-004",
                Prompt = prompt,
                // Add any other relevant parameters as needed
            };

            // Make the API request
            var response = openAi.Completions.CreateCompletionAsync(completionRequest);

            // Handle the response
            Console.WriteLine(response.Result.ToString );



            ViewData["ProphecyResult"] = response.Result.ToString;

            return View();
        }
    }

}