import type { AuthState, User } from "../../types/auth";

export const initialState: AuthState = {
    user: JSON.parse(localStorage.getItem("user") || "null") as User || null,
    token: localStorage.getItem("token"),
    loading: false,
}