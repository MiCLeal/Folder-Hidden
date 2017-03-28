using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Folder.Hidden.Client
{
    public partial class Enter : Form
    {
        public Enter()
        {
            InitializeComponent();
        }

        private void linkForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Controls.Add(new Button()
            {
                Name = "btnReset",
                Text = "Reset",
                Size = new Size(165, 23),
                Location = new Point(59, 186),
                Font = new Font("Consolas", 8.25f)
            });

            this.Controls.Add(new Controls.TextBoxPlaceholder()
            {
                Name = "txtPlaceholderResetCode",
                PlaceholderText = "Reset Code",
                Size = new Size(165, 20),
                Location = new Point(59, 160),
                Font = new Font("Consolas", 8.25f)
            });

            foreach(Control ctr in this.Controls)
            {
                if (ctr.Name.Equals("btnReset"))
                    ctr.Click += Reset_Click;
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Enter_Click(object sender, EventArgs e)
        {

        }
    }
}
