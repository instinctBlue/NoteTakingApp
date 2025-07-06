using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace NoteTakingApp
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Note> notes = new ObservableCollection<Note>();
        private readonly string notesFilePath = "notes.json";
        public MainWindow()
        {
            InitializeComponent();
            LoadNotesFromFile();

            // Bind the notes collection once to the ListBox
            NotesListBox.ItemsSource = notes;
        }

        private void NotesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NotesListBox.SelectedItem is Note selectedNote)
            {
                TitleTextBox.Text = selectedNote.Title;
                ContentTextBox.Text = selectedNote.Content;
            }
            else
            {
                TitleTextBox.Clear();
                ContentTextBox.Clear();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var newNote = new Note { Title = "New Note", Content = "" };
            notes.Add(newNote);
            NotesListBox.SelectedItem = newNote; // Select the new note
            SaveNotesToFile();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (NotesListBox.SelectedItem is Note selectedNote)
            {
                selectedNote.Title = TitleTextBox.Text;
                selectedNote.Content = ContentTextBox.Text;
                // No need to refresh ListBox.ItemsSource, UI updates automatically
            }
            SaveNotesToFile();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (NotesListBox.SelectedItem is Note selectedNote)
            {
                notes.Remove(selectedNote);
                TitleTextBox.Clear();
                ContentTextBox.Clear();
            }
            SaveNotesToFile();
        }
        private void SaveNotesToFile()
        {
            try
            {
                string json = JsonSerializer.Serialize(notes);
                File.WriteAllText(notesFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save notes: {ex.Message}");
            }
        }
        private void LoadNotesFromFile()
        {
            try
            {
                if (File.Exists(notesFilePath))
                {
                    string json = File.ReadAllText(notesFilePath);
                    var loadedNotes = JsonSerializer.Deserialize<ObservableCollection<Note>>(json);
                    if (loadedNotes != null)
                    {
                        notes = loadedNotes;
                        NotesListBox.ItemsSource = notes;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load notes: {ex.Message}");
            }
        }
    }
}
