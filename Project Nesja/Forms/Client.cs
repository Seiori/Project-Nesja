using Project_Nesja.Services;

namespace Project_Nesja.Forms
{
    public partial class Client : Form
    {
        private ClientAPI clientData;

        public Client()
        {
            InitializeComponent();
            clientData = new();
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }
    }
}
