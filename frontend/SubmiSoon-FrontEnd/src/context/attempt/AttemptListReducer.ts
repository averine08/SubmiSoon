import type { AttemptListAction } from "../../types/attemptListAction";
import type { AttemptListState } from "../../types/attemptListState";

export const attemptListReducer = (
    state : AttemptListState,
    action : AttemptListAction
): AttemptListState => {
    switch (action.type){
        case "SET_INCOMPLETE_LIST":
            return {
                ...state,
                incompleteAttempts : action.payload
            };
        
        case "SET_COMPLETE_LIST":
            return {
                ...state,
                completeAttempts : action.payload
            }
        default : 
            return state;
    }
};