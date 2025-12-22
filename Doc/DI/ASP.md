ASP.NET Core Service Lifetimes

This document summarizes service lifetimes in ASP.NET Core with real-time examples.

Transient (AddTransient)

Created: Every time requested.

Disposed: When the consuming object is disposed (or GC collects it if parent is transient).

Use case: Lightweight, stateless services.

Example:
builder.Services.AddTransient<IEmailService, EmailService>();

EmailService is created every time OrderService asks for it.

Multiple requests create multiple instances.

Real-Time Flow:
HTTP Request Start
|
Create OrderService (Scoped)
|
|-- Create EmailService (Transient)
|
Use EmailService
|
HTTP Request End
|
Dispose OrderService
|
Dispose EmailService

Scoped (AddScoped)

Created: Once per HTTP request.

Shared: Across services within the same request.

Disposed: At the end of the request.

Use case: Business logic, DbContext.

Example:
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<AppDbContext>();

One OrderService instance per request.

Shared DbContext for all services in request.

Singleton (AddSingleton)

Created: Once for the entire application.

Shared: Across all requests and users.

Disposed: When app shuts down.

Use case: Caching, configuration, shared data.

Example:
builder.Services.AddSingleton<IProductCache, ProductCache>();

ProductCache is the same for all requests.

Key Rules:

Transient: created every time requested, short-lived.

Scoped: one per request, shared within request.

Singleton: one for app lifetime, shared across all.

Parent Dependency Considerations:
Parent Service: Scoped → Transient disposed at end of request
Parent Service: Transient → Transient disposed when GC collects it
Parent Service: Singleton → Transient disposed at app shutdown (bad if holding transient)

Common Mistakes:

Injecting Scoped into Singleton → lifetime mismatch.

Using heavy objects as Transient → unnecessary GC pressure.

Using DbContext as Transient → multiple instances, inconsistent data.

Real-Life Analogy:
Singleton → Store inventory (shared for all)
Scoped → Cashier per customer (per request)
Transient → Receipt printer (new for every use)

References:

Microsoft Docs: Dependency Injection in ASP.NET Core

Real-time e-commerce example: Order processing, EmailService, ProductCache