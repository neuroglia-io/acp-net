namespace AgentCommunicationProtocol.Server;

/// <summary>
/// Exposes constants about ACP problems
/// </summary>
public static class Problems
{

    /// <summary>
    /// Exposes constants about ACP problem types
    /// </summary>
    public static class Types
    {

        /// <summary>
        /// Gets the base URI for all ACP problem types
        /// </summary>
        public static readonly Uri BaseUri = new("https://spec.acp.agntcy.org/problems/");

        /// <summary>
        /// Gets the type of problems that occur when a conflict is encountered
        /// </summary>
        public static readonly Uri Conflict = new(BaseUri, "conflict");
        /// <summary>
        /// Gets the type of problems that occur when data could not be found
        /// </summary>
        public static readonly Uri NotFound = new(BaseUri, "not-found");
        /// <summary>
        /// Gets the type of problems that occur when validation failed
        /// </summary>
        public static readonly Uri ValidationFailed = new(BaseUri, "validation-failed");

    }

    /// <summary>
    /// Exposes constants about ACP problem titles
    /// </summary>
    public static class Titles
    {

        /// <summary>
        /// Gets the title of problems that occur when an agent could not be found
        /// </summary>
        public const string AgentNotFound = "Agent Not Found";
        /// <summary>
        /// Gets the title of problems that occur when a run could not be found
        /// </summary>
        public const string RunNotFound = "Run Not Found";
        /// <summary>
        /// Gets the title of problems that occur when a thread already exists
        /// </summary>
        public const string ThreadAlreadyExists = "Thread Already Exists";
        /// <summary>
        /// Gets the title of problems that occur when a thread could not be found
        /// </summary>
        public const string ThreadNotFound = "Thread Not Found";
        /// <summary>
        /// Gets the title of problems that occur when a run is in an unexpected status
        /// </summary>
        public const string UnexpectedRunStatus = "Unexpected Run Status";

    }

    /// <summary>
    /// Exposes constants about ACP problem statuses
    /// </summary>
    public static class Statuses
    {

        /// <summary>
        /// Gets the status of problems that occur when data could not be found
        /// </summary>
        public const int NotFound = 404;
        /// <summary>
        /// Gets the status of problems that occur when a conflict is encountered
        /// </summary>
        public const int Conflict = 409;
        /// <summary>
        /// Gets the status of problems that occur when validation failed
        /// </summary>
        public const int ValidationFailed = 422;

    }

    /// <summary>
    /// Exposes constants about ACP problem details
    /// </summary>
    public static class Details
    {

        /// <summary>
        /// Gets the detail of problems that occur when an agent could not be found
        /// </summary>
        public const string AgentNotFound = "Failed to find the specified agent '{reference}'";
        /// <summary>
        /// Gets the detail of problems that occur when a run could not be found
        /// </summary>
        public const string RunNotFound = "Failed to find the run with the specified id '{id}'";
        /// <summary>
        /// Gets the detail of problems that occur when a thread already exists
        /// </summary>
        public const string ThreadAlreadyExists = "A thread with the specified id '{id}' already exists";
        /// <summary>
        /// Gets the detail of problems that occur when a thread could not be found
        /// </summary>
        public const string ThreadNotFound = "Failed to find the thread with the specified id '{id}'";
        /// <summary>
        /// Gets the detail of problems that occur when a run is in an unexpected status
        /// </summary>
        public const string UnexpectedRunStatus = "The run with id '{id}' is in an unexpected status '{status}'";

    }

    /// <summary>
    /// Creates a new <see cref="ProblemDetails"/> that describe an error that occurs when the specified agent could not be found
    /// </summary>
    /// <param name="reference">The reference of the agent that could not be found</param>
    /// <returns>A new <see cref="ProblemDetails"/></returns>
    public static ProblemDetails AgentNotFound(string reference) => new(Types.NotFound, Titles.AgentNotFound, Statuses.NotFound, StringFormatter.Format(Details.AgentNotFound, reference));

    /// <summary>
    /// Creates a new <see cref="ProblemDetails"/> that describe an error that occurs when the specified run could not be found
    /// </summary>
    /// <param name="id">The unique identifier of the run that could not be found</param>
    /// <returns>A new <see cref="ProblemDetails"/></returns>
    public static ProblemDetails RunNotFound(string id) => new(Types.NotFound, Titles.RunNotFound, Statuses.NotFound, StringFormatter.Format(Details.RunNotFound, id));

    /// <summary>
    /// Creates a new <see cref="ProblemDetails"/> that describe an error that occurs trying to create a thread that already exists
    /// </summary>
    /// <param name="id">The id of the thread that already exists</param>
    /// <returns>A new <see cref="ProblemDetails"/></returns>
    public static ProblemDetails ThreadAlreadyExists(string id) => new(Types.Conflict, Titles.ThreadAlreadyExists, Statuses.Conflict, StringFormatter.Format(Details.ThreadAlreadyExists, id));

    /// <summary>
    /// Creates a new <see cref="ProblemDetails"/> that describe an error that occurs when the specified thread could not be found
    /// </summary>
    /// <param name="id">The unique identifier of the thread that could not be found</param>
    /// <returns>A new <see cref="ProblemDetails"/></returns>
    public static ProblemDetails ThreadNotFound(string id) => new(Types.NotFound, Titles.ThreadNotFound, Statuses.NotFound, StringFormatter.Format(Details.ThreadNotFound, id));

    /// <summary>
    /// Creates a new <see cref="ProblemDetails"/> that describe an error that occurs when a run is in an unexpected status.
    /// </summary>
    /// <param name="id">The unique identifier of the run that is in an unexpected status.</param>
    /// <param name="status">The run's status.</param>
    /// <returns>A new <see cref="ProblemDetails"/></returns>
    public static ProblemDetails UnexpectedRunStatus(string id, string status) => new(Types.ValidationFailed, Titles.UnexpectedRunStatus, Statuses.ValidationFailed, StringFormatter.Format(Details.UnexpectedRunStatus, id, status));

}
