using System.Text.Json.Serialization;

namespace CopilotChat.WebApi.Models.Request;

/// <summary>
/// Parameters for editing particular message.
/// </summary>
public class EditUserSettingsParameters
{
  /// <summary>
  /// User Settings ID
  /// </summary>
  [JsonPropertyName("id")]
  public string? id { get; set; }

  /// <summary>
  /// User ID
  /// </summary>
  [JsonPropertyName("userId")]
  public string? userId { get; set; }

  /// <summary>
  /// Dark Mode enabled?
  /// </summary>
  [JsonPropertyName("darkMode")]
  public bool? darkMode { get; set; }

}
