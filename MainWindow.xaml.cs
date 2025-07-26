using Microsoft.Win32;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FileLoaderApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                PathTextBox.Text = openFileDialog.FileName;

                try
                {
                    string content = File.ReadAllText(openFileDialog.FileName);
                    DataTextBox.Text = content;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file: " + ex.Message);
                }
            }
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string data = DataTextBox.Text;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var json = $"{{\"message\":\"{EscapeJson(data)}\"}}";
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("https://localhost:7179/api/servicestatus/data", content);

                    string result = await response.Content.ReadAsStringAsync();

                    MessageBox.Show("Response from API:\n" + result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending data: " + ex.Message);
                }
            }
        }

        private string EscapeJson(string input)
        {
            return input
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\n", "\\n")
                .Replace("\r", "");
        }
    }
}


