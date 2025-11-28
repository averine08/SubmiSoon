import type { AttemptCard } from "../types/attemptListState";
import { api } from "./axios";


export async function fetchIncompleteAttemptsApi(): Promise<AttemptCard[]> {
    const response = await api.get("/attemptlist/incomplete");
    return response.data;
}

export async function fetchCompleteAttemptsApi(): Promise<AttemptCard[]> {
    const response = await api.get("/attemptlist/complete");
    return response.data
}