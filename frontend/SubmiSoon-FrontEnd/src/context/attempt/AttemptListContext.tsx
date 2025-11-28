import type React from "react";
import { createContext } from "react";
import type { AttemptListState } from "../../types/attemptListState";
import type { AttemptListAction } from "../../types/attemptListAction";

export const initialStateAttempt : AttemptListState = {
    incompleteAttempts : [],
    completeAttempts: [],
}

interface AttemptListContext {
    state : AttemptListState;
    dispatch: React.Dispatch<AttemptListAction>;
    loadIncompleteAttempts: () => Promise<void>;
    loadCompleteAttempts: () => Promise<void>
} 


export const AttemptListContext = createContext<AttemptListContext>( {} as AttemptListContext);


