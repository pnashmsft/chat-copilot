// Copyright (c) Microsoft. All rights reserved.

export interface IUserSettings {
    id: string;
    userId: string;
    darkMode: boolean;
    planners: boolean;
    personas: boolean;
    simplifiedChatExperience: boolean;
    azureContentSafety: boolean;
    azureAISearch: boolean;
    exportChatSessions: boolean;
    liveChatSessionSharing: boolean;
    feedbackFromUser: boolean;
    deploymentGPT35: boolean;
    deploymentGPT4: boolean;
}
