import type { AttemptDetailAction } from "../../types/attemptDetailAction";
import type { AttemptUIState } from "../../types/attemptDetailState";

export const attemptDetailReducer = (
    state: AttemptUIState,
    action : AttemptDetailAction
): AttemptUIState => {
    switch (action.type){
        case "SET_ACTIVE_ATTEMPT":
            return {
                ...state,
                ...action.payload,
            };
        case "SET_ACTIVE_QUESTION": {
            return {
                ...state,
                currentQuestionIndex : action.payload.questionId
            }
        }
        case "SAVE_ANSWER": {
            const newAnswer = action.payload.answer;

            return {
                ...state,
                answers : [
                    ...state.answers.filter(a => a.questionId !== newAnswer.questionId),
                    newAnswer
                ]
            }
        }
        
        case "SET_ATTEMPT_STATUS":
            return {...state, status : action.payload};
            
        case "RESET_ATTEMPT":
            return {
                attemptId: 0,
                assessmentId: 0,
                status : "NotStarted",
                asgTitle: "",
                startDate : "",
                endDate : "",
                questions: [],
                answers : [],
                currentQuestionIndex: 0
            };
        default:
            return state;
    }
}
