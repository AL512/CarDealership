import { FC, ReactElement } from 'react';
import {Outlet, Route, Routes} from 'react-router-dom';
import SigninOidc from './auth/SigninOidc';
import SignoutOidc from './auth/SignoutOidc';
import userManager, {
    loadUser,
    signinRedirect,
    signoutRedirect
} from './auth/user-service'
import {AboutPage} from "./pages/AboutPage";
import {Navigation} from "./components/Navigation";
import {CarListPage} from "./pages/CarListPage";
import {CarDetailsPage} from "./pages/CarDetailsPage";
import {Cars} from "./components/cars/Cars";


const App: FC<{}> = (): ReactElement => {
    loadUser();
    return (
        <>
            <Navigation/>
            <Routes>
                <Route path="/" element={<AboutPage />}/>
                <Route path="/cars" element={<Cars />}>
                    <Route index element={<CarListPage />}/>
                    <Route path=":id" element={<CarDetailsPage />} />
                </Route>
                <Route path="/signin-oidc" element={<SigninOidc />} />
                <Route path="/signout-oidc" element={<SignoutOidc />} />
                <Route path="*" element={<h2>Ресурс не найден</h2>} />
            </Routes>
        </>
    );
};

export default App;
