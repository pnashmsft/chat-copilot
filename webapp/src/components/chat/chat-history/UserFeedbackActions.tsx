import { Button, Text, Tooltip, makeStyles } from '@fluentui/react-components';
import { useCallback, useState } from 'react';
import { UserFeedback } from '../../../libs/models/ChatMessage';
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
    messageIndex: number;
}

export const UserFeedbackActions: React.FC<IUserFeedbackProps> = ({ messageIndex }) => {
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

            dispatch(
                updateMessageProperty({
                    chatId: selectedId,
                    messageIdOrIndex: messageIndex,
                    property: 'userFeedback',
                    value: positive ? UserFeedback.Positive : UserFeedback.Negative,
                    frontLoad: true,
                }),
            );
        },
        [dispatch, messageIndex, selectedId],
    );

    return (
        <div className={classes.root}>
            <Text color="gray" size={200} align="start">
                AI-generated content may be incorrect
            </Text>
            <p>&nbsp;&nbsp;&nbsp;</p>
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
