import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import NProgress from 'nprogress';
import { Provider } from 'react-redux'

import store from 'src/redux/store';
import Routes from './routes';

import './styles/index.scss';
import 'nprogress/nprogress.css';
import 'react-notifications/lib/notifications.css';

NProgress.configure({ minimum: 1 });

function App() {
  return (
    <Provider store={store}>
      <BrowserRouter>
        <Routes />
      </BrowserRouter>
    </Provider>
  );
}

const ROOT = document.getElementById('root');
ReactDOM.render(<App />, ROOT);
