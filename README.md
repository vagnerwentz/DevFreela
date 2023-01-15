# DevFreela

> A system simulation to publish a project that one freelancer can get.

## Features

- [X] Create, edit, remove, list a project.
- [X] Start a project as a freelancer.
- [X] Finish a project as a client.
- [X] Possibility to create comments about the project.
- [X] Freelancer skills.
- [X] SignIn e SignUp.
- [X] List users.


## 💻 Technologies

- .NET
- Docker (SQL Server and RabbitMQ)
- RabbitMQ (Synchronous calls to this [repository](https://github.com/vagnerwentz/DevFreela.Payments)

## Architecture, patterns e concepts.

- Clean Architecture
- Design Patterns
- CQRS
- Asynchronous and Synchronous

## Something that I liked.

> In this project, I learned more about RabbitMQ, which was used to make asynchronous calls to the [DevFreela.Payments](https://github.com/vagnerwentz/DevFreela.Payments) repository
> at the time of finalization, when sending a finalization request, in the SQL database, the status of the project was changed to `PaymentPending` and after that, it was sent
> to the file called `Payments` where the DevFreela.Payments repository was listening in the background to this queue, and when receiving it, it executed the necessary code
> for the approval of a payment, and with that, it published again after success, in another queue called `PaymentApproved`, in which this repository
> listened to this queue, and upon receiving the `ProjectId`, it searched the base for this project, and thus changed the project status to `Completed`.
> So there was synchronous communication between the two services.
