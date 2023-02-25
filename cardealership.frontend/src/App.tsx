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
import {AboutPage} from "./pages/AboutPage";
import {Navigation} from "./components/Navigation";
import {CarListPage} from "./pages/CarListPage";


const App: FC<{}> = (): ReactElement => {
    loadUser();
    return (
        <>
            <Navigation/>
            <Routes>
                <Route path="/" element={<AboutPage />} />
                <Route path="/cars" element={<CarListPage />} />
                <Route path="/signin-oidc" element={<SigninOidc />} />
                <Route path="/signout-oidc" element={<SignoutOidc />} />
            </Routes>
        </>
    );
};

export default App;
