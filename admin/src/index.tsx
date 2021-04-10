import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import NProgress from 'nprogress';

import Routes from './routes';

import './styles/index.css';
import 'nprogress/nprogress.css';

NProgress.configure({ minimum: 1 });

function App() {
  return (
    <BrowserRouter>
      <Routes />
    </BrowserRouter>
  );
}

ReactDOM.render(<App />, document.getElementById('root'));
