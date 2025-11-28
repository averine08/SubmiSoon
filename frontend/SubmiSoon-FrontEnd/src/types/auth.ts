export interface User {
    id : number;
    name: string;
    email:string;
    role: string;
}

export interface AuthState {
    user : User | null;
    token : string | null;
    loading :boolean;
}

export type AuthAction = 
| {type : "LOGIN_REQUEST"}
| {type: "LOGIN_FAILED"}
| {type: "LOGIN_SUCCESS", payload: {user: User | null; token: string}}
| {type: "LOGOUT"};
