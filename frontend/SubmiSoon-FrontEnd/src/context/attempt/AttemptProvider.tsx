import { useReducer, type ReactNode } from "react";
import { attemptListReducer } from "./AttemptListReducer";
import { AttemptListContext, initialStateAttempt } from "./AttemptListContext";
import { fetchCompleteAttemptsApi, fetchIncompleteAttemptsApi } from "../../api/attemptListApi";


export const AttemptListProvider = ({ children } : { children: ReactNode }) => {
    const [state, dispatch] = useReducer(attemptListReducer, initialStateAttempt);

    async function loadIncompleteAttempts() {

            const result = await fetchIncompleteAttemptsApi();
            // console.log(result);

            dispatch({ type:"SET_INCOMPLETE_LIST", payload: result});

    };

    async function loadCompleteAttempts() {
        const result = await fetchCompleteAttemptsApi();
        // console.log(result);
        dispatch({ type: "SET_COMPLETE_LIST", payload : result})
    };
        
        return (
            <AttemptListContext.Provider
            value = {{ 
                state,
                dispatch,
                loadIncompleteAttempts,
                loadCompleteAttempts
                }}>
                {children}
                </AttemptListContext.Provider>
            )
        
};