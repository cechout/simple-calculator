# Modern Windows Calculator (WinUI 3 Port) 🧮

![WinUI 3](https://img.shields.io/badge/WinUI_3-0078D7?style=for-the-badge&logo=windows&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Windows 11](https://img.shields.io/badge/Windows_11_Native-0078D4?style=for-the-badge&logo=windows-11&logoColor=white)

This project focuses on modernizing an already **fully completed WPF calculator app** (located in the `main` branch). The goal of this branch is to port the entire application natively to **WinUI 3** and the Windows 11 Fluent Design.

## 📖 Project Background & Vision: WPF to WinUI 3

### The Foundation (WPF - Completed)
The `main` branch holds the original version of the application. It serves as our **stable reference point**. 
* **Status:** 100% Finished.
* **Scope:** A fully working calculator with two main modes: a Standard Arithmetic mode and a Currency Converter with real-time logic.
* **Technology:** Built with Windows Presentation Foundation (WPF). It uses a custom-made navigation system and traditional XAML styling.

### The Goal (WinUI 3 - In Progress)
The current branch (`feature/winui-port`) is where the transformation happens. The goal is not just to copy the app, but to **re-imagine it for Windows 11**.
**What I am focusing on:**
* **Modern Aesthetics:** Replace the old UI with **Fluent Design**. This includes using **Mica Alt** (the beautiful translucent glass effect), rounded corners, and modern typography.
* **Official Controls:** Moving away from custom WPF workarounds to use native WinUI 3 controls like the **NavigationView**.

## 📸 Screenshots

| Standard Mode | Currency Converter | Menu Navigation |
| :---: | :---: | :---: |
| <img width="506" height="849" alt="Screenshot 2026-04-23 203123" src="https://github.com/user-attachments/assets/0459b259-1b03-4b51-acfb-62579f9d0bb6" /> | <img width="511" height="850" alt="Screenshot 2026-04-23 203143" src="https://github.com/user-attachments/assets/90c5f175-f320-4562-bf62-1d8b239384c7" /> | <img width="509" height="850" alt="Screenshot 2026-04-23 203134" src="https://github.com/user-attachments/assets/ad0945de-731f-402d-8e4a-a41de50facae" /> |

## 🛠️ How to Run

To build and run this project, you will need Visual Studio and the Windows App SDK.

### Prerequisites
* **Visual Studio 2022** (Version 17.0 or later)
* Workload: **.NET Desktop Development**
* Workload: **Windows application development** (Ensure "Windows App SDK C++ Templates" and "Windows App SDK C# Templates" are checked)

### Installation
```bash
# Clone the repository
git clone [https://github.com/YOUR_USERNAME/YOUR_REPOSITORY.git](https://github.com/YOUR_USERNAME/YOUR_REPOSITORY.git)

# Navigate into the project folder

cd YOUR_REPOSITORY

# Open the .sln file in Visual Studio 2022
# Set the "Calculator.WinUI" project as the Startup Project.
# Press F5 or Ctrl+F5 to build and run.
```
