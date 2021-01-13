# Stop & Go

A simple implementation of the game "Red Light, Green Light" using SignalR in C# and React.
Supports a single game across multiple players.

## Prerequisites
- [dotnet core 2.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/2.1)
- [yarn](https://yarnpkg.com)
- VS Code or Rider

## Development

### API Server
From the terminal, within the API project folder, run:
```sh
dotnet watch run
```

This will launch the API at http://localhost:5000.

### React App

From the terminal, within the React project folder, run:
```
yarn start
```
This will launch app at http://localhost:8000 and automatically open a new tab in the default web browser.
