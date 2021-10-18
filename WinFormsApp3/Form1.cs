using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void show(object sender, EventArgs e)
        {

            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(PurchaseOrder));
            var stream = new FileStream("purchaseorder.xml", FileMode.Open, FileAccess.Read);

            PurchaseOrder? purchaseorder = (PurchaseOrder?)serializer.Deserialize(stream);

            purchaseorder.PurchaseOrderNumber = "99504";

            using (var outputstream = new FileStream("result.xml", FileMode.Create, FileAccess.Write))
            {
                using (stream)
                {
                    var bItems = purchaseorder.Items.Where(i => i.PartNumber.Contains("A"));
                    serializer.Serialize(outputstream, purchaseorder);


                    MessageBox.Show($"result is {string.Join(", ", bItems.Select(b => b.PartNumber))}");
                }
            }
            
        }
    }
}
