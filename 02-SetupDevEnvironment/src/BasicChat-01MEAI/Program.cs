using System.ClientModel;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;

using Azure;
using Azure.AI.Inference;

var deploymentName = "o3-mini"; // e.g. "gpt-4o-mini"
var endpoint = new Uri("https://tokapin-openai-01.openai.azure.com/"); // e.g. "https://< your hub name >.openai.azure.com/"
var apiKey = new ApiKeyCredential(Environment.GetEnvironmentVariable("AZURE_AI_KEY") ?? throw new InvalidOperationException("The environment variable 'AZURE_AI_KEY' is not set."));

IChatClient client = new AzureOpenAIClient(
    endpoint,
    apiKey)
.AsChatClient(deploymentName);

var response = await client.GetResponseAsync("Tell me a joke about a frog");

Console.WriteLine(response.Message);