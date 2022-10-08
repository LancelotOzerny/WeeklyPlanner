using System;
using System.Collections.Generic;
using System.Windows;
using System.Xml.Linq;
using System.Linq;

namespace WeeklyPlanner
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Task> _tasks = new List<Task>();
        public string DataFilePath { get; set; }

        public MainWindow()
        {
            DataFilePath = "Data.xml";

            InitializeComponent();
            Task_Value.Text = "0";

            try
            {
                XElement data = XElement.Load(DataFilePath);
                LoadData(data);
                ShowTasks();
            }
            catch (Exception) {}
        }

        public void AddTask(Task item)
        {
            item.Margin = new Thickness(0, 10, 0, 0);
            _tasks.Add(item);
        }

        public void ShowTasks()
        {
            TasksContainer.Items.Clear();
            DateTime dt = DateTime.Now;

            var select = from task in _tasks where task.DayOfWeek == dt.DayOfWeek select task;

            foreach (Task item in select)
            {
                item.Margin = new Thickness(0, 10, 0, 0);
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

            SaveData();
        }

        private void LoadData(XElement data)
        {
            IEnumerable<XElement> xElements = data.Elements();

            if (xElements != null)
            {
                foreach (XElement xElement in xElements)
                {
                    LoadData(xElement);

                    if (xElement.Name == "TaskElement")
                    {
                        Task LoadedTask = new Task();

                        foreach (XElement attr in xElement.Elements())
                        {
                            if (attr.Name == "Value")
                            {
                                LoadedTask.Value = Convert.ToString(attr.Value);
                            }

                            if (attr.Name == "Status")
                            {
                                LoadedTask.Status = (Task.TaskStatus)Convert.ToInt32(attr.Value);
                            }

                            if (attr.Name == "DayOfWeek")
                            {
                                LoadedTask.DayOfWeek = (DayOfWeek)Convert.ToInt32(attr.Value);
                            }
                        }
                        _tasks.Add(LoadedTask);
                    }
                }
            }
        }

        private void SaveData()
        {
            XElement data = new XElement("TasksData");
            foreach (Task task in _tasks)
            {
                task.Status = Task.TaskStatus.Wait;
                XElement item = new XElement("TaskElement");

                XElement value = new XElement("Value");
                value.Value = task.Value;
                item.Add(value);

                XElement status = new XElement("Status");
                status.Value = ((int)task.Status).ToString();
                item.Add(status);

                XElement dayOfWeek = new XElement("DayOfWeek");
                dayOfWeek.Value = (((int)task.DayOfWeek).ToString()).ToString();
                item.Add(dayOfWeek);

                data.Add(item);
            }

            data.Save(DataFilePath);
        }
    }
}
