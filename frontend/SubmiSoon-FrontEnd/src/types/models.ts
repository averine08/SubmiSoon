export type QuestionType = "essay" | "mcq" | "file";

export interface Choice {
    choiceId: number;
    // questionId: number;
    text: string;
}

export interface Question {
    questionId: number;
    questionText: string;
    questionType: QuestionType;
    choice: Choice[];
}

export interface Assessment {
    assessmentId: number;
    title: string;
    description: string;
    startDate: string;   // string because from API (ISO)
    endDate: string;
    questions: Question[];
}

export interface Answer {
    questionId: number;
    essayAnswer?: string | null;
    chosenAnswerId?: number | null;
    filePath?: string | null;  
    LastUpdate : string;
}

export type AttemptStatus = "NotStarted" | "Draft" | "OnReview" | "Complete";

export interface Attempt {
    attemptId: number;
    studentId: number;
    assessmentId: number;
    submittedAt: string | null;
    status: AttemptStatus;
    score?: number | null;
    answers: Answer[];
}
