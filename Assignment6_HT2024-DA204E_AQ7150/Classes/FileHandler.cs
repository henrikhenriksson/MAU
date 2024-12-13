using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assignment6_HT2024_DA204E_AQ7150.Enums.Enums;

namespace Assignment6_HT2024_DA204E_AQ7150.Classes
{
    public static class FileHandler
    {
        private const string FileVersionToken = "TASK_FILE_V1";

        private static void SaveTasks(string filePath, TaskManager taskManager)
        {
            try
            {


                using StreamWriter writer = new StreamWriter(filePath);

                writer.WriteLine(FileVersionToken);

                writer.WriteLine(taskManager.GetAllTasks().Count);

                foreach (var task in taskManager.GetAllTasks())
                {
                    writer.WriteLine(task.Description);
                    writer.WriteLine(task.DueDate.ToString("o"));
                    writer.WriteLine(task.Priority);


                }


            }
            catch (Exception ex)
            {

                throw new IOException($"Error Saving Tasks: {ex.Message}", ex);
            }


        }

        public static void LoadTasks(string filePath, TaskManager manager)
        {
            try
            {

                using StreamReader reader = new StreamReader(filePath);

                string fileToken = reader.ReadLine();
                if (fileToken != FileVersionToken)
                {
                    throw new InvalidDataException("Error: File format is incorrect or wrong version");
                }

                if (int.TryParse(reader.ReadLine(), out var taskCount))
                {
                    manager = new();

                    for (int i = 0; i < taskCount; i++)
                    {
                        string description = reader.ReadLine();
                        DateTime dueDate = DateTime.Parse(reader.ReadLine());
                        PriorityLevel priority = (PriorityLevel)Enum.Parse(typeof(PriorityLevel), reader.ReadLine());

                        Task task = new(description, dueDate, priority);
                        manager.AddTask(task);
                    }

                }
            }
            catch (Exception ex)
            {
                throw new IOException($"Error Loading Tasks: {ex.Message}", ex);
            }

        }
    }
}
