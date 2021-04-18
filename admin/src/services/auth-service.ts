import { User, UserManager, UserManagerSettings } from "oidc-client";

import { CallBackEndpoints } from "src/constants/configs";

const oidcSettings: UserManagerSettings = {
  authority: "https://localhost:5000",
  client_id: "admin",
  redirect_uri: CallBackEndpoints.redirect_uri,
  post_logout_redirect_uri: CallBackEndpoints.post_logout_redirect_uri,
  response_type: "code",
  scope: "api openid profile offline_access",
  automaticSilentRenew: true,
  includeIdTokenInSilentRenew: true,
};

class AuthService {
  public userManager: UserManager;

  constructor() {
    this.userManager = new UserManager(oidcSettings);
  }

  public getUserAsync(): Promise<User | null> {
    return this.userManager.getUser();
  }

  public loginAsync(): Promise<void> {
    return this.userManager.signinRedirect();
  }

  public completeLoginAsync(url: string): Promise<User> {
    return this.userManager.signinCallback(url);
  }

  public renewTokenAsync(): Promise<User> {
    return this.userManager.signinSilent();
  }

  public logoutAsync(): Promise<void> {
    return this.userManager.signoutRedirect();
  }

  public async completeLogoutAsync(url: string): Promise<void> {
    await this.userManager.signoutCallback(url);
  }
}

export default new AuthService();
