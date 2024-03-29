// Copyright (c) Microsoft. All rights reserved.

import { IUserSettings } from '../models/UserSettings';
import { BaseService } from './BaseService';

export class UserSettingsService extends BaseService {
    public updateUserSettingsAsync = async (
        userId: string,
        darkMode: boolean,
        accessToken: string,
    ): Promise<IUserSettings> => {
        const body = {
            userId,
            darkMode,
        };

        const result = await this.getResponseAsync<IUserSettings>(
            {
                commandPath: `settings/${userId}`,
                method: 'POST',
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
