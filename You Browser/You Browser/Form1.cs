using System.Configuration;
using System.Xml;

namespace You_Browser
{
    public partial class Form1 : Form
    {
        string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        private string _passwordFile = "encrypted password file.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void searchBarButton_Click(object sender, EventArgs e)
        {

            var searchUrl = "https://you.com/search?q=" + searchBar.Text;
            webView21.CoreWebView2.Navigate(searchUrl);

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            searchBar.Text = "";
            webView21.CoreWebView2.Navigate("https://you.com");
        }

        private void youBrowserReturnButton_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.Navigate("https://you.com");
        }

        private void chatGPTButton_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.Navigate("https://chat.openai.com");
        }

        private void bardAIButton_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.Navigate("https://bard.google.com");
        }

        private void youtubeMusicButton_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.Navigate("https://music.youtube.com");
        }

        private void spotifyButton_Click(object sender, EventArgs e)
        {
            webView21.CoreWebView2.Navigate("https://spotify.com");

        }

        private void lockButton_Click(object sender, EventArgs e)
        {
            lockPanel.Show();
            changePasswordButton.Show();
        }

        private void unlockButton_Click(object sender, EventArgs e)
        {

            string[] lines = System.IO.File.ReadAllLines(appPath + @"\encrypted password file.txt");
            foreach (string line in lines)
            {
                if (line == passwordTextbox.Text)
                {
                    lockPanel.Hide();
                    passwordTextbox.Text = "";
                }
                else
                {
                    passwordLabel.Show();
                    passwordLabel.Text = "Incorrect Password!";
                    passwordTimer.Enabled = true;
                }
            }

        }


        private void Form1_MinimumSizeChanged(object sender, EventArgs e)
        {

        }

        private void lockPanel_Resize(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void unlockButton_MouseEnter(object sender, EventArgs e)
        {

        }

        private void unlockButton_MouseLeave(object sender, EventArgs e)
        {

        }

        private void unlockButton_MouseHover(object sender, EventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            searchPanel.Show();
        }

        private void maximizeButton_Click(object sender, EventArgs e)
        {
            webView21.Dock = DockStyle.Fill;
            searchPanel.Hide();

        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            currentPasswordTextbox.Show();
            newPasswordTextbox.Show();
            confirmPasswordTextbox.Show();
            changeButton.Show();
            hideButton.Show();
            passwordTimer.Enabled = true;
        }

        private void hideButton_Click(object sender, EventArgs e)
        {
            currentPasswordTextbox.Hide();
            newPasswordTextbox.Hide();
            confirmPasswordTextbox.Hide();
            changeButton.Hide();
            hideButton.Hide();
            currentPasswordTextbox.Text = "";
            newPasswordTextbox.Text = "";
            confirmPasswordTextbox.Text = "";
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }

        private void searchPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
        }

        private void lockPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
        }

        private void confirmPasswordTextbox_TextChanged(object sender, EventArgs e)
        {
        }

        private void newPasswordTextbox_TextChanged(object sender, EventArgs e)
        {
        }

        private void currentPasswordTextbox_TextChanged(object sender, EventArgs e)
        {
        }

        private void passwordLabel_Click(object sender, EventArgs e)
        {
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void passwordTimer_Tick(object sender, EventArgs e)
        {
            passwordTimer.Enabled = false;
            passwordLabel.Visible = false;
        }

        private void setPasswordButton_Click(object sender, EventArgs e)
        {
            lockPanel.Show();
            createPasswordButton.Show();
            createPasswordTextbox.Show();
            changePasswordButton.Hide();
            returnButton.Show();
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            returnButton.Hide();
            lockPanel.Hide();
            createPasswordButton.Hide();
            createPasswordTextbox.Hide();
            changePasswordButton.Hide();
        }

        private void createPasswordButton_Click(object sender, EventArgs e)
        {
            // Get the password from the textbox.
            string password = createPasswordTextbox.Text;

            // Save the password to the file.
            using (StreamWriter writer = File.AppendText(_passwordFile))
            {
                writer.WriteLine(password);

            }
        }

        private void changeButton_Click_1(object sender, EventArgs e)
        {
            // Get the current password from the textbox.
            string currentPassword = currentPasswordTextbox.Text;

            // Get the new password from the textbox.
            string newPassword = newPasswordTextbox.Text;

            // Get the confirmation password from the textbox.
            string confirmationPassword = confirmPasswordTextbox.Text;

            // Check if the new password and confirmation password match.
            if (newPassword == confirmationPassword)
            {
                passwordLabel.Show();
                passwordLabel.Text = "Successfully Changed!";
                passwordTimer.Enabled = true;
                // Delete the existing password from the file.
                File.Delete(_passwordFile);

                // Save the new password to the file.
                using (StreamWriter writer = File.AppendText(_passwordFile))
                {
                    writer.WriteLine(newPassword);
                }
            }
            else
            {
                passwordLabel.Text = "Passwords Dont Match!";
                passwordTimer.Enabled = true;
            }
        }

        private void passwordCheckingTimer_Tick(object sender, EventArgs e)
        {
            string path = @"encrypted password file.txt";
            if (File.Exists(path))
            {
                fileAddingButton.Enabled = false;
                string text = File.ReadAllText(path);
                if (!string.IsNullOrEmpty(text))
                {
                    setPasswordButton.Enabled = false;

                }
                else
                {
                    setPasswordButton.Enabled = true;
                }
            }
            else
            {
                fileAddingButton.Enabled = true;
            }
        }

        private void fileAddingButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(_passwordFile))
            {
                File.Create(_passwordFile);
                passwordCheckingTimer.Enabled = false;
                searchBar.PlaceholderText = "File Created! Please Close Browser Before Use And Creating A Password!";
            }

            fileAddingButton.Enabled = false;
        }
    }
}