using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6_HT2024_DA204E_AQ7150.Classes
{
    public class TaskManager
    {
        private List<Task> _tasks;


        public TaskManager() { _tasks = new List<Task>(); }

        public void AddTask(Task task)
        {

            if (task == null)
            {
                throw new ArgumentNullException(nameof(task), "Task Cannot be null");
            }

            _tasks.Add(task);
        }

        public void RemoveTask(int index)
        {
            if (index < 0 || index >= _tasks.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of Range");
            }

            _tasks.RemoveAt(index);
        }

        public void UpdateTask(int index, Task updatedTask)
        {
            if (index < 0 || index >= _tasks.Count)
            {
                throw new ArgumentException(nameof(index), "Index is out of range");
            }
            if (updatedTask == null)
            {
                throw new ArgumentException(nameof(updatedTask), "UpdatedTask cannot be Null");
            }
            _tasks[index] = updatedTask;
        }

        public List<Task> GetAllTasks() { return new List<Task>(_tasks); }


        public string[] GetInfoStringList()
        {
            string[] infoStrings = new string[_tasks.Count];

            for (int i = 0; i < infoStrings.Length; i++)
            {
                infoStrings[i] = _tasks[i].ToString();
            }

            return infoStrings;
        }

    }
}
