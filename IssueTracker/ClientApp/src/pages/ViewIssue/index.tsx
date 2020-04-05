import * as React from 'react';
import { connect } from 'react-redux';
import * as UserTaskStore from '../../store/UserTask';
import { ApplicationState } from '../../store';
import { RouteComponentProps } from 'react-router';

type ViewIssueProps =
    UserTaskStore.UserTaskState
    & typeof UserTaskStore.actionCreators
    & RouteComponentProps<{ taskId: string }>;

class ViewIssue extends React.PureComponent<ViewIssueProps> {
    public componentDidMount() {
        this.props.requestUserTasks();
    }

    render() {
        const { taskId } = this.props.match.params;
        console.log( parseInt(taskId));
        const currentTask = this.props.tasks.find((el) => el.id === parseInt(taskId));
        console.log(currentTask)
        return (
            <div>
                <h1>Issue details</h1>
                <div>
                    {
                        currentTask ?
                        currentTask.id
                        : 'No issue found'
                    }
                </div>
            </div>
        )
    }
}

export default connect(
    (state: ApplicationState) => state.tasks, // Selects which state properties are merged into the component's props
    UserTaskStore.actionCreators // Selects which action creators are merged into the component's props
)(ViewIssue as any);
