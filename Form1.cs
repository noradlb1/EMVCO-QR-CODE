using QRCoder;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EMVCO_QR_CODE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbBankId.ValueMember = "Id";
            cmbBankId.DisplayMember = "Name";
            cmbBankId.DataSource = ListBankId.GetList();
            cmbBankId.SelectedValue = "970422";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var obj = new EMVCO(cmbBankId.SelectedValue.ToString(), txtSoTaiKhoan.Text, txtSoTien.Text, txtNoiDung.Text);
            txtSource.Text = obj.GetData;

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(txtSource.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            pictureBox1.Image = qrCodeImage;

        }
    }


}
