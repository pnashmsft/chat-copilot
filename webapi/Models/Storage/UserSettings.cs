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
    /// The partition key for the source.
    /// </summary>
    [JsonIgnore]
    public string Partition => this.UserId;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserSettings"/> class.
    /// </summary>
    /// <param name="userId">Settings belong to this user.</param>
    /// <param name="darkMode">Is Dark Mode enabled?</param>
    public UserSettings(string userId, bool? darkMode)
    {
        this.Id = Guid.NewGuid().ToString();
        this.UserId = userId;
        this.DarkMode = darkMode ?? false;
    }
}
