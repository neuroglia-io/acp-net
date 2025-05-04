namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents a message.
/// </summary>
[Description("Represents a message.")]
[DataContract]
public record Message
{

    /// <summary>
    /// Gets or sets the message's unique identifier.
    /// </summary>
    [Description("The message's unique identifier.")]
    [Required, MinLength(1)]
    [DataMember(Name = "id", Order = 1), JsonPropertyName("id"), JsonPropertyOrder(1), YamlMember(Alias = "id", Order = 1)]
    public virtual string Id { get; set; } = null!;

    /// <summary>
    /// Gets or sets the message's role.
    /// </summary>
    [Description("The message's role.")]
    [Required, MinLength(1)]
    [DataMember(Name = "role", Order = 2), JsonPropertyName("role"), JsonPropertyOrder(2), YamlMember(Alias = "role", Order =2)]
    public virtual string Role { get; set; } = null!;

    /// <summary>
    /// Gets or sets the message's content.
    /// </summary>
    [Description("The message's content.")]
    [Required, MinLength(1)]
    [DataMember(Name = "content", Order = 3), JsonPropertyName("content"), JsonPropertyOrder(3), YamlMember(Alias = "content", Order = 3)]
    public virtual EquatableList<MessageTextBlock> Content { get; set; } = null!;

    /// <summary>
    /// Gets or sets the message's metadata, if any.
    /// </summary>
    [Description("The message's metadata, if any.")]
    [Required]
    [DataMember(Name = "metadata", Order = 4), JsonPropertyName("metadata"), JsonPropertyOrder(4), YamlMember(Alias = "metadata", Order = 4)]
    public virtual EquatableDictionary<string, object>? Metadata { get; set; } = null!;

}
