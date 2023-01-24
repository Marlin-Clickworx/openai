using OpenAI.GPT3.Extensions;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;

namespace OpenAI.GPT3.Managers
{
    public partial class OpenAIService : IModerationService
    {
        /// <inheritdoc />
        public async Task<CreateModerationResponse> CreateModeration(CreateModerationRequest createModerationRequest)
        {
            return await _httpClient.PostAndReadAsAsync<CreateModerationResponse>(_endpointProvider.ModerationCreate(), createModerationRequest);
        }

        public Task<CreateModerationResponse> CreateModeration(string input, string? model = null)
        {
            return CreateModeration(new CreateModerationRequest()
            {
                Input = input,
                Model = model
            });
        }
    }
}