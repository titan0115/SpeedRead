using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string Text; // глобальная переменная текста который пользователь ввёл
        public int Delay; //глобальная переменная задержки

        public async void Button_Click(object sender, RoutedEventArgs e) //кнопка "начать" обработчик её действия
        {
            Text = Clipboard.GetText(); // пробуем вытащить текст напрямую из буфера обмена
            await OutBegin();
        }

        public async Task OutBegin() //метод вывода текста в окошечко
        {
            string[] words = Text.Split(' '); // без ножа режем текстовую пееменную на массив от куда удаляем все пробелы

            foreach (string word in words) // цикл для вывода всего этого говна
            {
                textRun.Text = word;
                await Task.Delay(100);
            }
        }

        
    }
}

