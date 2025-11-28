import type { AttemptStatus } from "./models";

export interface AttemptCard {
    attemptId: number;
    assessmentId: number;
    title: string;
    description: string;
    startDate?: string;
    endDate?: string;
    submittedAt?: string | null;
    status: AttemptStatus;
    score?: number | null;
}
export interface AttemptListState {
    incompleteAttempts: AttemptCard[];
    completeAttempts: AttemptCard[];
    
}