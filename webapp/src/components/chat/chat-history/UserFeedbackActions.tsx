import { Button, Tooltip, makeStyles } from '@fluentui/react-components';
import { useCallback, useState } from 'react';
import { useChat } from '../../../libs/hooks';
import { IChatMessage, UserFeedback } from '../../../libs/models/ChatMessage';
import { useAppDispatch, useAppSelector } from '../../../redux/app/hooks';
import { RootState } from '../../../redux/app/store';
import { updateMessageProperty } from '../../../redux/features/conversations/conversationsSlice';
import { ThumbDislike16, ThumbLike16 } from '../../shared/BundledIcons';

const useClasses = makeStyles({
    root: {
        display: 'flex',
        'place-content': 'flex-end',
        alignItems: 'center',
    },
});

interface IUserFeedbackProps {
    message: IChatMessage;
}

export const UserFeedbackActions: React.FC<IUserFeedbackProps> = ({ message }) => {
    const chat = useChat();
    const [thumbsUpAppearance, setThumbsUpAppearance] = useState<
        'secondary' | 'primary' | 'outline' | 'subtle' | 'transparent'
    >();
    const [thumbsDownAppearance, setThumbsDownAppearance] = useState<
        'secondary' | 'primary' | 'outline' | 'subtle' | 'transparent'
    >();
    const classes = useClasses();

    const dispatch = useAppDispatch();
    const { selectedId } = useAppSelector((state: RootState) => state.conversations);

    const onUserFeedbackProvided = useCallback(
        (positive: boolean) => {
            if (positive) {
                setThumbsUpAppearance('primary');
                setThumbsDownAppearance('transparent');
            } else {
                setThumbsUpAppearance('transparent');
                setThumbsDownAppearance('primary');
            }

            const messageID = typeof message.id === 'string' ? message.id : 0;
            const feedback = positive ? UserFeedback.Positive : UserFeedback.Negative;

            dispatch(
                updateMessageProperty({
                    chatId: selectedId,
                    messageIdOrIndex: messageID,
                    property: 'userFeedback',
                    value: feedback,
                    frontLoad: true,
                }),
            );

            // Persist to database
            void chat.updateChatMessage(message, feedback);
        },
        [chat, dispatch, message, selectedId],
    );

    return (
        <div className={classes.root}>
            <Tooltip content={'Like bot message'} relationship="label">
                <Button
                    icon={<ThumbLike16 />}
                    appearance={thumbsUpAppearance}
                    aria-label="Edit"
                    onClick={() => {
                        onUserFeedbackProvided(true);
                    }}
                />
            </Tooltip>
            <Tooltip content={'Dislike bot message'} relationship="label">
                <Button
                    icon={<ThumbDislike16 />}
                    appearance={thumbsDownAppearance}
                    aria-label="Edit"
                    onClick={() => {
                        onUserFeedbackProvided(false);
                    }}
                />
            </Tooltip>
        </div>
    );
};
