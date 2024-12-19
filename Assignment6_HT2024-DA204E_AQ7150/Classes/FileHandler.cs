// Written by: Henrik Henriksson(AQ7150)

using static Assignment6_HT2024_DA204E_AQ7150.Enums.Enums;

namespace Assignment6_HT2024_DA204E_AQ7150.Classes
{
    public static class FileHandler
    {
        // This helps keep track of valid files to ensure the user doesnt load anything mismatching
        private const string FileVersionToken = "TASK_FILE_V1";

        public static void SaveTasks(string filePath, TaskManager taskManager)
        {

            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
            }

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

        public static void LoadTasks(string filePath, TaskManager taskManager)
        {
            try
            {

                using StreamReader reader = new StreamReader(filePath);

                var fileToken = reader.ReadLine(); // see filetoken description, we want to avoid users loading any mismatching file.
                if (fileToken != FileVersionToken)
                {
                    throw new InvalidDataException("Error: File format is incorrect or wrong version");
                }

                if (int.TryParse(reader.ReadLine(), out var taskCount))
                {
                    // this might be removed if addition to already created list is preffered.
                    taskManager.ClearTasks();

                    for (int i = 0; i < taskCount; i++)
                    {
                        var description = reader.ReadLine();
                        DateTime dueDate = DateTime.Parse(reader.ReadLine());
                        PriorityLevel priority = (PriorityLevel)Enum.Parse(typeof(PriorityLevel), reader.ReadLine());

                        Task task = new(description, dueDate, priority);
                        taskManager.AddTask(task);
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
