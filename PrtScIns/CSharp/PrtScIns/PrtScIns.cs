using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrtScIns
{
    public partial class PrtScIns : Form
    {
        public PrtScIns()
        {
            InitializeComponent();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            SerialPortClose();
            Application.Exit();
        }

        private void PrtScIns_Load(object sender, EventArgs e)
        {
            SerialPortOpen();
        }

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string receivedData = serialPort.ReadLine().Replace("\r", "").Replace("\n", "");
            if(receivedData == "PrtSc")
            {
                SendKeys.SendWait("{PRTSC}");
            }

            if (receivedData == "Ins")
            {
                SendKeys.SendWait("{INS}");
            }
        }

        #region プライベートメソッド
        private void SerialPortOpen()
        {
            serialPort.PortName = "COM3";
            serialPort.BaudRate = 9600;
            serialPort.Open();
        }

        private void SerialPortClose()
        {
            serialPort.Close();
        }

        #endregion
    }
}
