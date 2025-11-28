import React, { useContext, useEffect, useState } from "react"
import { AuthContext } from "../context/auth/AuthContext"
import type { LoginRequest } from "../api/authApi";
import { useNavigate } from "react-router-dom";

const Login = () => {
    console.log("LOGIN PAGE RENDERED");
    const { login, state } = useContext(AuthContext);
    const navigate = useNavigate();

    const [form, setForm] = useState<LoginRequest>({
        email: "",
        password: "",
    });

    const [error, setError] = useState("");

    useEffect(() => {
        console.log("STATE UPDATED:", state);
    }, [state]);


    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setError("");
        try{
            
            await login(form);
            console.log(state)
            navigate("/dashboard");
        }catch (err){
            setError("Email atau password salah !");
        }

    }
    return (
        <div className='w-1vw h-lvh bg-[#4789E6] flex flex-col justify-center items-center'>
            <div className=" px-2 py-4 ">
                <div>
                    <form onSubmit={handleSubmit} >
                        <div className=" bg-white border-base-300 rounded-box w-xs border px-4 py-8">
                            <h1 className="text-2xl text-center my-4 font-bold text-[#4789E6]">SubmiSoon</h1>

                            <label htmlFor="email_input" className="label">Email</label>
                            <input id="email_input" type="email" className="input mb-2 focus:outline-0" placeholder="Email" value={form.email} onChange={e=> setForm({...form, email: e.target.value})} required/>

                            <label htmlFor="password_input" className="label">Password</label>
                            <input id="password_input"  type="password" className="input focus:outline-0 " placeholder="Password" value={form.password} onChange={e=> setForm({...form, password: e.target.value})} required />

                            {error && (
                                <div className="my-2 text-red-600 text-xs text-center bg-red-100 py-2 mx-4 rounded">
                                    {error}
                                </div>
                            )}

                            <button
                                type="submit"
                                className="btn btn-block mt-2 bg-[#FD9F4D] text-white disabled:opacity-60">
                                    {state.loading? "Loading..." : "Login"}
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    )
}

export default Login