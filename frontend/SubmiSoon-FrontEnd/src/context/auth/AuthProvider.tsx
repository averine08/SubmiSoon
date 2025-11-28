import {  useReducer, type ReactNode } from "react";
import { loginApi, type LoginRequest } from "../../api/authApi";
import { authReducer } from "./AuthReducer";
import { initialState } from "./AuthInitialState";
import { AuthContext } from "./AuthContext";

export const AuthProvider = ({ children }: { children: ReactNode }) => {
    const [state, dispatch] = useReducer(authReducer, initialState);
    console.log(state);

    async function login(data: LoginRequest) {
        dispatch({ type: "LOGIN_REQUEST" });

        try{
            const result = await loginApi(data);
            console.log(result)
            
            localStorage.setItem("token", result.token);
            localStorage.setItem("user", JSON.stringify(result.user));
            
            dispatch({
            type: "LOGIN_SUCCESS",
            payload: { user: result.user, token: result.token },
            });

        }catch(error){
            dispatch({ type: "LOGIN_FAILED"});
            throw error;
        }
    }

    function logout() {
        localStorage.removeItem("token");
        localStorage.removeItem("user");
        dispatch({ type: "LOGOUT" });
    }

    return (
        <AuthContext.Provider value={{ state, login, logout }}>
        {children}
        </AuthContext.Provider>
    );
};