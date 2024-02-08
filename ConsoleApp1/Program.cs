// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;
using System.Net.Http;

Console.WriteLine("Hello, World!");



var httpClient = new HttpClient() { 
BaseAddress = new Uri("https://api.openai.com/v1")
};

httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "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");
httpClient.DefaultRequestHeaders.Add("OpenAI-Beta", "assistants-v1");
httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
