using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;

namespace OpenAI.Playground.TestHelpers
{
    internal static class EmbeddingTestHelper
    {
        public static async Task RunSimpleEmbeddingTest(IOpenAIService sdk)
        {
            ConsoleExtensions.WriteLine("Simple Embedding test is starting:", ConsoleColor.Cyan);

            try
            {
                ConsoleExtensions.WriteLine("Embedding Test:", ConsoleColor.DarkCyan);
                var embeddingResult = await sdk.Embeddings.CreateEmbedding(new EmbeddingCreateRequest()
                {
                    InputAsList = new List<string> { "The quick brown fox jumped over the lazy dog." },
                    Model = Models.TextSearchAdaDocV1
                });

                if (embeddingResult.Successful)
                {
                    var json = System.Text.Json.JsonSerializer.Serialize(embeddingResult.Data.FirstOrDefault());
                    Console.WriteLine(json);
                }
                else
                {
                    if (embeddingResult.Error == null)
                    {
                        throw new Exception("Unknown Error");
                    }

                    Console.WriteLine($"{embeddingResult.Error.Code}: {embeddingResult.Error.Message}");
                }

                Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(embeddingResult.Data.FirstOrDefault()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}