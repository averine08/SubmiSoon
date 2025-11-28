import type { AnswerValue, AttemptUIState } from "./attemptDetailState";
import type { AttemptStatus } from "./models";

export type AttemptDetailAction =
    | { type: "SET_ACTIVE_ATTEMPT"; payload: AttemptUIState }
    | { type : "SET_ACTIVE_QUESTION"; payload : {questionId: number}}
    | { type: "SAVE_ANSWER"; payload: { answer: AnswerValue } }
    | { type: "SET_ATTEMPT_STATUS"; payload: AttemptStatus }
    | { type: "RESET_ATTEMPT" };
