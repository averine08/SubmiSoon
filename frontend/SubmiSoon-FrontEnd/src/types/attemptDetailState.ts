import type { AttemptStatus, Question } from "./models";

export interface AnswerValue {
    answerId: number;
    questionId: number;
    type: "essay" | "mcq" | "file";
    essayAnswer?: string;
    choosenId?: number
    filePath?: string
    lastUpdate?: string

};


export interface AttemptUIState {
    attemptId: number;
    assessmentId: number;
    status: AttemptStatus;
    asgTitle : string;
    startDate : string;
    endDate : string;
    questions: Question[];
    answers: AnswerValue[];
    currentQuestionIndex: number;
}

