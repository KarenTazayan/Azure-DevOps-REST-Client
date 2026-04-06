---
applyTo: "**/*.cs"
---

# Async Programming Rules (Event Handlers)

## ❗ async void usage

- NEVER use `async void` except for **UI event handlers**.
- All other asynchronous methods MUST return `Task` or `Task<T>`.

## ✅ Event handler pattern

Event handlers MUST follow one of these patterns:

### Preferred (explicit)

```csharp
private async void SomeEventHandler(object sender, EventArgs e)
{
    try
    {
        await HandleAsync();
    }
    catch (Exception ex)
    {
        // Handle/log exception (no unobserved exceptions)
    }
}