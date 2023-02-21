import { UserManager, UserManagerSettings } from 'oidc-client';
import { setAuthHeader } from './auth-headers';

const userManagerSettings: UserManagerSettings = {
    client_id: 'cardealership-web-app',
    redirect_uri: 'http://localhost:3001/signin-oidc',
    response_type: 'code',
    scope: 'openid profile СarDealershipWebAPI',
    authority: 'https://localhost:44386/',
    post_logout_redirect_uri: 'http://localhost:3001/signout-oidc',
};

const userManager = new UserManager(userManagerSettings);
export async function loadUser() {
    const user = await userManager.getUser();
    console.log('User: ', user);
    const token = user?.access_token;
    setAuthHeader(token);
}

export const signinRedirect = () => userManager.signinRedirect();

export const signinRedirectCallback = () => {
    userManager.signinRedirectCallback();
    //loadUser();
}

export const signoutRedirect = (args?: any) => {
    userManager.clearStaleState();
    userManager.removeUser();
    return userManager.signoutRedirect(args);
};

export const signoutRedirectCallback = () => {
    userManager.clearStaleState();
    userManager.removeUser();
    return userManager.signoutRedirectCallback();
};

export default userManager;
