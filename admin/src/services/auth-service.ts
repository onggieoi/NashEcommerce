import { User, UserManager, UserManagerSettings } from "oidc-client";

import { CallBackEndpoints, UrlBackEnd } from "src/constants/configs";

const oidcSettings: UserManagerSettings = {
  authority: UrlBackEnd,
  client_id: "admin",
  redirect_uri: CallBackEndpoints.redirect_uri,
  post_logout_redirect_uri: CallBackEndpoints.post_logout_redirect_uri,
  response_type: "id_token token",
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

  public loginAsync(): Promise<User> {
    return this.userManager.signinPopup();
  }

  public completeLoginAsync(url: string): Promise<User | undefined> {
    return this.userManager.signinPopupCallback(url);
  }

  public renewTokenAsync(): Promise<User> {
    return this.userManager.signinSilent();
  }

  public logoutAsync(): Promise<void> {
    return this.userManager.signoutPopup();
  }

  public async completeLogoutAsync(url: string): Promise<void> {
    await this.userManager.signoutPopupCallback(url);
  }
}

export default new AuthService();
