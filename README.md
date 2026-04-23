# Modern Windows Calculator (WinUI 3 Port) 🧮

![WinUI 3](https://img.shields.io/badge/WinUI_3-0078D7?style=for-the-badge&logo=windows&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Windows 11](https://img.shields.io/badge/Windows_11_Native-0078D4?style=for-the-badge&logo=windows-11&logoColor=white)

A sleek, feature-rich calculator built from the ground up for Windows 11. Originally a legacy WPF application, this project has been fully ported to **WinUI 3** to leverage modern Fluent Design, Mica backdrops, and hardware-accelerated UI.

## ✨ Key Features

* **Standard Calculator:** Fully functional arithmetic calculator with a running calculation history.
* **Live Currency Converter:** Built-in conversion tool supporting major global currencies (EUR, USD, GBP, CZK, JPY, CNY).
* **Native Windows 11 Look & Feel:** * Implements the **Mica Backdrop** for that beautiful, translucent glass effect.
  * Follows Microsoft's **Fluent Design System** with smooth animations and rounded corners.
  * Automatically adapts to the user's **System Accent Color**.
* **Optimized Architecture:** Uses **Lightweight Styling** and Resource Zones (DRY Principle) to maintain native hover/click animations without bloated ControlTemplates.

## 📸 Screenshots

*(Insert screenshots of your app here. Show off the Mica effect and the Currency menu!)*

| Standard Mode | Currency Converter | Menu Navigation |
| :---: | :---: | :---: |
| <img width="506" height="849" alt="Screenshot 2026-04-23 203123" src="https://github.com/user-attachments/assets/0459b259-1b03-4b51-acfb-62579f9d0bb6" /> | <img width="511" height="850" alt="Screenshot 2026-04-23 203143" src="https://github.com/user-attachments/assets/90c5f175-f320-4562-bf62-1d8b239384c7" /> | <img width="509" height="850" alt="Screenshot 2026-04-23 203134" src="https://github.com/user-attachments/assets/ad0945de-731f-402d-8e4a-a41de50facae" /> |

## 🏗️ Technical Highlights (Why WinUI 3?)

During the migration from WPF to WinUI 3, several architectural improvements were made:
1. **Lightweight Styling:** Replaced massive WPF `<ControlTemplate>` overrides with localized `<Button.Resources>`. This allows custom theming while preserving native WinUI pointer animations.
2. **Container Scoping:** Used Grid-level Resource Dictionaries to cascade UI states (Hover, Pressed) to multiple buttons simultaneously, massively reducing XAML code duplication.
3. **Modern Navigation:** Switched from URI-based navigation to WinUI's robust `Frame.Navigate(typeof(Page))` type-safe approach.

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

## 🗺️ Roadmap (Next Steps)
[x] Port legacy WPF logic to WinUI 3.

[x] Implement Fluent Design and Lightweight Styling.

[x] Refactor navigation and UI architecture.

[ ] Responsive Design: Replace hardcoded Width/Height values with dynamic Grid star-sizing (*) to ensure the calculator scales beautifully across all window sizes.

[ ] Add dark mode / light mode toggle switch.
