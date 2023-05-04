# zomujo-phoenix

- Outbox Pattern (for domain events)
- Inbox pattern (for integration events)
- Event-Driven Architecture
- Mediator Pattern
- Domain-driven development
- In-Memory Events Bus (using MediatR notifications)

# TODO
- Switch all ID types to Guids
- Alert frontend guys of server and client methods to call and implement for hub interactions
- Implement Doctors, Counsellors, Pharma Auth Processors
- Use background job to manage redis data (esp. in Docs module)
- Optimize db tables (Drug, Drugs)
- Complete event handlers (UserDeletedEvent)
- Use **Humanizer** package
- Add health checks (db checks already implemented)
- Get credentials from firebase console and use path
- Find a way to handle publish failures (retries) so as to maintain data integrity
- Make all commands and other classes have *internal* access