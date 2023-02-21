using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImposibleBruhNoter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<NoteClass> allNoteList = new List<NoteClass>();
        public NoteClass noteClass = new NoteClass();
        public MainWindow()
        {
          
            InitializeComponent();//Код кринж как всегда. Выводятся вообще все заметки, но настройка даты заметки работает
            DateSelect.Text=DateTime.Now.ToString();
            allNoteList = CringeConverter.Deserialize<List<NoteClass>>();
            string[] items = new string[100];
            for (int i = 0; i < allNoteList.Count; i++)
            {
                
                items[i] = allNoteList[i].Name;
                
            }
            labelBox.ItemsSource = items;
        }
        
        private void ButtonDell_Click(object sender, RoutedEventArgs e)
        {
            //Удаление
            allNoteList = CringeConverter.Deserialize<List<NoteClass>>();
            for (int i = 0; i < allNoteList.Count; i++)
            {
                if (nameNote.Text == allNoteList[i].Name && descriptionNote.Text != allNoteList[i].Description)
                {
                    allNoteList[i].Name="";
                    allNoteList[i].Description="";
                    DateSelect.Text = Convert.ToString(allNoteList[i].date);
                }
                else if (nameNote.Text == allNoteList[i].Name)
                {
                    allNoteList[i].Name = "";
                    allNoteList[i].Description="";
                    DateSelect.Text = Convert.ToString(allNoteList[i].date);
                }
            }
            CringeConverter.Serialize(allNoteList);
        }
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            //Сохранение
            allNoteList = CringeConverter.Deserialize<List<NoteClass>>();
            noteClass.Name = nameNote.Text;
            noteClass.Description = descriptionNote.Text;
            noteClass.date = Convert.ToDateTime(DateSelect.Text);
            allNoteList.Add(noteClass);
           CringeConverter.Serialize(allNoteList);
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            //Создание
            nameNote.Text = "";
            descriptionNote.Text = "";

        }

        private void labelBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItem = labelBox.SelectedItem.ToString();
            for (int i = 0; i< allNoteList.Count; i++)
            {
                if (selectedItem== allNoteList[i].Name)
                {
                    nameNote.Text = allNoteList[i].Name;
                    descriptionNote.Text = allNoteList[i].Description;
                    DateSelect.Text = Convert.ToString(allNoteList[i].date);
                }
            }
        }
    }
}
