# 🤖 ChatbotSkeleton

ChatbotSkeleton is a .NET MAUI chat app starter that provides a modern cross-platform UI shell for building an assistant-style experience.

The app currently includes a functional chat interface with:

- 💬 User and assistant message bubbles
- 🧭 Sidebar chat history
- ✨ New chat workflow
- ⌨️ Send-on-Enter behavior on Windows (Shift+Enter for newline)
- 🧪 Simple simulated assistant response (`Echo: ...`) for rapid UI testing

## 🚀 Why This Repo

Use this project as a clean starting point when you want to:

- ⚡ Prototype chat UX quickly
- 🧠 Add your own AI backend later (Azure OpenAI, local model, API gateway, etc.)
- 🌍 Ship one UI across Android, iOS, Mac Catalyst, and Windows

## 🛠️ Tech Stack

- .NET 10
- .NET MAUI (single project)
- C# + XAML
- `ObservableCollection<T>` data binding
- Custom `DataTemplateSelector` for user/bot message rendering

## 🗂️ Current Project Layout

```text
ChatbotSkeleton/
 App.xaml
 AppShell.xaml
 MainPage.xaml
 MainPage.xaml.cs
 MauiProgram.cs
 Models/
  ChatMessage.cs
 Selectors/
  ChatMessageTemplateSelector.cs
 Resources/
  Styles/
   Colors.xaml
   Styles.xaml
 Platforms/
  Android/
  iOS/
  MacCatalyst/
  Windows/
```

## 📋 Prerequisites

Install one of the following environments:

1. Visual Studio 2022 (or later) with .NET MAUI workload
2. .NET SDK 10 and MAUI workloads via CLI

Recommended checks:

```powershell
dotnet --version
dotnet workload list
```

If MAUI workloads are missing:

```powershell
dotnet workload install maui
```

## 🧱 Build

From the repository root:

```powershell
dotnet restore
dotnet build ChatbotSkeleton.slnx
```

Platform-specific build examples:

```powershell
dotnet build ChatbotSkeleton/ChatbotSkeleton.csproj -f net10.0-windows10.0.19041.0
dotnet build ChatbotSkeleton/ChatbotSkeleton.csproj -f net10.0-android
dotnet build ChatbotSkeleton/ChatbotSkeleton.csproj -f net10.0-ios
dotnet build ChatbotSkeleton/ChatbotSkeleton.csproj -f net10.0-maccatalyst
```

## ▶️ Run

Example for Windows:

```powershell
dotnet build ChatbotSkeleton/ChatbotSkeleton.csproj -t:Run -f net10.0-windows10.0.19041.0
```

For mobile and Mac targets, run from Visual Studio with a configured emulator/simulator/device.

## 🧠 Current Behavior Notes

- Sending a message adds it to the conversation and automatically scrolls to the bottom.
- The first user message in a chat session is captured as the chat-history title.
- Selecting a history entry currently loads a placeholder message (`Loaded: ...`).
- Assistant replies are mocked and should be replaced with your real service integration.

## 🛣️ Next Steps

Suggested enhancements:

1. Replace mocked echo response with a real chat service.
2. Introduce a view model layer and service abstractions.
3. Persist chat sessions to local storage.
4. Add streaming responses and cancellation.
5. Add unit tests for message/state logic.

## 📄 License

See `LICENSE.txt`.
