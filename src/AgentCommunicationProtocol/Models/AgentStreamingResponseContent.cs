namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents the result of an agent invocation that produces a stream of output chat messages
/// </summary>
[DataContract, Description("The result of an agent invocation that produces a stream of output chat messages")]
public record AgentStreamingMessageContent
{

    /// <summary>
    /// Initializes a new <see cref="AgentStreamingMessageContent"/>
    /// </summary>
    public AgentStreamingMessageContent() { }

    /// <summary>
    /// Initializes a new <see cref="AgentStreamingMessageContent"/>
    /// </summary>
    /// <param name="content">The content of the streaming message.</param>
    /// <param name="role">The role associated with the message, if any.</param>
    /// <param name="metadata">Additional metadata associated with the message, if any.</param>
    public AgentStreamingMessageContent(string? content, string? role = null, IReadOnlyDictionary<string, object>? metadata = null)
    {
        Content = content;
        Role = role;
        Metadata = metadata;
    }

    /// <summary>
    /// Gets or sets the content of the streaming chat message.
    /// </summary>
    [Description("The message's content")]
    [DataMember(Name = "content", Order = 1), JsonPropertyName("content"), JsonPropertyOrder(1), YamlMember(Alias = "content", Order = 1)]
    public virtual string? Content { get; set; }

    /// <summary>
    /// Gets or sets the role associated with the streaming message, if any.
    /// </summary>
    [Description("The message's role")]
    [DataMember(Name = "role", Order = 2), JsonPropertyName("role"), JsonPropertyOrder(2), YamlMember(Alias = "role", Order = 2)]
    public virtual string? Role { get; set; }

    /// <summary>
    /// Gets or sets any metadata associated with the streaming message.
    /// </summary>
    [Description("The message's metadata, if any")]
    [DataMember(Name = "metadata", Order = 3), JsonPropertyName("metadata"), JsonPropertyOrder(3), YamlMember(Alias = "metadata", Order = 3)]
    public virtual IReadOnlyDictionary<string, object>? Metadata { get; set; }

}
