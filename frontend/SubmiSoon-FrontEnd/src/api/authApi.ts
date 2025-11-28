import type { User } from "../types/auth";
import { api } from "./axios";

export interface LoginRequest {
    email: string;
    password: string;
}

export interface LoginResponse {
    token: string;
    user: User;
}

export async function loginApi(data: LoginRequest): Promise<LoginResponse> {
    const response = await api.post("/auth/login", data);
    return response.data
}