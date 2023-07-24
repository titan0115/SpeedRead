using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SpeedRead
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
        private static bool isPaused = false;


        public async void Button_Click(object sender, RoutedEventArgs e) //кнопка "начать" обработчик её действия
        {
            Text = Clipboard.GetText(); // пробуем вытащить текст напрямую из буфера обмена, пока что как-то так
            

            await OutBegin();
        }

        public async Task OutBegin() //метод вывода текста в окошечко
        {
            string[] words = Text.Split(' '); // без ножа режем текстовую пееменную на массив от куда удаляем все пробелы

            if (string.IsNullOrEmpty(Text)) // условие при котром будет выполнение программы
            {
                textRun.Text = "ERROR: скопируйте текст в буфер обмена, чтобы начать";
            }
            else // вывод ошибки если текста в буфере обмена нету
            {
                foreach (string word in words) // цикл для вывода всего этого говна 
                {

                    if (isPaused) // глупая реализация паузы
                    {
                        await Task.Delay(1000);

                    }
                    else
                    {
                        Delay = 60000/(int)ValeuDelay.Value; //математический расчёт слов в минуту
                        textRun.Text = word;  //поочерёдно закидываем весь текс в окошечко 
                        await Task.Delay(Delay); // просто задержка
                    }

                }
            }
        }


        private void Button_Click_Paus(object sender, RoutedEventArgs e) //пауза реализация))
        {

            if (isPaused)
            {
                ResumeExecution();
            }
            else
            {
                PauseExecution();
            }

        }

        public static void PauseExecution()
        {
            isPaused = true; // Устанавливаем флаг паузы

        }

        public static void ResumeExecution()
        {
            isPaused = false; // Сбрасываем флаг паузы
        }
    }
}

