// Copyright (c) Microsoft. All rights reserved.

using System.Collections.Generic;
using System.Threading.Tasks;
using CopilotChat.WebApi.Models.Storage;

namespace CopilotChat.WebApi.Storage;

/// <summary>
/// A repository for user settings.
/// </summary>
public class UserSettingsRepository : Repository<UserSettings>
{
    /// <summary>
    /// Initializes a new instance of the UserSettingsRepository class.
    /// </summary>
    /// <param name="storageContext">The storage context.</param>
    public UserSettingsRepository(IStorageContext<UserSettings> storageContext)
        : base(storageContext)
    {
    }

    /// <summary>
    /// Finds settings by user id.
    /// </summary>
    /// <param name="userId">The user id.</param>
    /// <returns>Settings of the user id.</returns>
    public Task<IEnumerable<UserSettings>> FindSettingsByUserIdAsync(string userId)
    {
        return base.StorageContext.QueryEntitiesAsync(e => e.UserId == userId);
    }
}
