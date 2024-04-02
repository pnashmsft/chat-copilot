// Copyright (c) Microsoft. All rights reserved.

export interface IUserSettings {
    id: string;
    userId: string;
    darkMode: boolean;
    plannersAndPersonas: boolean;
    simplifiedChatExperience: boolean;
    azureContentSafety: boolean;
    azureAISearch: boolean;
    exportChatSessions: boolean;
    liveChatSessionSharing: boolean;
    feedbackFromUser: boolean;
}
