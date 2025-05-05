namespace AgentCommunicationProtocol.Commands.Threads;

/// <summary>
/// Represents the command used to create a new thread.
/// </summary>
[Description("Represents the command used to create a new thread.")]
[DataContract]
public class CreateThreadCommand
    : Command<Models.Thread>
{

    /// <summary>
    /// Gets or sets the unique identifier of the thread to create. If not provided, an random UUID will be generated.
    /// </summary>
    [Description("The unique identifier of the thread to create. If not provided, an random UUID will be generated.")]
    [DataMember(Name = "thread_id", Order = 1), JsonPropertyName("thread_id"), JsonPropertyOrder(1), YamlMember(Alias = "thread_id", Order = 1)]
    public virtual string? ThreadId { get; set; }

    /// <summary>
    /// Gets or sets a key/value mapping of the metadata properties, if any, to associate to the thread to create
    /// </summary>
    [Description("A key/value mapping of the metadata properties, if any, to associate to the thread to create.")]
    [DataMember(Name = "metadata", Order = 2), JsonPropertyName("metadata"), JsonPropertyOrder(2), YamlMember(Alias = "metadata", Order = 2)]
    public virtual EquatableDictionary<string, object>? Metadata { get; set; }

    /// <summary>
    /// Gets/sets the strategy used to handle duplicate creation. Defaults to 'raise'.
    /// </summary>
    [Description("The strategy used to handle duplicate creation. Defaults to 'raise'.")]
    [AllowedValues(ThreadIfExistStrategy.Raise, ThreadIfExistStrategy.DoNothing), DefaultValue(ThreadIfExistStrategy.Raise)]
    [DataMember(Name = "if_exists", Order = 3), JsonPropertyName("if_exists"), JsonPropertyOrder(3), YamlMember(Alias = "if_exists", Order = 3)]
    public virtual string IfExists { get; set; } = ThreadIfExistStrategy.Raise;

}
