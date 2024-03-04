using System;
using System.Text.Json.Serialization;

namespace CopilotChat.WebApi.Models.Response;

/// <summary>
/// Configuration to be used by the frontend client to this service.
/// </summary>
public class FrontendConfig
{
  [JsonPropertyName("headerTitle")]
  public string HeaderTitle { get; set; } = string.Empty;

  [JsonPropertyName("headerTitleColor")]
  public string HeaderTitleColor { get; set; } = string.Empty;

  [JsonPropertyName("headerBackgroundColor")]
  public string HeaderBackgroundColor { get; set; } = string.Empty;

  [JsonPropertyName("headerIcon")]
  public string HeaderIcon { get; set; } = string.Empty;

  [JsonPropertyName("headerSettingsEnabled")]
  public Boolean HeaderSettingsEnabled { get; set; } = false;

  [JsonPropertyName("headerPluginsEnabled")]
  public Boolean HeaderPluginsEnabled { get; set; } = false;

  [JsonPropertyName("documentUploadEnabled")]
  public Boolean DocumentUploadEnabled { get; set; } = false;

  [JsonPropertyName("createNewChat")]
  public Boolean CreateNewChat { get; set; } = false;

}
