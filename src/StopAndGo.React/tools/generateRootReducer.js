/* eslint-disable no-console */
import _ from 'lodash';
import dir from 'node-dir';
import fs from 'fs';
import path from 'path';

dir.subdirs(
  path.resolve(__dirname, '../app/features'),
  (err1, directoryPaths) => {
    if (err1) throw err1;

    const features = _.reduce(
      directoryPaths,
      (result, directoryPath) => {
        const matches = directoryPath.match(
          /features(?:[/\\])(.+?)(?:[/\\])reducers$/,
        );
        if (!matches) return result;

        return [...result, matches[1]];
      },
      [],
    );
    features.sort();

    const rootReducerContents = [
      "import {combineReducers} from 'redux-immutable';",
      ...features.map(
        feature => `import ${feature} from './features/${feature}/reducers';`,
      ),

      '\nconst rootReducer = combineReducers({',
      '  features: combineReducers({',
      ...features.map(feature => `    ${feature},`),
      '  }),',
      '});\n',

      'export default rootReducer;\n',
    ].join('\n');

    fs.writeFile(
      path.resolve(__dirname, '../app/rootReducer.js'),
      rootReducerContents,
      err2 => {
        if (err2) throw err2;
      },
    );
  },
);
