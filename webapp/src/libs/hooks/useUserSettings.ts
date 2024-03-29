// Copyright (c) Microsoft. All rights reserved.

import { useMsal } from '@azure/msal-react';
import { getErrorDetails } from '../../components/utils/TextUtils';
import { useAppDispatch } from '../../redux/app/hooks';
import { addAlert } from '../../redux/features/app/appSlice';
import { AuthHelper } from '../auth/AuthHelper';
import { AlertType } from '../models/AlertType';
import { UserSettingsService } from '../services/UserSettingsService';

export const useUserSettings = () => {
    const dispatch = useAppDispatch();
    const { instance, inProgress } = useMsal();
    const userSettingsService = new UserSettingsService();

    const updateUserSettings = async (userId: string, darkMode: boolean) => {
        try {
            return await userSettingsService.updateUserSettingsAsync(
                userId,
                darkMode,
                await AuthHelper.getSKaaSAccessToken(instance, inProgress),
            );
        } catch (e: any) {
            const errorMessage = `Unable to settings record for user. Details: ${getErrorDetails(e)}`;
            dispatch(addAlert({ message: errorMessage, type: AlertType.Error }));
        }

        return [];
    };

    const getUserSettings = async (userId: string) => {
        try {
            return await userSettingsService.getUserSettingsAsync(
                userId,
                await AuthHelper.getSKaaSAccessToken(instance, inProgress),
            );
        } catch (e: any) {
            const errorMessage = `Unable to get user settings. Details: ${getErrorDetails(e)}`;
            dispatch(addAlert({ message: errorMessage, type: AlertType.Error }));
        }

        return [];
    };

    return {
        updateUserSettings,
        getUserSettings,
    };
};
