namespace Castle
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StartNewButton_Click(object sender, EventArgs e)
        {
            Form setupForm = new SetupWindow();
            this.Hide();
            setupForm.Show();
        }
    }
}
