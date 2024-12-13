

namespace Assignment6_HT2024_DA204E_AQ7150
{
    public partial class MainForm : Form
    {


        private MenuStrip menuStrip;
        private Panel mainPanel;

        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {

            mainPanel = new Panel { Dock = DockStyle.Fill };

            menuStrip = new MenuStrip();

            // File Menu section:

            ToolStripMenuItem fileMenu = new ToolStripMenuItem("file");
            ToolStripMenuItem newMenuItem = new ToolStripMenuItem("new", null, NewMenuItem_Click);
            ToolStripMenuItem openMenuItem = new ToolStripMenuItem("open", null, OpenMenuItem_Click);
            ToolStripMenuItem saveMenuItem = new ToolStripMenuItem("new", null, SaveMenuItem_Click);
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("file", null, ExitMenuItem_Click);

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

            Text = "Task Manager";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(800, 600);

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
            MessageBox.Show("Save menu clicked.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
