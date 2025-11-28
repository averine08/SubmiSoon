// import { useState } from 'react'
// import reactLogo from './assets/react.svg'
// import viteLogo from '/vite.svg'
import './App.css'
import { Navigate, Route, Routes } from 'react-router-dom'
import Login from './pages/Login'
import ProtectedRoute from './components/ProtectedRoute'
import Dashboard from './pages/Dashboard'
import { useContext } from 'react'
import { AuthContext } from './context/auth/AuthContext'
import Assessment from './pages/Assessment'
import MainLayout from './components/layout/MainLayout'

function App() {
  const {state} = useContext(AuthContext);
  return (
    <Routes>
      <Route path='/login' element={<Login/>}/>
      
      <Route path= "/" element={<ProtectedRoute><MainLayout/></ProtectedRoute>}>
        <Route index element={<Navigate to= "/dashboard"/>}/>
        <Route path="dashboard" element={<Dashboard/>}/>
        <Route path="assessment" element={<Assessment/>}/>
        {/* <Route path="assesssment/:id" element={<Attempt/>}/> */}
      </Route>
      <Route
        path='/dashboard'
        element={
          <ProtectedRoute>
            <Dashboard/>
          </ProtectedRoute>
        }
      />

      <Route
        path='/assessment'
        element= {<Navigate to="/dashboard"/>}
      />

      <Route
        path='/assessment/incomplete'
        element= {<Navigate to="/dashboard"/>}
      />

      <Route
        path='*'
        element= {
          state.token || localStorage.getItem("token")
          ? <Navigate to="/dashboard" replace />
          : <Navigate to="/login" replace />
        }
      />

    
    </Routes>

    
    
  )
}

export default App
