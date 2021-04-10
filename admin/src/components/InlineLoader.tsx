import React, { useEffect } from 'react';
import NProgress from 'nprogress';

const InlineLoader = () => {
  useEffect(() => {
    NProgress.start();

    return () => {
      NProgress.done();
    };
  });

  return <></>;
};

export default InlineLoader;