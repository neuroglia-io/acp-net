namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents an object used to record an agent run.
/// </summary>
/// <typeparam name="TRun">The type of recorded run.</typeparam>
[Description("Represents an object used to record an agent's run.")]
[DataContract]
public abstract record RunRecord<TRun>
    : IRunRecord<TRun>
    where TRun : Run
{

    /// <summary>
    /// Gets or sets the run's unique identifier.
    /// </summary>
    [Description("The run's unique identifier.")]
    [Required, MinLength(1)]
    [DataMember(Name = "run_id", Order = 1), JsonPropertyName("run_id"), JsonPropertyOrder(1), YamlMember(Alias = "run_id", Order = 1)]
    public virtual required string Id { get; set; } = null!;

    /// <summary>
    /// Gets or sets the unique identifier of the thread, if any, the run belongs to.
    /// </summary>
    [Description("The unique identifier of the thread, if any, the run belongs to.")]
    [DataMember(Name = "thread_id", Order = 2), JsonPropertyName("thread_id"), JsonPropertyOrder(2), YamlMember(Alias = "thread_id", Order = 2)]
    public virtual string? ThreadId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the agent the run concerns.
    /// </summary>
    [Description("The unique identifier of the agent the run concerns.")]
    [Required, MinLength(1)]
    [DataMember(Name = "agent_id", Order = 3), JsonPropertyName("agent_id"), JsonPropertyOrder(3), YamlMember(Alias = "agent_id", Order = 3)]
    public virtual required string AgentId { get; set; } = null!;

    /// <summary>
    /// Gets or sets the date and time the run was created at.
    /// </summary>
    [Description("The date and time the run was created at.")]
    [Required]
    [DataMember(Name = "created_at", Order = 4), JsonPropertyName("created_at"), JsonPropertyOrder(4), YamlMember(Alias = "created_at", Order = 4)]
    public virtual required DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the date and time the run was last updated at.
    /// </summary>
    [Description("The date and time the run was last updated at.")]
    [Required]
    [DataMember(Name = "updated_at", Order = 5), JsonPropertyName("updated_at"), JsonPropertyOrder(5), YamlMember(Alias = "updated_at", Order = 5)]
    public virtual required DateTimeOffset UpdatedAt { get; set; }

    /// <summary>
    /// Gets or sets the run's status.
    /// </summary>
    [Description("The run's status.")]
    [Required, AllowedValues(RunStatus.Pending, RunStatus.Error, RunStatus.Success, RunStatus.Timeout, RunStatus.Interrupted)]
    [DataMember(Name = "status", Order = 6), JsonPropertyName("status"), JsonPropertyOrder(6), YamlMember(Alias = "status", Order = 6)]
    public virtual string Status { get; set; } = RunStatus.Pending;

    /// <summary>
    /// Gets or sets the run's output, if any.
    /// </summary>
    [Description("The run's output, if any.")]
    [DataMember(Name = "output", Order = 7), JsonPropertyName("output"), JsonPropertyOrder(7), YamlMember(Alias = "output", Order = 7)]
    public virtual RunOutput? Output { get; set; }

    /// <inheritdoc/>
    public abstract TRun AsRun();

    Run IRunRecord.AsRun() => AsRun();

}