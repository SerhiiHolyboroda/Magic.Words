using Azure;
using Azure.AI.OpenAI;
using Magic.Words.Core.Interfaces;
using Magic.Words.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using OpenAI_API;
using OpenAI_API.Completions;
using OpenAI_API.Moderation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic.Words.Infrastructure.Services {
    public class OpenAIService : IOpenAIService {

        private readonly OpenAIConfiguration _openAIConfig;
        public OpenAIService(IOptionsMonitor<OpenAIConfiguration> optionsMonitor ) {
            _openAIConfig = optionsMonitor.CurrentValue;
        }
        public async Task<string> CompleteSentence(string text) {

            // api instance
            OpenAIClient client = new OpenAIClient("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");
            // var api = new OpenAI_API.OpenAIAPI(_openAIConfig.Key);
        var  response =  await client.GetCompletionsAsync(new CompletionsOptions()
           {
               DeploymentName = "gpt-3.5-turbo-instruct", // assumes a matching model deployment or model name
               Prompts = { "Hello, world!" },
           });
            string result = "";
            foreach (var choice in response.Value.Choices)
            {
                Console.WriteLine(choice.Text);
                result += choice.Text;
            }
            //  var result = await api.Completions.GetCompletion(text);
            return result;
        }

        public async Task<string> CompleteSentenceAdvance(string text) {
            var api = new OpenAI_API.OpenAIAPI(_openAIConfig.Key);
            var result = await api.Completions.CreateCompletionAsync(
                new OpenAI_API.Completions.CompletionRequest(text, model: "CurieText", temperature: 0.1));
            return result.Completions[0].Text ;
        }

        public async Task<string> CheckProgramingLanguage(string language) {
            var api = new OpenAI_API.OpenAIAPI(_openAIConfig.Key);
            var chat = api.Chat.CreateConversation();
            chat.AppendSystemMessage("Give me random prophecy for the day");
            //  chat.AppendUserInput(language); // maybe here "Give me random prophecy for the day"
            var response = await chat.GetResponseFromChatbotAsync();
            return response;
        }
    }
}
