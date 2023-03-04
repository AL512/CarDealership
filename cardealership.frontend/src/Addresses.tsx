import {UserManagerSettings} from "oidc-client";

export const userManagerSettings: UserManagerSettings = {
    client_id: 'cardealership-web-app',
    redirect_uri: 'http://localhost:3001/signin-oidc',
    response_type: 'code',
    scope: 'openid profile СarDealershipWebAPI',
    authority: 'https://localhost:44386/',
    post_logout_redirect_uri: 'http://localhost:3001/signout-oidc',
};

export const apiServerUrl: string = 'https://localhost:44397'