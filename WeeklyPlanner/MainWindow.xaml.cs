using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace WeeklyPlanner
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Task> tasks = new List<Task>();

        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 3; ++i)
            {
                Task item = new Task($"Задача {i + 1}");
                AddTask(item);
                ShowTasks();
            }
        }

        public void AddTask(Task item)
        {
            item.Margin = new Thickness(0, 10, 0, 0);
            tasks.Add(item);
        }

        public void ShowTasks()
        {
            TasksContainer.Items.Clear();

            foreach (Task item in tasks)
            {
                TasksContainer.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task task = new Task(Task_Value.Text, Task.TaskStatus.Wait, (DayOfWeek)Convert.ToInt32(Task_DayWeek.SelectedIndex));
            AddTask(task);
            ShowTasks();

            Task_DayWeek.SelectedIndex = 0;
            Task_Value.Text = String.Empty;
        }
    }
}
