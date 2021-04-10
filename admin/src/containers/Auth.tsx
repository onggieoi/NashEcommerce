import React, { useEffect } from "react";
import { useHistory, useParams } from "react-router-dom";

import InlineLoader from "src/components/InlineLoader";
import authService from "src/services/auth-service";

const Auth = () => {
    const history = useHistory();
    const { action } = useParams<{ action: string }>();

    useEffect(() => {
        (async () => {
            console.log("isRun?");

            switch (action) {
                case "login":
                    await authService.loginAsync();
                    break;

                case "login-callback":
                    await authService.completeLoginAsync(window.location.href);
                    const user = await authService.getUserAsync();
                    console.log(user);
                    history.push("/");
                    break;

                default:
                    break;
            }
        })();
    }, [history, action]);

    return <InlineLoader></InlineLoader>;
};

export default Auth;
