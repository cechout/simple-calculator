# Simple Calculator (WinUI 3 Port) 

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![WinUI 3](https://img.shields.io/badge/WinUI_3-0078D7?style=for-the-badge&logo=windows&logoColor=white)

This project focuses on modernizing an already **fully completed WPF calculator app**. The goal of this is to port the entire application natively to **WinUI 3** and the Windows 11 Fluent Design.

## 📖 Project Background & Vision: WPF to WinUI 3

### The Foundation (WPF - Completed)
The original WPF application is finished and serves as a stable reference point for the entire project.
* **Status:** Finished (Archived at Tag `v1.0.0`).
* **Scope:** A simple standard arithmetic calculator and a real-time currency converter.
* **Design:** Built with WPF using a custom navigation system and classic XAML styling.

### The Goal (WinUI 3 - In Progress)
The goal is to make the app look and feel fully native to Windows 11.
* **WinUI Elements:** Replacing all old UI parts (buttons, fonts, and scrollviewers) with native WinUI elements.
* **Official Controls:** Moving away from custom WPF workarounds to use native WinUI 3 controls like `NavigationView`.
* **Logic Improvements:** I am refactoring the underlying math engine to improve the cumbersome input system and planning to maybe even implement new calculation features.

## 📸 Screenshots (from finished WPF application)

| Standard Mode | Currency Converter | Menu Navigation |
| :---: | :---: | :---: |
| <img width="100%" alt="Screenshot 2026-04-28 141547" src="https://github.com/user-attachments/assets/9bd1cd4c-d372-4e83-9170-d41fc65416ad" /> | <img width="100%" alt="Screenshot 2026-04-28 141608" src="https://github.com/user-attachments/assets/af23e8a1-22df-486d-abb0-644a163ba3c5" /> | <img width="99%" alt="Screenshot 2026-04-28 141556" src="https://github.com/user-attachments/assets/5be56816-5357-4a8b-8e02-7e4f454168ff" /> |

## 🛠️ How to Run

To build and run this project, it is highly recommended to use **Visual Studio 2022** (Version 17.0 or later). 
Before opening the solution, make sure you have the following workloads installed via the **Visual Studio Installer**:

* **.NET Desktop Development**
* **Windows application development** (Make that the "Windows App SDK C# Templates" are checked in the optional components on the right side).

Now just set `Calculator_WinUI` as your Startup Project and Press **F5** to build and run the application.
