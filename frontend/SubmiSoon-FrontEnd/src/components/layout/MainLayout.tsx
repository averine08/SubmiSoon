import { useContext } from "react";
import { Outlet, useNavigate } from "react-router-dom"
import { AuthContext } from "../../context/auth/AuthContext";

const MainLayout = () => {
    const navigate = useNavigate();
    const {state, logout} = useContext(AuthContext);

    const handleLogout = () => {
        logout()
        navigate("/login");

    }

    return (
        <div className="flex relative flex-1 overflow-hidden flex-col min-h-screen bg-gray-30">

            <header className="flex fixed top-0 z-20 items-center justify-between w-full h-12 bg-white shadow  px-6">
                <div className="text-xl font-bold text-[#4789E6]">SubmiSoon</div>
                <button onClick={handleLogout} className="text-sm hover:bg-red-100 transition hover:text-red-500 p-2 rounded-lg cursor-pointer">Log Out</button>
            </header>

            <div className="flex h-[calc(100vh-80px)] mt-12 bg-gray-300">

                <div className="flex flex-col gap-8 w-56 bg-[#4789E6] text-white p-6">

                    <div className="bg-white text-black rounded-lg p-4 shadow-sm">
                        <div className="font-semibold">{state.user?.name}</div>
                        <div className="text-sm text-gray-600">{state.user?.role}</div>
                    </div>

                    <nav className="flex flex-col gap-4">
                        <a onClick={() => navigate("/dashboard")} className="hover:underline cursor-pointer">Dashboard</a>
                        <a onClick={() => navigate("/assessment")} className="hover:underline cursor-pointer">Assessment</a>
                    </nav>

                </div>

                <main className="flex-1 m-4 p-4 border bg-white rounded-lg overflow-y-auto">
                    <Outlet />
                </main>
            </div>

        {/* Footer */}
        <footer className="w-full h-8 bg-white shadow-inner flex items-center justify-center text-xs">
            All rights reserved @2025
        </footer>
        </div>
    )
}

export default MainLayout