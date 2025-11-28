import type { AnswerValue } from "../types/attemptDetailState";
import { api } from "./axios";


export async function fetchAttemptDetailApi(attemptId: number){
    const res = await api.get(`/api/attempt/${attemptId}`);
    return res.data;
}

export async function saveAnswerApi(
    attemptId: number,
    answer: AnswerValue
) {
    const body = {
        questionId : answer.questionId,
        type: answer.type,
        essayAnswer: answer.essayAnswer,
        choosenId: answer.choosenId,
        filePath: answer.filePath,
    };

    const res = await api.post(`/api/attempt/${attemptId}/answer`,body)
    return res.data;
}