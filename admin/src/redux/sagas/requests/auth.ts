import authService from "src/services/auth-service";

export function requestGetUser() {
    return authService.getUserAsync();
}

export function completeLogin() {
    return authService.completeLoginAsync(window.location.href);
}

export function loginRequest() {
    return authService.loginAsync();
}

export function logoutRequest() {
    return authService.logoutAsync();
}

export function logoutCallBack() {
    return authService.completeLogoutAsync(window.location.href);
}