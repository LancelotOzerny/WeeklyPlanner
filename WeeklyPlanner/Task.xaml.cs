using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WeeklyPlanner
{
    /// <summary>
    /// Логика взаимодействия для Task.xaml
    /// </summary>
    public partial class Task : UserControl
    {
        /// <summary>
        /// Текущий статус задачи - "готова" или "в ожидании"
        /// </summary>
        public enum TaskStatus { Wait = 0, Ok = 1 }

        private TaskStatus _taskStatus = TaskStatus.Wait;
        private string _value = string.Empty;

        /// <summary>
        /// Свойство, которое позволяет установить или получить день недели на который выпадает задача
        /// </summary>
        public DayOfWeek DayOfWeek { get; set; }

        /// <summary>
        /// Свойство, которое позволяет установить или получить текущее значение задачи
        /// </summary>
        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                TextBlock_Value.Text = value;
            }
        }
        
        /// <summary>
        /// Свойство, которое позволяет установить или получить текущий статус задачи
        /// </summary>
        public TaskStatus Status 
        {
            get => _taskStatus;
            set
            {
                if (value == TaskStatus.Ok)
                {
                    this.Background = (Brush)System.ComponentModel.TypeDescriptor.GetConverter(typeof(Brush)).ConvertFromInvariantString("Green");
                    /*TextBlock_Value.TextDecorations = TextDecorations.Strikethrough;*/
                    _taskStatus = TaskStatus.Ok;
                }

                if (value == TaskStatus.Wait)
                {
                    this.Background = (Brush)System.ComponentModel.TypeDescriptor.GetConverter(typeof(Brush)).ConvertFromInvariantString("Yellow");
                    /*if (TextBlock_Value.TextDecorations.Count > 0)
                    {
                        TextBlock_Value.TextDecorations.Clear();
                    }*/
                    _taskStatus = TaskStatus.Wait;
                }
            }
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Task()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор который принимает значение задачи и зануляет все остальные значения
        /// </summary>
        /// <param name="value">Значение задачи</param>
        public Task(string value)
        {
            InitializeComponent();
            Set(value, TaskStatus.Wait, 0);
        }

        /// <summary>
        /// Конструктор с параметрами, который принимает значение и статус задачи и зануляет день недели
        /// </summary>
        /// <param name="value">Значение задачи</param>
        /// <param name="tStatus">Статус задачи</param>
        public Task(string value, TaskStatus tStatus)
        {
            InitializeComponent();
            Set(value, tStatus, 0);
        }

        /// <summary>
        /// Конструктор с параметрами, который принимает значение, статус задачи и день недели
        /// </summary>
        /// <param name="value">Значение задачи</param>
        /// <param name="tStatus">Статус задачи</param>
        /// <param name="day"></param>
        public Task(string value, TaskStatus tStatus, DayOfWeek day)
        {
            InitializeComponent();
            Set(value, tStatus, day);
        }

        /// <summary>
        /// Метод, который позволяет установить параметры текущей задачи
        /// </summary>
        /// <param name="value">Значение задачи</param>
        /// <param name="tStatus">Статус задачи</param>
        /// <param name="day"></param>
        public void Set(string value, TaskStatus tStatus, DayOfWeek day)
        {
            Value = value;
            Status = tStatus;
            DayOfWeek = day;
        }
    }
}
