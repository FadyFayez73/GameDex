# GameDex
GameDex is an open-source project aimed at creating an application for managing a personal game library. It started as a project using ASP.NET Core MVC and evolved to include multi-platform support with React and Electron. The project features an independent API server and a data layer, with flexibility for developing new ideas.

## Current Features

- An API server (GameDex.APIServer) supporting React and ASP.NET Core MVC interfaces.

- A structured data layer (GameDex.DataLayer) for storing and managing game data.

- The core logic in (GameDex.Core).

- An initial web interface using ASP.NET Core MVC (GameDex.WebLayer).

- Desktop application support using Electron.

- A modern user interface using React (react-app).

## Technologies Used

- Backend: ASP.NET Core MVC and a custom API server

- Frontend: React (with SPA support) and ASP.NET Core MVC (non-SPA)

- Desktop: Electron

- Storage: Custom DataLayer

- Version Control: Git

## How to Run

### 1- Clone the project:

```
git clone https://github.com/FadyFayez73/GameDex.git
```

### 2- Navigate to the folder:
```
cd GameDex
```

### 3- Open the project in Visual Studio and run the GameDex.sln file.

### 4- Ensure you have the required development environment:

- .NET SDK for ASP.NET Core and API.

- Node.js and npm for React.

### 5- Build the project:

- Start the server (GameDex.APIServer) first.

- Open react-app or GameDex.WebLayer depending on the interface you want to use.

## History and Evolution

- The project began as a web application using ASP.NET Core MVC but was paused to develop a new idea.

- React and Electron were added to support a multi-platform concept.

- The project remains open for experimentation and redirection based on the developer's vision.

## Future Plans

- Define a new vision for the project (e.g., a game management tool or analysis utility).

- Add support for external APIs (e.g., IGDB or Steam).

- Enhance the user interface (either MVC or React).

- Release a downloadable demo version.

## How to Contribute

- Open an Issue if you find a bug or have a suggestion.

- Fork the project, modify the code, and submit a Pull Request.

- Add comments to the code to facilitate collaboration.
