import type { AttemptUIState } from "../../types/attemptDetailState";

export const initialState: AttemptUIState = {
    attemptId: 0,
    assessmentId: 0,
    status: "NotStarted",
    asgTitle: "",
    startDate: "",
    endDate: "",
    questions: [],
    answers: [],
    currentQuestionIndex: 0,
};