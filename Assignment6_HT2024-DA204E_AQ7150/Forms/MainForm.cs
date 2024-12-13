

using Assignment6_HT2024_DA204E_AQ7150.Classes;
using static Assignment6_HT2024_DA204E_AQ7150.Enums.Enums;
using Task = Assignment6_HT2024_DA204E_AQ7150.Classes.Task;

namespace Assignment6_HT2024_DA204E_AQ7150
{
    public partial class MainForm : Form
    {


        private MenuStrip menuStrip;
        private Panel mainPanel;
        private TableLayoutPanel inputTable;
        private TextBox taskDescriptionTextBox;
        private DateTimePicker dueDatePicker;
        private ComboBox priorityComboBox;
        private Button addTaskButton;
        private ListBox taskListBox;

        private TaskManager taskManager;

        public MainForm()
        {
            taskManager = new TaskManager();
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            InitializeMainPanel();
            initilizeMenuStrip();
            InitializeInputControls();
            InitializeTaskListBox();

            MainMenuStrip = menuStrip;
            Controls.Add(menuStrip);
            Controls.Add(mainPanel);

            Text = "Task Manager";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(800, 600);

        }

        private void InitializeTaskListBox()
        {

            taskListBox = new ListBox()
            {
                Dock = DockStyle.Fill
            };


            Label taskListLabel = new Label()
            {
                Text = "Tasks: ",
                AutoSize = true,
                Dock = DockStyle.Top,
                Padding = new Padding(10, 10, 0, 5)
            };

            mainPanel.Controls.Add(taskListLabel);

            mainPanel.Controls.Add(taskListBox);


        }

        private void UpdateTaskListDisplay()
        {
            taskListBox.Items.Clear();
            foreach (var task in taskManager.GetAllTasks())
            {
                taskListBox.Items.Add(task.ToString());
            }
        }

        private void InitializeInputControls()
        {
            inputTable = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 2,
                RowCount = 4,
                Padding = new Padding(10),
            };

            Label descriptionLabel = new Label
            {
                Text = "Description:",
                AutoSize = true,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };

            Label dueDateLabel = new Label
            {
                Text = "Due Date:",
                AutoSize = true,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };

            Label priorityLabel = new Label
            {
                Text = "Priority:",
                AutoSize = true,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            };

            taskDescriptionTextBox = new TextBox
            {
                PlaceholderText = "Enter Task Description",
                Width = 200
            };

            dueDatePicker = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy hh:mm tt",
                Width = 150
            };

            priorityComboBox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 120

            };
            priorityComboBox.Items.AddRange(Enum.GetNames(typeof(PriorityLevel)));
            priorityComboBox.SelectedIndex = 0;

            addTaskButton = new Button
            {
                Text = "Add Task",
                Width = 100
            };
            addTaskButton.Click += AddTaskButton_Click;

            inputTable.Controls.Add(descriptionLabel, 0, 0);
            inputTable.Controls.Add(taskDescriptionTextBox, 1, 0);
            inputTable.Controls.Add(dueDateLabel, 0, 1);
            inputTable.Controls.Add(dueDatePicker, 1, 1);
            inputTable.Controls.Add(priorityLabel, 0, 2);
            inputTable.Controls.Add(priorityComboBox, 1, 2);
            inputTable.Controls.Add(addTaskButton, 1, 3);

            mainPanel.Controls.Add(inputTable);
        }

        private void AddTaskButton_Click(object? sender, EventArgs e)
        {

            try
            {
                string description = taskDescriptionTextBox.Text.Trim();
                if (string.IsNullOrEmpty(description))
                {
                    MessageBox.Show("Description cannot be emtpy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dueDatePicker.Value = DateTime.Now;
                priorityComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void InitializeMainPanel()
        {
            mainPanel = new Panel { Dock = DockStyle.Fill };
        }

        private void initilizeMenuStrip()
        {
            menuStrip = new MenuStrip();
            // File Menu section:

            ToolStripMenuItem fileMenu = new ToolStripMenuItem("File");
            ToolStripMenuItem newMenuItem = new ToolStripMenuItem("New", null, NewMenuItem_Click);
            ToolStripMenuItem openMenuItem = new ToolStripMenuItem("Open", null, OpenMenuItem_Click);
            ToolStripMenuItem saveMenuItem = new ToolStripMenuItem("Save", null, SaveMenuItem_Click);
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("File", null, ExitMenuItem_Click);

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

        private void NewMenuItem_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("New menu clicked.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OpenMenuItem_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Open menu clicked.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        private void SaveMenuItem_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("New menu clicked.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
