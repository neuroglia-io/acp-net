using AgentCommunicationProtocol.Commands.Runs;
using AgentCommunicationProtocol.Commands.Threads;
using AgentCommunicationProtocol.Queries.Threads;

namespace AgentCommunicationProtocol.Server.Controllers;

/// <summary>
/// Represents the <see cref="Controller"/> used to manage <see cref="Models.Thread"/>s
/// </summary>
/// <param name="mediator">The service used to mediate calls</param>
/// <param name="jsonOptions">The service used to access the current <see cref="JsonOptions"/></param>
[ApiController, Route("threads")]
public class ThreadsController(IMediator mediator, IOptions<JsonOptions> jsonOptions)
    : Controller
{

    /// <summary>
    /// Creates a new thread.
    /// </summary>
    /// <param name="command">The command to execute.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>A new <see cref="IActionResult"/> used to describe the result of the operation.</returns>
    [HttpPost(Name = "Create Thread")]
    [EndpointName("Create Thread"), EndpointDescription("Creates a new thread.")]
    [ProducesResponseType(typeof(Models.Thread), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Conflict)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> CreateThreadAsync([FromBody, Description("The command to execute.")] CreateThreadCommand command, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var result = await mediator.ExecuteAsync(command, cancellationToken).ConfigureAwait(false);
        return this.Process(result);
    }

    /// <summary>
    /// Returns a list of threads matching the criteria provided in the request.\nThis endpoint also functions as the endpoint to list all threads.
    /// </summary>
    /// <param name="query">The search query to perform.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>A new <see cref="IActionResult"/> used to describe the result of the operation.</returns>
    [HttpPost("search", Name = "Search Threads")]
    [EndpointName("Search Threads"), EndpointDescription("Returns a list of threads matching the criteria provided in the request.\nThis endpoint also functions as the endpoint to list all threads.")]
    [ProducesResponseType(typeof(IEnumerable<Models.Thread>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> SearchThreadsAsync([FromBody, Description("The search query to perform.")] SearchThreadQuery query, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var result = await mediator.ExecuteAsync(query, cancellationToken).ConfigureAwait(false);
        return this.Process(result);
    }

    /// <summary>
    /// Gets the specified thread.
    /// </summary>
    /// <param name="id">The unique identifier of the thread to get.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>A new <see cref="IActionResult"/> used to describe the result of the operation.</returns>
    [HttpGet("{id}", Name = "Get Thread")]
    [EndpointName("Get Thread"), EndpointDescription("Gets the thread with the specified id.")]
    [ProducesResponseType(typeof(Models.Thread), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> GetThreadAsync([Description("The id of the thread to get.")] string id, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var result = await mediator.ExecuteAsync(new GetThreadQuery()
        {
            Id = id
        }, cancellationToken).ConfigureAwait(false);
        return this.Process(result);
    }

    /// <summary>
    /// Gets the history of the specified thread.
    /// </summary>
    /// <param name="id">The unique identifier of the thread to get the history of.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>A new <see cref="IActionResult"/> used to describe the result of the operation.</returns>
    [HttpGet("{id}/history", Name = "Get Thread History")]
    [EndpointName("Get Thread History"), EndpointDescription("Gets the history of the specified thread.")]
    [ProducesResponseType(typeof(Models.ThreadState), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> GetThreadHistoryAsync([Description("The id of the thread to get the history of.")] string id, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var result = await mediator.ExecuteAsync(new GetThreadHistoryQuery()
        {
            Id = id
        }, cancellationToken).ConfigureAwait(false);
        return this.Process(result);
    }

    /// <summary>
    /// Patches the thread with the specified id.
    /// </summary>
    /// <param name="id">The id of the thread to patch.</param>
    /// <param name="state">The thread's updated state.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>A new <see cref="IActionResult"/> used to describe the result of the operation.</returns>
    [HttpPatch("{id}", Name = "Patch Thread")]
    [EndpointName("Patch Thread"), EndpointDescription("Patches the thread with the specified id.")]
    [ProducesResponseType(typeof(Models.Thread), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> PatchThreadAsync([Description("The id of the thread to patch.")] string id, [FromBody, Description("The thread's updated state.")] Models.ThreadState state, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var result = await mediator.ExecuteAsync(new PatchThreadCommand()
        {
            ThreadId = id,
            State = state
        }, cancellationToken).ConfigureAwait(false);
        return this.Process(result);
    }

    /// <summary>
    /// Deletes the specified thread.
    /// </summary>
    /// <param name="id">The unique identifier of the thread to delete.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>A new <see cref="IActionResult"/> used to describe the result of the operation.</returns>
    [HttpDelete("{id}", Name = "Delete Thread")]
    [EndpointName("Delete Thread"), EndpointDescription("Deletes the thread with the specified id.")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> DeleteThreadAsync([Description("The id of the thread to delete.")] string id, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var result = await mediator.ExecuteAsync(new DeleteThreadCommand()
        {
            ThreadId = id
        }, cancellationToken).ConfigureAwait(false);
        return this.Process(result, (int)HttpStatusCode.NoContent);
    }

    /// <summary>
    /// Lists the specified thread's runs.
    /// </summary>
    /// <param name="id">The id of the thread to list the runs of.</param>
    /// <param name="offset">The The offset, if any, to start listing runs from. Defaults to '0'.</param>
    /// <param name="limit">The limit, if any, of runs to list. Defaults to '1000'.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>A new <see cref="IActionResult"/> used to describe the result of the operation.</returns>
    [HttpGet("{id}/runs")]
    [EndpointName("List Thread Runs"), EndpointDescription("Lists the specified thread's runs.")]
    [ProducesResponseType(typeof(IEnumerable<AgentRun>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> ListThreadRunsAsync([Description("The id of the thread to list the runs of.")] string id, [Description("The offset, if any, to start listing runs from. Defaults to '0'.")] uint offset = 0, [Description("The limit, if any, of runs to list. Defaults to '1000'.")] uint limit = ListThreadRunsQuery.DefaultLimit, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var result = await mediator.ExecuteAsync(new ListThreadRunsQuery()
        {
            ThreadId = id,
            Offset = offset,
            Limit = limit
        }, cancellationToken).ConfigureAwait(false);
        return this.Process(result, (int)HttpStatusCode.NoContent);
    }

    /// <summary>
    /// Creates a run on the specified thread and return the run its ID immediately. Don't wait for the final run output.
    /// </summary>
    /// <param name="id">The id of the thread on which to create a new run.</param>
    /// <param name="command">The command that defines the run to create.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>A new <see cref="IActionResult"/> used to describe the result of the operation.</returns>
    [HttpPost("{id}/runs")]
    [EndpointName("Create Background Thread Run"), EndpointDescription("Creates a run on the specified thread and return the run its ID immediately. Don't wait for the final run output.")]
    [ProducesResponseType(typeof(StatefulAgentRun), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.Conflict)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> CreateBackgroundRunAsync([Description("The id of the thread on which to create a new run.")] string id, [FromBody, Description("The command that defines the run to create")] CreateStatefulRunCommand command, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var result = await mediator.ExecuteAsync(new CreateThreadBackgroundRunCommand()
        {
            ThreadId = id,
            Run = command
        }, cancellationToken).ConfigureAwait(false);
        return this.Process(result, (int)HttpStatusCode.NoContent);
    }

    /// <summary>
    /// Creates a run on the specified thread and streams its output.
    /// </summary>
    /// <param name="id">The id of the thread on which to create a new run.</param>
    /// <param name="command">The command that defines the run to create.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>A new awaitable <see cref="Task"/>.</returns>
    [HttpPost("{id}/runs/stream")]
    [EndpointName("Create And Stream Thread Run"), EndpointDescription("Creates a run on the specified thread and streams its output.")]
    [ProducesResponseType(typeof(IEnumerable<RunResultUpdate>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.Conflict)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task CreateAndStreamRunAsync([Description("The id of the thread on which to create a new run.")] string id, [FromBody, Description("The command that defines the run to create")] CreateStatefulRunCommand command, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
        {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await JsonSerializer.SerializeAsync(Response.Body, ProblemDetailsFactory.CreateValidationProblemDetails(HttpContext, ModelState), jsonOptions.Value.JsonSerializerOptions, cancellationToken);
            return;
        }
        var result = await mediator.ExecuteAsync(new CreateAndStreamThreadRunCommand()
        {
            ThreadId = id,
            Run = command
        }, cancellationToken).ConfigureAwait(false);
        if (!result.IsSuccess())
        {
            Response.StatusCode = result.Status;
            await JsonSerializer.SerializeAsync(Response.Body, ProblemDetailsFactory.CreateProblemDetails(HttpContext), jsonOptions.Value.JsonSerializerOptions, cancellationToken);
            return;
        }
        Response.Headers.ContentType = "text/event-stream";
        Response.Headers.CacheControl = "no-cache";
        Response.Headers.Connection = "keep-alive";
        Response.Headers["X-Response-Id"] = result.Data!.Id;
        await Response.Body.FlushAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            await foreach (var e in result.Data!.Stream.WithCancellation(cancellationToken))
            {
                var sseMessage = $"data: {jsonSerializer.SerializeToText(e)}\n\n";
                await Response.Body.WriteAsync(Encoding.UTF8.GetBytes(sseMessage), cancellationToken).ConfigureAwait(false);
                await Response.Body.FlushAsync(cancellationToken).ConfigureAwait(false);
            }
        }
        catch (Exception ex) when (ex is TaskCanceledException || ex is OperationCanceledException) { }
        return this.Process(result, (int)HttpStatusCode.NoContent);
    }

    /// <summary>
    /// Creates a run on the specified thread and wait for its output.
    /// </summary>
    /// <param name="id">The id of the thread on which to create a new run.</param>
    /// <param name="command">The command that defines the run to create.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
    /// <returns>A new <see cref="IActionResult"/> used to describe the result of the operation.</returns>
    [HttpPost("{id}/runs/wait")]
    [EndpointName("Create And Wait Thread Run"), EndpointDescription("Creates a run on the specified thread and wait for its output.")]
    [ProducesResponseType(typeof(StatefulAgentRun), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.Conflict)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> CreateAndWaitRunAsync([Description("The id of the thread on which to create a new run.")] string id, [FromBody, Description("The command that defines the run to create")] CreateStatefulRunCommand command, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var result = await mediator.ExecuteAsync(new CreateAndStreamThreadRunCommand()
        {
            ThreadId = id,
            Run = command
        }, cancellationToken).ConfigureAwait(false);
        return this.Process(result, (int)HttpStatusCode.NoContent);
    }

}