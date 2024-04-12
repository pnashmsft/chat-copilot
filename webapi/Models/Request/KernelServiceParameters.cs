using System.Text.Json.Serialization;

namespace CopilotChat.WebApi.Models.Request;

/// <summary>
/// Parameters for editing particular message.
/// </summary>
public class KernelServiceParameters
{
  /// <summary>
  /// Azure OpenAI Deployment Name
  /// </summary>
  [JsonPropertyName("deployment")]
  public string? deployment { get; set; }

}
