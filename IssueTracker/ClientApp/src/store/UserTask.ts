import { Action, Reducer } from 'redux';
import { AppThunkAction } from './';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface UserTaskState {
    isLoading: boolean;
    tasks: UserTask[];
    taskId?: number;
}

export interface UserTask {
    id: number;
    date: string;
    name: string;
    type: string;
    description: string;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestUserTasksAction {
    type: 'REQUEST_USER_TASKS';
}

interface RequestUserTaskAction {
    type: 'REQUEST_USER_TASK';
    taskId: number;
}

interface ReceiveUserTasksAction {
    type: 'RECEIVE_USER_TASKS';
    tasks: UserTask[];
}

interface ReceiveUserTaskAction {
    type: 'RECEIVE_USER_TASK';
    tasks: UserTask[];
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestUserTasksAction | ReceiveUserTasksAction | RequestUserTaskAction | ReceiveUserTaskAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestUserTasks: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        const appState = getState();
        if (appState && appState.tasks) {
            fetch(`api/usertask`)
                .then(response => response.json() as Promise<UserTask[]>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_USER_TASKS', tasks: data });
                });

            dispatch({ type: 'REQUEST_USER_TASKS'});
        }
    },

    requestUserTask: (taskId: number): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        const appState = getState();
        if (appState && appState.tasks) {
            fetch(`api/usertask/${taskId}`)
                .then(response => response.json() as Promise<UserTask[]>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_USER_TASK', tasks: data });
                });

            dispatch({ type: 'REQUEST_USER_TASK', taskId });
        }
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: UserTaskState = { tasks: [], isLoading: false };

export const reducer: Reducer<UserTaskState> = (state: UserTaskState | undefined, incomingAction: Action): UserTaskState => {
    if (state === undefined) {
        return unloadedState;
    }

    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'REQUEST_USER_TASKS':
            return {
                tasks: state.tasks,
                isLoading: true
            };
        case 'RECEIVE_USER_TASKS':
            // Only accept the incoming data if it matches the most recent request. This ensures we correctly
            // handle out-of-order responses.
            return {
                tasks: action.tasks,
                isLoading: false
            };

        default:
            return state;
    }
};
