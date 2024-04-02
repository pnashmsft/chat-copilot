// Copyright (c) Microsoft. All rights reserved.

import { IUserSettings } from '../models/UserSettings';
import { BaseService } from './BaseService';

export class UserSettingsService extends BaseService {
    public updateUserSettingsAsync = async (
        userId: string,
        darkMode: boolean,
        plannersAndPersonas: boolean,
        simplifiedChatExperience: boolean,
        azureContentSafety: boolean,
        azureAISearch: boolean,
        exportChatSessions: boolean,
        liveChatSessionSharing: boolean,
        feedbackFromUser: boolean,
        accessToken: string,
    ): Promise<IUserSettings> => {
        const body = {
            userId,
            darkMode,
            plannersAndPersonas,
            simplifiedChatExperience,
            azureContentSafety,
            azureAISearch,
            exportChatSessions,
            liveChatSessionSharing,
            feedbackFromUser,
        };

        const result = await this.getResponseAsync<IUserSettings>(
            {
                commandPath: `settings/${userId}`,
                method: 'PATCH',
                body,
            },
            accessToken,
        );

        return result;
    };

    public getUserSettingsAsync = async (userId: string, accessToken: string): Promise<IUserSettings> => {
        const result = await this.getResponseAsync<IUserSettings>(
            {
                commandPath: `settings/${userId}`,
                method: 'GET',
            },
            accessToken,
        );

        return result;
    };
}
