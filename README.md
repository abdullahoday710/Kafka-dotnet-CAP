This repository houses a prototype project focused on exploring **event-driven architecture** using **Apache Kafka** and its integration with ASP.NET microservices. The goal is to provide a hands-on environment for learning how to build scalable and reactive systems.

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
   Start the necessary Kafka and Zookeeper containers:
    ```bash
    docker-compose up -d
    ```
    The `-d` flag runs the containers in detached mode, so they run in the background.

    TIP : to see all your running detached docker instances you can use the command ```docker container ls```

4.  **Run a Microservice:**

    * **Using Visual Studio:**
        Open the `KafkaCAPPlayground.sln` file in Visual Studio. You can then select and run any of the individual microservices within the solution.

    * **Using the .NET CLI:**
        From the root directory, you can run the default `OrderService` microservice directly:
        ```bash
        dotnet run
        ```

---
