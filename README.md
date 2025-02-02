# AGData Assessment

## Application
The **application** successfully integrates an Angular 15 frontend with a .NET Core 6 RESTful API, ensuring smooth communication between the two. The frontend allows users to input their **name and address**, with validation ensuring that the name field is **required**. The API processes and returns the entered data as a mock response, demonstrating the **interaction between the UI and backend**. Inline validation has been added to improve user experience, replacing alerts with real-time feedback on missing fields.

## Technical
The **AGDataAssessment.Server** project adheres to **technical best practices**, incorporating Domain-Driven Design (DDD) principles to separate concerns across Domain, Application, Infrastructure, and Presentation layers. Dependency Injection (DI) is used to ensure modularity and testability, while SOLID principles guide the architecture for maintainability and scalability. Unit tests have been configured to validate core business logic and ensure the stability of the application.

## Tooling
From a **tooling** perspective, the entire solution is structured within Visual Studio, allowing seamless development, debugging, and execution. The **Angular and .NET projects** have been combined into a **single solution, with automated build steps** ensuring proper execution. The application compiles with no errors, runs cleanly, and has an easy local setup for quick deployment. Additionally, the testing environment has been optimized by ensuring that all required modules are properly declared, making the project fully functional and production-ready.
