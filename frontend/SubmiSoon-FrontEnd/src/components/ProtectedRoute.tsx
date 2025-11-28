import { type JSX } from 'react'
import { Navigate } from 'react-router-dom';



interface Props {
    children: JSX.Element;
}

const ProtectedRoute = ({ children }: Props) => {

    const storedToken = localStorage.getItem("token");

    if (!storedToken) {
        return <Navigate to="/login" replace />;
    }

    return children;
};


export default ProtectedRoute