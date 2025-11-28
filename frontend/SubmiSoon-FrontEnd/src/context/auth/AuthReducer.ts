import type { AuthAction, AuthState } from "../../types/auth";

export function authReducer(state: AuthState, action: AuthAction): AuthState {
    switch (action.type) {
        case "LOGIN_REQUEST":
            return {...state, loading: true};
        
        case "LOGIN_FAILED":
            return {...state, loading: false};

        case "LOGIN_SUCCESS":
            return {
                loading : false,
                user: action.payload.user,
                token: action.payload.token,
            };
        
        case "LOGOUT":
            return {
                user: null,
                token: null,
                loading: false,
            }
        default:
            return state;
    }
}