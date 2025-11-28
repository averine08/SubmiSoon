import { createContext } from "react";
import { type AttemptUIState, type AnswerValue } from "../../types/attemptDetailState";



interface AttemptDetailContextType{
    state: AttemptUIState;
    loadAttempt: (attemptId : number) => Promise<void>;
    setActiveQuestion: (questionId: number) => void;
    saveAnswer: (attemptId: number, answer: AnswerValue) => Promise<void>;
}

export const AttemptDetailContext = createContext<AttemptDetailContextType | null>(null);



