using AgentCommunicationProtocol.Queries.Agents;

namespace AgentCommunicationProtocol.Server.Controllers;

/// <summary>
/// Represents the <see cref="Controller"/> used to manage <see cref="Agent"/>s
/// </summary>
/// <param name="mediator">The service used to mediate calls</param>
[ApiController, Route("agents")]
public class AgentsController(IMediator mediator)
    : Controller
{

    /// <summary>
    /// Returns a list of agents matching the criteria provided in the request.\nThis endpoint also functions as the endpoint to list all agents.
    /// </summary>
    /// <param name="query">The query to execute.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>A new <see cref="IActionResult"/> used to describe the result of the operation.</returns>
    [HttpPost("search", Name = "Search Agents")]    
    [EndpointName("Search Agents"), EndpointDescription("Returns a list of agents matching the criteria provided in the request.\nThis endpoint also functions as the endpoint to list all agents.")]
    [ProducesResponseType(typeof(IEnumerable<Agent>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> SearchAgentsAsync([FromBody, Description("The search query to perform.")] SearchAgentsQuery query, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var result = await mediator.ExecuteAsync(query, cancellationToken).ConfigureAwait(false);
        return this.Process(result);
    }

    /// <summary>
    /// Gets an agent by id.
    /// </summary>
    /// <param name="id">The id of the agent to get.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>A new <see cref="IActionResult"/> used to describe the result of the operation.</returns>
    [HttpGet("{id}", Name = "Get Agent")]
    [EndpointName("Get Agent"), EndpointDescription("Gets an agent by id.")]
    [ProducesResponseType(typeof(Agent), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetAgentAsync([Description("The id of the agent to get.")] string id, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var result = await mediator.ExecuteAsync(new GetAgentQuery()
        {
            Id = id
        }, cancellationToken).ConfigureAwait(false);
        return this.Process(result);
    }

    /// <summary>
    /// Gets the ACP descriptor of agent by id.
    /// </summary>
    /// <param name="id">The id of the agent to get the ACP descriptor of.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>A new <see cref="IActionResult"/> used to describe the result of the operation.</returns>
    [HttpGet("{id}/descriptor", Name = "Get Agent ACP Descriptor")]
    [EndpointName("Get Agent ACP Descriptor"), EndpointDescription("Gets the ACP descriptor of an agent by id.")]
    [ProducesResponseType(typeof(AgentDescriptor), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> GetAgentDescriptorAsync([Description("The id of the agent to get the descriptor of.")] string id, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var result = await mediator.ExecuteAsync(new GetAgentDescriptorQuery()
        {
            Id = id
        }, cancellationToken).ConfigureAwait(false);
        return this.Process(result);
    }

}
