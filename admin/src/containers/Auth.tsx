import React, { useEffect } from "react";
import { useDispatch } from "react-redux";
import { useHistory, useParams } from "react-router-dom";

import InlineLoader from "src/components/InlineLoader";
import { login, loginCallBack, logoutCallBack } from "src/redux/ducks/auth";

const Auth = () => {
    const history = useHistory();
    const { action } = useParams<{ action: string }>();
    const dispatch = useDispatch();

    useEffect(() => {
        switch (action) {
            case "login":
                dispatch(login());
                break;

            case "login-callback":
                dispatch(loginCallBack());
                break;

            case "logout-callback":
                dispatch(logoutCallBack());
                break;

            default:
                break;
        }
    }, [history, action]);

    return <InlineLoader></InlineLoader>;
};

export default Auth;
