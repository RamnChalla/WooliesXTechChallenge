# WooliesXTechChallange
1. Clone the repository or download unzip provided zip folder . 2. Open the solution in Visual Studio 2019. 3. Run all unit test cases and all tests should paas 6. Hit Ctrl+F5 to run the web api application. 7. Swagger is included in the api project. 8. Check the output by running the console application

Project Design:

    Followed MediatR design pattern
    Followed SOLID principle to make components loosely coupled.
    Inbuilt dependency injection

Project Structure

    Solution contains folders - for each project
    NUnit Test Project is used for testing controller and domain/services.
    Moq is used for mocking
    web api project contains 3 main part - repository, services and Commands.
    test folder contains test cases to test only controller services. Additional time required to cover all the testing/

Technical debts:

    Solution can be extended for CQRS with db operations.
    More unit test needs to be added. Unit test cases can be improved using fluent assertions.
    Automapper easy to use for mapping.
    Detailed logging can be implemented.
    Fluent validation can be implemeted for view model validations by separating models and viewmodels.
    web application or console app to be used to display data
