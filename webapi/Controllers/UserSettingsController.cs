// Copyright (c) Microsoft. All rights reserved.

using System;
using System.Threading.Tasks;
using CopilotChat.WebApi.Hubs;
using CopilotChat.WebApi.Models.Request;
using CopilotChat.WebApi.Models.Storage;
using CopilotChat.WebApi.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace CopilotChat.WebApi.Controllers;

/// <summary>
/// Controller for managing retrieving/updating user settings.
/// </summary>
[ApiController]
public class UserSettingsController : ControllerBase
{
    private readonly ILogger<UserSettingsController> _logger;
    private readonly UserSettingsRepository _userSettingsRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserSettingsController"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="userSettingsRepository">The user settings repository.</param>
    public UserSettingsController(
        ILogger<UserSettingsController> logger,
        UserSettingsRepository userSettingsRepository)
    {
        this._logger = logger;
        this._userSettingsRepository = userSettingsRepository;
    }

    /// <summary>
    /// Get all settings for a user.
    /// </summary>
    /// <param name="userId">The user id to retrieve settings for.</param>
    [HttpGet]
    [Route("settings/{userId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserSettingsAsync(Guid userId)
    {
        var settings = await this._userSettingsRepository.FindSettingsByUserIdAsync(userId.ToString());

        return this.Ok(settings);
    }

    /// <summary>
    /// Update user settings.
    /// </summary>
    /// <param name="msgParameters">Params to update settings.</param>
    [HttpPatch]
    [Route("settings/{userId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateUserSettingsAsync(
        [FromServices] IHubContext<MessageRelayHub> messageRelayHubContext,
        [FromBody] EditUserSettingsParameters msgParameters,
        [FromRoute] Guid userId)
    {
        if (msgParameters.userId != null)
        {
            UserSettings? us = (UserSettings?)await this._userSettingsRepository.FindSettingsByUserIdAsync(userId.ToString());
            if (us != null)
            {
                // Update existing settings record for this user
                us!.DarkMode = msgParameters.darkMode;
                await this._userSettingsRepository.UpsertAsync(us);

                return this.Ok(us);
            }

            // Create a new settings record for this user 
            var newUserSettings = new UserSettings(msgParameters.userId, msgParameters.darkMode);
            await this._userSettingsRepository.createUserSettings(newUserSettings);

            return this.Ok(us);
        }

        return this.NotFound("User ID was not sent to update user settings'.");
    }
}
