// Copyright (c) Microsoft. All rights reserved.

using System;
using System.Text.Json.Serialization;
using CopilotChat.WebApi.Storage;

namespace CopilotChat.WebApi.Models.Storage;

/// <summary>
/// User specific settings set via the Settings dialog.
/// </summary>
public class UserSettings : IStorageEntity
{
    /// <summary>
    /// Settings ID that is persistent and unique.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// User ID that is persistent and unique.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Dark Mode enabled?
    /// </summary>
    public bool? DarkMode { get; set; }

    /// <summary>
    /// Planners and Personas enabled?
    /// </summary>
    public bool? PlannersAndPersonas { get; set; }

    /// <summary>
    /// Simplified Chat Experience?
    /// </summary>
    public bool? SimplifiedChatExperience { get; set; }

    /// <summary>
    /// Azure Content Safety enabled?
    /// </summary>
    public bool? AzureContentSafety { get; set; }

    /// <summary>
    /// Azure AI Search enabled?
    /// </summary>
    public bool? AzureAISearch { get; set; }

    /// <summary>
    /// Export Chat Sessions enabled?
    /// </summary>
    public bool? ExportChatSessions { get; set; }

    /// <summary>
    /// Live Chat Session Sharing enabled?
    /// </summary>
    public bool? LiveChatSessionSharing { get; set; }

    /// <summary>
    /// Reinforced Learning from User Feedback enabled?
    /// </summary>
    public bool? FeedbackFromUser { get; set; }

    /// <summary>
    /// The partition key for the source.
    /// </summary>
    [JsonIgnore]
    public string Partition => this.UserId;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserSettings"/> class.
    /// </summary>
    /// <param name="userId">Settings belong to this user.</param>
    /// <param name="darkMode">Is Dark Mode enabled?</param>
    /// <param name="plannersAndPersonas">Planners and Personas enabled?</param>
    /// <param name="simplifiedChatExperience">Simplified Chat Experience?</param>
    /// <param name="azureContentSafety">Azure Content Safety enabled?</param>
    /// <param name="azureAISearch">Azure AI Search enabled?</param>
    /// <param name="exportChatSessions">Export Chat Sesssions enabled?</param>
    /// <param name="liveChatSessionSharing">Live Chat Session Sharing enabled?</param>
    /// <param name="feedbackFromUser">Reinforced Learning From User Feedback enabled?</param>
    public UserSettings(string userId, bool? darkMode, bool? plannersAndPersonas, bool? simplifiedChatExperience, bool? azureContentSafety,
    bool? azureAISearch, bool? exportChatSessions, bool? liveChatSessionSharing, bool? feedbackFromUser)
    {
        this.Id = Guid.NewGuid().ToString();
        this.UserId = userId;
        this.DarkMode = darkMode ?? false;
        this.PlannersAndPersonas = plannersAndPersonas ?? false;
        this.SimplifiedChatExperience = simplifiedChatExperience ?? false;
        this.AzureContentSafety = azureContentSafety ?? false;
        this.AzureAISearch = azureAISearch ?? false;
        this.ExportChatSessions = exportChatSessions ?? false;
        this.LiveChatSessionSharing = liveChatSessionSharing ?? false;
        this.FeedbackFromUser = feedbackFromUser ?? false;
    }
}
