﻿using OpenAI.GPT3.Extensions;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels.ImageResponseModel;

namespace OpenAI.GPT3.Managers;

public partial class OpenAIService : IImageService
{
    /// <summary>
    ///     Creates an image given a prompt.
    /// </summary>
    /// <param name="imageCreateModel"></param>
    /// <returns></returns>
    public async Task<ImageCreateResponse> CreateImage(ImageCreateRequest imageCreateModel)
    {
        return await _httpClient.PostAndReadAsAsync<ImageCreateResponse>(_endpointProvider.ImageCreate(), imageCreateModel);
    }

    public Task<ImageCreateResponse> CreateImage(string prompt)
    {
        return CreateImage(new ImageCreateRequest(prompt));
    }

    /// <summary>
    ///     Creates an edited or extended image given an original image and a prompt.
    /// </summary>
    /// <param name="imageEditCreateRequest"></param>
    /// <returns></returns>
    public async Task<ImageCreateResponse> CreateImageEdit(ImageEditCreateRequest imageEditCreateRequest)
    {
        var multipartContent = new MultipartFormDataContent();
        if (imageEditCreateRequest.User != null) multipartContent.Add(new StringContent(imageEditCreateRequest.User), "user");
        if (imageEditCreateRequest.ResponseFormat != null) multipartContent.Add(new StringContent(imageEditCreateRequest.ResponseFormat), "response_format");
        if (imageEditCreateRequest.Size != null) multipartContent.Add(new StringContent(imageEditCreateRequest.Size), "size");
        if (imageEditCreateRequest.N != null) multipartContent.Add(new StringContent(imageEditCreateRequest.N.ToString()!), "n");
        if (imageEditCreateRequest.Mask != null) multipartContent.Add(new ByteArrayContent(imageEditCreateRequest.Mask), "mask", imageEditCreateRequest.MaskName);

        multipartContent.Add(new StringContent(imageEditCreateRequest.Prompt), "prompt");
        multipartContent.Add(new ByteArrayContent(imageEditCreateRequest.Image), "image", imageEditCreateRequest.ImageName);

        return await _httpClient.PostFileAndReadAsAsync<ImageCreateResponse>(_endpointProvider.ImageEditCreate(), multipartContent);
    }

    /// <summary>
    ///     Creates a variation of a given image.
    /// </summary>
    /// <param name="imageEditCreateRequest"></param>
    /// <returns></returns>
    public async Task<ImageCreateResponse> CreateImageVariation(ImageVariationCreateRequest imageEditCreateRequest)
    {
        var multipartContent = new MultipartFormDataContent();
        if (imageEditCreateRequest.User != null) multipartContent.Add(new StringContent(imageEditCreateRequest.User), "user");
        if (imageEditCreateRequest.ResponseFormat != null) multipartContent.Add(new StringContent(imageEditCreateRequest.ResponseFormat), "response_format");
        if (imageEditCreateRequest.Size != null) multipartContent.Add(new StringContent(imageEditCreateRequest.Size), "size");
        if (imageEditCreateRequest.N != null) multipartContent.Add(new StringContent(imageEditCreateRequest.N.ToString()!), "n");

        multipartContent.Add(new ByteArrayContent(imageEditCreateRequest.Image), "image", imageEditCreateRequest.ImageName);

        return await _httpClient.PostFileAndReadAsAsync<ImageCreateResponse>(_endpointProvider.ImageVariationCreate(), multipartContent);
    }
}