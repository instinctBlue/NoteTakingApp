# NoteTakingApp

A simple WPF note-taking application written in C# that allows you to create, edit, and delete notes. Notes are saved automatically to a JSON file for persistence between sessions.

## Features

- Add, edit, and delete notes with a user-friendly interface
- Notes saved in JSON format locally for persistence
- Real-time UI updates using `ObservableCollection` and `INotifyPropertyChanged`
- Simple and clean UI built with WPF

  ## 📸 Screenshot

Here is the main window of the Note Taking App:

![Main Window](/NoteTakingApp.png)


## Getting Started

### Prerequisites

- [.NET 6 SDK or newer](https://dotnet.microsoft.com/download) (or .NET Framework if using that version)
- Visual Studio 2022 or newer recommended

### Running the App

1. Clone the repository:
   ```bash
   git clone https://github.com/instinctBlue/NoteTakingApp.git

2. Open the solution in Visual Studio.

3. Build and run the project.

How to Use
Add: press Add button to create new note, then click Save to save it.

Edit: Select a note from the list, edit the title or content, then click Save.

Delete: Select a note and click Delete to remove it.

Notes are saved automatically to a JSON file (notes.json) in your app folder.

Project Structure
Note.cs — The Note model implementing INotifyPropertyChanged.

MainWindow.xaml — The main UI layout.

MainWindow.xaml.cs — Code behind with logic for managing notes and JSON persistence.

License
This project is licensed under the MIT License.

Contributing
Feel free to submit issues or pull requests!

Author
Created by Linas
