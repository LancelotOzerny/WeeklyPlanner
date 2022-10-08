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
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 420; ++i)
            {
                Task item = new Task($"Задача {i + 1}");
                AddTask(item);
            }
        }

        public void AddTask(Task item)
        {
            item.Margin = new Thickness(0, 10, 0, 0);
            TasksContainer.Items.Add(item);
        }
    }
}
