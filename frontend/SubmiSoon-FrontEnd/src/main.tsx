import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import { BrowserRouter } from 'react-router-dom'
import { AuthProvider } from './context/auth/AuthProvider.tsx'
import { AttemptListProvider } from './context/attempt/AttemptProvider.tsx'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <BrowserRouter>
      <AuthProvider>
        <AttemptListProvider>
        <App />
        </AttemptListProvider>
      </AuthProvider>
    </BrowserRouter>
  </StrictMode>,
)
