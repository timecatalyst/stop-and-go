import React from 'react';
import {Switch, Route} from 'react-router-dom';
import StopAndGoPage from './features/stopAndGo/components/StopAndGoPage';
import NotFoundPage from './features/shared/components/NotFoundPage';
import SystemErrorPage from './features/shared/components/SystemErrorPage';

export default function App() {
  return (
    <Switch>
      <Route path="/not-found" component={NotFoundPage} />
      <Route path="/system-error" component={SystemErrorPage} />

      {/* Feature routes start here */}

      <Route path="/" component={StopAndGoPage} />
      <Route component={NotFoundPage} />
    </Switch>
  );
}
