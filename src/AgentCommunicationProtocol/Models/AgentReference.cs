namespace AgentCommunicationProtocol.Models;

/// <summary>
/// Represents a reference to an Agent Record in the Agent Directory.
/// </summary>
[Description("Represents a reference to an Agent Record in the Agent Directory.")]
[DataContract]
public record AgentReference
{

    /// <summary>
    /// Gets or sets the agent's name.
    /// </summary>
    [Description("The agent's name.")]
    [Required, MinLength(1)]
    [DataMember(Name = "name", Order = 1), JsonPropertyName("name"), JsonPropertyOrder(1), YamlMember(Alias = "name", Order = 1)]
    public virtual string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the agent's version.
    /// </summary>
    [Description("The agent's version.")]
    [Required, MinLength(1), RegularExpression("^(0|[1-9]\\d*)\\.(0|[1-9]\\d*)\\.(0|[1-9]\\d*)(?:-((?:0|[1-9]\\d*|\\d*[a-zA-Z-][0-9a-zA-Z-]*)(?:\\.(?:0|[1-9]\\d*|\\d*[a-zA-Z-][0-9a-zA-Z-]*))*))?(?:\\+([0-9a-zA-Z-]+(?:\\.[0-9a-zA-Z-]+)*))?$")]
    [DataMember(Name = "version", Order = 1), JsonPropertyName("version"), JsonPropertyOrder(1), YamlMember(Alias = "version", Order = 1)]
    public virtual string Version { get; set; } = null!;

    /// <summary>
    /// Gets or sets the record's URL. Can be a network location, i.e. an entry in the Agent Directory or a file.
    /// </summary>
    [Description("The record's URL. Can be a network location, i.e. an entry in the Agent Directory or a file.")]
    [DataMember(Name = "url", Order = 3), JsonPropertyName("url"), JsonPropertyOrder(3), YamlMember(Alias = "url", Order = 3)]
    public virtual Uri? Url { get; set; }

    /// <inheritdoc/>
    public override string ToString() => $"{Name}:{Version}";

}