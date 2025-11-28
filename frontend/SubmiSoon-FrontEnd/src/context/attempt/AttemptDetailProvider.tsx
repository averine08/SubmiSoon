import { useReducer, type ReactNode } from "react";
import { attemptDetailReducer } from "./AttemptDetailReducer";
import { initialState } from "./AttemptDetailInitialState";
import { fetchAttemptDetailApi, saveAnswerApi } from "../../api/attemptDetailApi";
import type { AnswerValue } from "../../types/attemptDetailState";
import { AttemptDetailContext } from "./AttemptDetailContext";

export const AttemptDetailProvider = ({ children }: { children: ReactNode}) => {
    const [state, dispatch] = useReducer(attemptDetailReducer, initialState);

    async function loadAttempt(attemptId: number) {
        const res = await fetchAttemptDetailApi(attemptId)

        dispatch({
            type: "SET_ACTIVE_ATTEMPT",
            payload: {
                ...res, 
                currentQuestionIndex: 0,
            },
        });
    }

    function setActiveQuestion(questionId: number){
        dispatch ({
            type: "SET_ACTIVE_QUESTION",
            payload : {questionId},
        })
    }
    async function saveAnswer(attemptId: number, answer: AnswerValue) {
        dispatch({
            type: "SAVE_ANSWER",
            payload: { answer },
        });

        
        const res = await saveAnswerApi(attemptId, answer);
        
        const backendAnswer: AnswerValue = res.data;

        // Timpa placeholder dengan yang resmi dari DB
        dispatch({
        type: "SAVE_ANSWER",
        payload: { answer: backendAnswer }
        });
    }


    return (
        <AttemptDetailContext.Provider
        value={{
            state,
            loadAttempt,
            setActiveQuestion,
            saveAnswer,
        }}
        >
        {children}
        </AttemptDetailContext.Provider>
    );

};