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

  /// <summary>
  /// Planners enabled?
  /// </summary>
  [JsonPropertyName("planners")]
  public bool? planners { get; set; }

  /// <summary>
  /// Personas enabled?
  /// </summary>
  [JsonPropertyName("personas")]
  public bool? personas { get; set; }

  /// <summary>
  /// Simplified Chat Experience?
  /// </summary>
  [JsonPropertyName("simplifiedChatExperience")]
  public bool? simplifiedChatExperience { get; set; }

  /// <summary>
  /// Azure Content Safety enabled?
  /// </summary>
  [JsonPropertyName("azureContentSafety")]
  public bool? azureContentSafety { get; set; }

  /// <summary>
  /// Azure AI Search enabled?
  /// </summary>
  [JsonPropertyName("azureAISearch")]
  public bool? azureAISearch { get; set; }

  /// <summary>
  /// Export Chat Sessions enabled?
  /// </summary>
  [JsonPropertyName("exportChatSessions")]
  public bool? exportChatSessions { get; set; }

  /// <summary>
  /// Live Chat Session Sharing enabled?
  /// </summary>
  [JsonPropertyName("liveChatSessionSharing")]
  public bool? liveChatSessionSharing { get; set; }

  /// <summary>
  /// Reinforced Learning from User Feedback enabled?
  /// </summary>
  [JsonPropertyName("feedbackFromUser")]
  public bool? feedbackFromUser { get; set; }

  /// <summary>
  /// Azure OpenAI Deployment Name gpt-35-turbo
  /// </summary>
  [JsonPropertyName("deploymentGPT35")]
  public bool? deploymentGPT35 { get; set; }

  /// <summary>
  /// Azure OpenAI Deployment Name gpt-4
  /// </summary>
  [JsonPropertyName("deploymentGPT4")]
  public bool? deploymentGPT4 { get; set; }
}
