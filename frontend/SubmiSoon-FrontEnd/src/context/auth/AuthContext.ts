import { createContext } from "react";
import type { AuthState } from "../../types/auth";
import type { LoginRequest } from "../../api/authApi";
import { initialState } from "./AuthInitialState";

export const AuthContext = createContext<{
    state: AuthState;
    login: (data: LoginRequest) => Promise<void>;
    logout: () => void;
}>({
    state: initialState,
    login: async() => {},
    logout: () => {},
})