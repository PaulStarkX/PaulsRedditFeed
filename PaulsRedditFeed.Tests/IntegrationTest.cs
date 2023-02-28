using AutoFixture;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PaulsRedditFeed.Tests;

namespace PaulsRedditFeed;

/// <summary>
/// Base class for integration tests that run against an in memory version of PaulsRedditFeed
/// </summary>
public abstract class IntegrationTest
{
    private readonly PaulsRedditFeedWebApplicationFactory testAppFactory;
    protected IServiceProvider Services { get; }

    /// <summary>
    /// An Http client that can communicate with the controllers in PaulsRedditFeed
    /// </summary>
    protected HttpClient HttpClient => testAppFactory.CreateClient();

    /// <summary>
    /// An AutoFixture factory for generating random test data for clean test code with
    /// less data setup in it.
    /// </summary>
    protected Fixture Fixture { get; } = new Fixture();

    public IntegrationTest()
    {
        testAppFactory = new PaulsRedditFeedWebApplicationFactory(ConfigureServices);
        Services = testAppFactory.Services;
    }

    /// <summary>
    /// Override to customize dependency injection for a test class
    /// </summary>
    /// <param name="services">collection to register services with</param>
    protected virtual void ConfigureServices(IServiceCollection services)
    {
    }
}