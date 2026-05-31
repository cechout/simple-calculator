<img width="2560" height="810" alt="Title" src="https://github.com/user-attachments/assets/5fc4473f-89c1-49ba-a5d5-22cd9d90b4cf" />

###

This project focuses on modernizing an already **fully completed WPF calculator app**. The goal is to port the application natively to **WinUI 3** (Windows 11 Fluent Design) and to refactor its underlying architecture to the **MVVM (Model-View-ViewModel)** pattern.

## 📖 Project Background & Vision: WPF to WinUI 3 & MVVM

### The Foundation (WPF - Completed)
The original WPF application is finished and serves as a stable reference point for the entire project.
* **Status:** Finished (Archived at Tag `v1.0.0`).
* **Scope:** A simple standard arithmetic calculator and a real-time currency converter.
* **Architecture:** Built with WPF using a custom navigation system, classic XAML styling, and UI-coupled code-behind logic.

### The Goal (WinUI 3 - In Progress)
The objective is to make the app look and feel native to Windows 11 while establishing a clean, maintainable codebase.
* **UI Modernization (WinUI 3):** Replacing all old UI parts with native WinUI elements. Moving away from custom WPF workarounds to use official Windows App SDK controls like `NavigationView`.
* **Architectural Shift (MVVM):** Transitioning from code-behind to a strict MVVM architecture. This decouples the mathematical logic from the user interface, utilizing proper data binding and commands.
* **Logic Improvements:** Refactoring the underlying math engine to improve the cumbersome input system and provide a solid foundation for new calculation features.

## 🛠️ How to Run

To build and run this project, it is highly recommended to use **Visual Studio 2022** (Version 17.0 or later). 
Before opening the solution, make sure you have the following workloads installed via the **Visual Studio Installer**:

* **.NET Desktop Development**
* **Windows application development** (Make that the "Windows App SDK C# Templates" are checked in the optional components on the right side).

### 2. Clone the Repository
```ps
git close https://github.com/cechout/simple-calculator.git
```

### 3. Build and Run
* Open the solution file in Visual Studio.
* Right-click on `Calculator_WinUI` in the Solution Explorer and select Set as `Startup Project`.
* In the top toolbar, change the Solution Platform from `Any CPU` to your specific system architecture (e.g., `x64`). *Note: WinUI 3 projects do not support 'Any CPU' builds.*
* Press `F5` to build and run the application.

And now you're good to go!
