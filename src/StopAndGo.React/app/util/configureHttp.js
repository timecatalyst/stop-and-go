import {configureHttp as _configureHttp} from 'truefit-react-utils';

function createAxiosConfig() {
  return {
    baseURL: process.env.API_BASE_URL,
  };
}

export function configureHttp() {
  _configureHttp(createAxiosConfig);
}
