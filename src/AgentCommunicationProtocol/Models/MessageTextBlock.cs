namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents a message's text block.
/// </summary>
[Description("Represents a message's text block.")]
[DataContract]
public record MessageTextBlock
{

    /// <summary>
    /// Gets or sets the message block's text.
    /// </summary>
    [Description("The message block's text.")]
    [Required, MinLength(1)]
    [DataMember(Name = "text", Order = 1), JsonPropertyName("text"), JsonPropertyOrder(1), YamlMember(Alias = "text", Order = 1)]
    public virtual string Text { get; set; } = null!;

    /// <summary>
    /// Gets or sets the message block's type.
    /// </summary>
    [Description("The message block's type.")]
    [Required, MinLength(1)]
    [DataMember(Name = "type", Order = 2), JsonPropertyName("type"), JsonPropertyOrder(2), YamlMember(Alias = "type", Order = 2)]
    public virtual string Type { get; set; } = null!;

    /// <summary>
    /// Gets or sets the message block's metadata, if any.
    /// </summary>
    [Description("The message block's metadata, if any.")]
    [Required]
    [DataMember(Name = "metadata", Order = 3), JsonPropertyName("metadata"), JsonPropertyOrder(3), YamlMember(Alias = "metadata", Order = 3)]
    public virtual EquatableDictionary<string, object>? Metadata { get; set; } = null!;

}