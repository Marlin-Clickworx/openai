﻿using LaserCatEyes.HttpClientListener;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.GPT3.Extensions;
using OpenAI.GPT3.Interfaces;
using OpenAI.Playground.TestHelpers;

var builder = new ConfigurationBuilder()
    .AddJsonFile("ApiSettings.json")
    .AddUserSecrets<Program>();

IConfiguration configuration = builder.Build();
var serviceCollection = new ServiceCollection();
serviceCollection.AddScoped(_ => configuration);

// Laser cat eyes is a tool that shows your requests and responses between OpenAI server and your client.
// Get your app key from https://lasercateyes.com for FREE and put it under ApiSettings.json or secrets.json.
// It is in Beta version, if you don't want to use it just comment out below line.
serviceCollection.AddLaserCatEyesHttpClientListener();

serviceCollection.AddOpenAIService();
//serviceCollection.AddOpenAIService(settings => { settings.ApiKey = "TEST"; });

var serviceProvider = serviceCollection.BuildServiceProvider();
var sdk = serviceProvider.GetRequiredService<IOpenAIService>();

//await ModelTestHelper.FetchModelsTest(sdk);
//await EditTestHelper.RunSimpleEditCreateTest(sdk);
//await ImageTestHelper.RunSimpleCreateImageTest(sdk);
//await ImageTestHelper.RunSimpleCreateImageEditTest(sdk);
//await ImageTestHelper.RunSimpleCreateImageVariationTest(sdk);
//await ModerationTestHelper.CreateModerationTest(sdk);
//await CompletionTestHelper.RunSimpleCompletionTest(sdk);
//await CompletionTestHelper.RunSimpleCompletionTest2(sdk);
//await CompletionTestHelper.RunSimpleCompletionTest3(sdk);
//await CompletionTestHelper.RunSimpleCompletionStreamTest(sdk);
await EmbeddingTestHelper.RunSimpleEmbeddingTest(sdk);
//////await FileTestHelper.RunSimpleFileTest(sdk); //will delete files
//////await FineTuningTestHelper.CleanUpAllFineTunings(sdk); //!!!!! will delete all fine-tunings
//await FineTuningTestHelper.RunCaseStudyIsTheModelMakingUntrueStatements(sdk);
Console.ReadLine();