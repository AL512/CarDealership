import { FC, ReactElement } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import AuthProvider from './auth/auth-provider';
import SigninOidc from './auth/SigninOidc';
import SignoutOidc from './auth/SignoutOidc';
import CarList from './carinfo/CarList';
import userManager, {
    loadUser,
    signinRedirect,
    signoutRedirect
} from './auth/user-service'
import './App.css';

const App: FC<{}> = (): ReactElement => {
    loadUser();
    return (
        <div className="App">
            <header className="App-header">
                <button onClick={() => signinRedirect()}>Войти</button>
                <AuthProvider userManager={userManager}>
                    <Router>
                        <Routes>
                            <Route path="/" element={<CarList />} />
                            <Route path="/signin-oidc" element={<SigninOidc />} />
                            <Route path="/signout-oidc" element={<SignoutOidc />} />
                        </Routes>
                    </Router>
                </AuthProvider>
            </header>
        </div>
    );
};

export default App;
