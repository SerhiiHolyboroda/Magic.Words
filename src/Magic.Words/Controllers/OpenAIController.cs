using Magic.Words.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Magic.Words.Web.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class OpenAIController : Controller {

        private readonly ILogger<OpenAIController> _logger;
        private readonly IOpenAIService _openAIService;
        public OpenAIController(ILogger<OpenAIController> logger, IOpenAIService openAIService) {
            _logger = logger;
            _openAIService = openAIService;
        }
        [HttpPost()]

        [Route("CompleteSentence")]     
        public async Task<IActionResult> CompleteSentence(string text) {
            var result = await _openAIService.CompleteSentence(text);
            return Ok(result);
        }

        [Route("CompleteSentenceAdvance")]
        public async Task<IActionResult> CompleteSentenceAdvance(string text) {
            var result = await _openAIService.CompleteSentenceAdvance(text);
            return Ok(result);
        }
        [HttpPost()]
        [Route("AskQuestion")]
        public async Task<IActionResult> AskQuestion(string text) {
           
           
            var result = await _openAIService.CheckProgramingLanguage(text);
            return Ok(result);
        }


        public async Task<IActionResult> Index() {
            // Call the CheckProgramingLanguage method and get the result

           ; // You can pass any programming language you want

            // Pass the result to the view
            ViewData["ProphecyResult"] = await AskQuestion("C");

            return View();
        }
    }
}
