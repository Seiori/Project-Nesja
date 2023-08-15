using Project_Nesja.Data;

namespace Project_Nesja.Forms
{
    public partial class Client : Form
    {
        private ClientData clientData;

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
