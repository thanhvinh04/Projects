using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSA_CTDLGT
{
    public partial class Formbd : Form
    {
        public bool ktra = false;
        public Form1 form1 = new Form1();

        public Formbd()
        {
            InitializeComponent();
            Thread t = new Thread(() =>
            {
                try
                {
                    form1.read();
                }
                finally
                {
                    Invoke(new Action(() => 
                    {
                        this.Hide();                  
                        form1.ShowDialog();
                        
                    }));
                    Application.ExitThread();
                    
                }

            });
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
      
        } 
        // người dùng nhấn vào tầng nền ->  không xảy ra gì 
    }
}
