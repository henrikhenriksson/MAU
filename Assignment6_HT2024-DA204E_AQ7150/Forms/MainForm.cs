// Written by: Henrik Henriksson(AQ7150)




using Assignment6_HT2024_DA204E_AQ7150.Classes;
using static Assignment6_HT2024_DA204E_AQ7150.Enums.Enums;
using Task = Assignment6_HT2024_DA204E_AQ7150.Classes.Task;

namespace Assignment6_HT2024_DA204E_AQ7150
{
    public partial class MainForm : Form
    {


        private MenuStrip menuStrip;
        private Panel mainPanel;
        private TextBox taskDescriptionTextBox;
        private DateTimePicker dueDatePicker;
        private ComboBox priorityComboBox;
        private Button addTaskButton;
        private ListBox taskListBox;

        private TaskManager taskManager;

        Color commonBackColor;
        Color commonForeColor;
        Font commonFont;
        public MainForm()
        {
            taskManager = new TaskManager();
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            Text = "Task Manager";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(900, 700);
            BackColor = Color.DarkGray;

            commonFont = new Font("Arial", 10, FontStyle.Regular);
            commonBackColor = Color.LightGray;
            commonForeColor = Color.Black;

            InitializeMainPanel();
            initilizeMenuStrip();
            InitializeInputControls();

            MainMenuStrip = menuStrip;
            Controls.Add(menuStrip);
            Controls.Add(mainPanel);
        }


        private void InitializeMainPanel()
        {
            mainPanel = new Panel
            {
                Size = new Size(850, 600),
                Location = new Point((this.ClientSize.Width - 850) / 2, (this.ClientSize.Height - 650) / 2 + 40),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.SlateGray
            };
        }
        private void InitializeInputControls()
        {
            Label descriptionLabel = new Label
            {
                Text = "Description",
                Font = commonFont,
                Location = new Point(20, 20),
                AutoSize = true,
            };
            mainPanel.Controls.Add(descriptionLabel);

            taskDescriptionTextBox = new TextBox
            {
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Location = new Point(180, 20),
                Size = new Size(200, 25)
            };
            mainPanel.Controls.Add(taskDescriptionTextBox);

            Label dueDateLabel = new Label
            {
                Text = "Due Date: ",
                Font = commonFont,
                ForeColor = commonForeColor,
                Location = new Point(20, 60),
                AutoSize = true
            };
            mainPanel.Controls.Add(dueDateLabel);

            dueDatePicker = new DateTimePicker
            {
                Value = DateTime.Now.AddHours(24),
                Font = commonFont,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy hh:mm tt",
                CalendarMonthBackground = commonBackColor,
                CalendarForeColor = commonForeColor,
                CalendarFont = commonFont,
                Location = new Point(180, 60),
                Size = new Size(200, 25)
            };
            mainPanel.Controls.Add(dueDatePicker);
            Label priorityLabel = new Label
            {
                Text = "Priority",
                Font = commonFont,
                ForeColor = commonForeColor,
                Location = new Point(20, 100),
                AutoSize = true

            };
            mainPanel.Controls.Add(priorityLabel);
            priorityComboBox = new ComboBox
            {
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Location = new Point(180, 100),
                Size = new Size(200, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            priorityComboBox.Items.AddRange(Enum.GetNames(typeof(PriorityLevel)));
            priorityComboBox.SelectedIndex = 2;
            mainPanel.Controls.Add(priorityComboBox);

            addTaskButton = new Button
            {
                Text = "Add Task:",
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Location = new Point(20, 160),
                Size = new Size(360, 30)
            };
            addTaskButton.Click += AddTaskButton_Click;
            mainPanel.Controls.Add(addTaskButton);

            Label taskListLabel = new Label
            {
                Text = "Tasks",
                Font = commonFont,
                ForeColor = commonForeColor,
                Location = new Point(20, 230),
                AutoSize = true
            };
            mainPanel.Controls[0].Controls.Add(taskListLabel);
            taskListBox = new ListBox
            {
                Font = commonFont,
                BackColor = commonBackColor,
                ForeColor = commonForeColor,
                Location = new Point(20, 270),
                Size = new Size(780, 300)
            };
            mainPanel.Controls.Add(taskListBox);

        }

        private void initilizeMenuStrip()
        {
            menuStrip = new MenuStrip();
            // File Menu section:

            ToolStripMenuItem fileMenu = new ToolStripMenuItem("File");
            ToolStripMenuItem newMenuItem = new ToolStripMenuItem("New", null, NewMenuItem_Click);
            ToolStripMenuItem openMenuItem = new ToolStripMenuItem("Open", null, OpenMenuItem_Click);
            ToolStripMenuItem saveMenuItem = new ToolStripMenuItem("Save", null, SaveMenuItem_Click);
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("Exit", null, ExitMenuItem_Click);

            fileMenu.DropDownItems.Add(newMenuItem);
            fileMenu.DropDownItems.Add(openMenuItem);
            fileMenu.DropDownItems.Add(saveMenuItem);
            fileMenu.DropDownItems.Add(new ToolStripSeparator());
            fileMenu.DropDownItems.Add(exitMenuItem);

            // Help Menu

            ToolStripMenuItem helpMenu = new ToolStripMenuItem("Help");
            ToolStripMenuItem aboutMenuItem = new ToolStripMenuItem("About", null, AboutMenuItem_Click);
            helpMenu.DropDownItems.Add(aboutMenuItem);

            menuStrip.Items.Add(fileMenu);
            menuStrip.Items.Add(helpMenu);
        }


        private void UpdateTaskListDisplay()
        {
            taskListBox.Items.Clear();
            foreach (var task in taskManager.GetAllTasks().OrderBy(t => t.DueDate))
            {
                taskListBox.Items.Add(task.ToString());
            }
        }

        private void AddTaskButton_Click(object? sender, EventArgs e)
        {

            try
            {
                string description = taskDescriptionTextBox.Text.Trim();
                if (string.IsNullOrEmpty(description))
                {
                    MessageBox.Show("Description cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime dueDate = dueDatePicker.Value;
                if (dueDate < DateTime.Now)
                {
                    MessageBox.Show("Due Date cannot be in the past.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!Enum.TryParse(priorityComboBox.SelectedItem.ToString(), out PriorityLevel priority))
                {
                    MessageBox.Show("Invalid priority selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                Task newTask = new Task(description, dueDate, priority);
                taskManager.AddTask(newTask);

                UpdateTaskListDisplay();

                MessageBox.Show("Task added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // reset values for new entry.
                taskDescriptionTextBox.Clear();
                dueDatePicker.Value = DateTime.Now.AddHours(24);
                priorityComboBox.SelectedIndex = 2;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void NewMenuItem_Click(object? sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to clear the current list and start a new one?",
                                         "Confirm New Task List",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                taskManager = new TaskManager();
                UpdateTaskListDisplay();
            }
        }

        private void OpenMenuItem_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog(); ;

            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.Title = "Open Task File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileHandler.LoadTasks(openFileDialog.FileName, taskManager);
                    UpdateTaskListDisplay();
                    MessageBox.Show("Tasks Loaded Succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An Error occured while loading the file: {ex.Message}", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


        private void SaveMenuItem_Click(object? sender, EventArgs e)
        {

            if (!taskManager.GetAllTasks().Any())
            {
                MessageBox.Show("There are no tasks to save. Please add tasks before saving.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.Title = "Save Tasks to File";
            saveFileDialog.FileName = $"Reminders_{DateTime.Now:yyyyMMdd_HHmm}";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileHandler.SaveTasks(saveFileDialog.FileName, taskManager);
                    MessageBox.Show("Tasks saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while saving the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void ExitMenuItem_Click(object? sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?.", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) { Close(); }

        }

        private void AboutMenuItem_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Task Manager Application\nVersion 1.0\nWritten By: Henrik Henriksson.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }




    }
}
