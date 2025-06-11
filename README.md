This repository houses a prototype project focused on exploring **event-driven architecture** using **Apache Kafka** and its integration with ASP.NET microservices. The goal is to provide a hands-on environment for learning how to build scalable and reactive systems.

## Architecture
![Untitled-2025-06-11-1026](https://github.com/user-attachments/assets/2cba5fff-0fde-4851-afa5-24620a69f62c)

## Requirements

Ensure you have the following installed:

* **.NET 8.0 SDK**
* **Docker Desktop** (for running Kafka and Zookeeper)

## Getting Started

Follow these steps to get the project up and running:

1.  **Clone the Repository:**
    ```bash
    git clone https://github.com/abdullahoday710/Kafka-dotnet-CAP
    cd KafkaCAPPlayground
    ```

2.  **Start Docker Services:**
   Start the necessary Kafka and Zookeeper and postgres containers:
    ```bash
    docker-compose up -d
    ```
    The `-d` flag runs the containers in detached mode, so they run in the background.

    TIP : to see all your running detached docker instances you can use the command ```docker container ls```
3. **populate the databases**
   
   Now we need to create the tables for our database, Simply run these commands
   
   ```update-database -Project BillingService -StartupProject BillingService```
   
   ```update-database -Project OrderService -StartupProject OrderService```
    
5.  **Run a Microservice:**

    * **Using Visual Studio:**
        Open the `KafkaCAPPlayground.sln` file in Visual Studio. You can then select and run any of the individual microservices within the solution.

    * **Using the .NET CLI:**
        From the root directory, you can run the default `OrderService` microservice directly:
        ```bash
        dotnet run --project OrderService/OrderService.csproj
        ```

---

## Useful dev commands cheat sheet
- Add a migration to a specific microservice : ```add-migration {Migration name} -Project {Microservice name} -StartupProject {Microservice name}```
- Update the database for a specific microservice : ```update-database -Project {Microservice name} -StartupProject {Microservice name}```
