using System.Xml;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        XmlDocument doc = new XmlDocument();

        string fileName = @"D:\New folder\WinFormsApp1\XMLFile1.xml";
        int d;

        private void HienThi()
        {
            dataGridView1.Rows.Clear();
            doc.Load(fileName);
            XmlNodeList DS = doc.SelectNodes("/ds/nhanvien");
            int sd = 0;
            dataGridView1.ColumnCount = 4;
            dataGridView1.Rows.Add();

            foreach (XmlNode nhanVien in DS)
            {
                XmlNode maNv = nhanVien.SelectSingleNode("@manv");
                dataGridView1.Rows[sd].Cells[0].Value = maNv.InnerText.ToString();

                XmlNode ho = nhanVien.SelectSingleNode("hoten/ho");
                dataGridView1.Rows[sd].Cells[1].Value = ho.InnerText.ToString();

                XmlNode ten = nhanVien.SelectSingleNode("hoten/ten");
                dataGridView1.Rows[sd].Cells[2].Value = ten.InnerText.ToString();

                XmlNode diaChi = nhanVien.SelectSingleNode("diachi");
                dataGridView1.Rows[sd].Cells[3].Value = diaChi.InnerText.ToString();
                dataGridView1.Rows.Add();
                sd++;
            }



        }

        private void From1_Load(object sender, EventArgs e)
        {
            HienThi();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            doc.Load(fileName);

            XmlElement goc = doc.DocumentElement;
            XmlNode nhanVien = doc.CreateElement("nhanvien");
            XmlAttribute maNv = doc.CreateAttribute("manv");
            maNv.InnerText = textBox5.Text;
            nhanVien.Attributes.Append(maNv);
            XmlNode hoTen = doc.CreateElement("hoten");
            XmlNode ho = doc.CreateElement("ho");
            ho.InnerText = textBox6.Text;
            hoTen.AppendChild(ho);
            XmlNode ten = doc.CreateElement("ten");
            ten.InnerText = textBox7.Text;
            hoTen.AppendChild(ten);
            nhanVien.AppendChild(hoTen);
            XmlNode diaChi = doc.CreateElement("diachi");
            diaChi.InnerText = textBox8.Text;
            nhanVien.AppendChild(diaChi);
            goc.AppendChild(nhanVien);
            doc.Save(fileName);
            HienThi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            doc.Load(fileName);

            XmlElement goc = doc.DocumentElement;
            XmlNode nhanVienCu = goc.SelectSingleNode("/ds/nhanvien[@manv='" + textBox5.Text + "']");
            XmlNode nhanVien = doc.CreateElement("nhanvien");
            XmlAttribute maNv = doc.CreateAttribute("manv");
            maNv.InnerText = textBox5.Text;
            nhanVien.Attributes.Append(maNv);
            XmlNode hoTen = doc.CreateElement("hoten");
            XmlNode ho = doc.CreateElement("ho");
            ho.InnerText = textBox6.Text;
            hoTen.AppendChild(ho);
            XmlNode ten = doc.CreateElement("ten");
            ten.InnerText = textBox7.Text;
            hoTen.AppendChild(ten);
            nhanVien.AppendChild(hoTen);
            XmlNode diaChi = doc.CreateElement("diachi");
            diaChi.InnerText = textBox8.Text;
            nhanVien.AppendChild(diaChi);
            goc.ReplaceChild(nhanVien, nhanVienCu);
            doc.Save(fileName);
            HienThi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            doc.Load(fileName);

            XmlElement goc = doc.DocumentElement;
            XmlNode nhanVien = goc.SelectSingleNode("/ds/nhanvien[@manv='" + textBox5.Text + "']");
            goc.RemoveChild(nhanVien);
            doc.Save(fileName);
            HienThi();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            d = e.RowIndex;
            textBox5.Text = dataGridView1.Rows[d].Cells[0].Value.ToString();
            textBox6.Text = dataGridView1.Rows[d].Cells[1].Value.ToString();
            textBox7.Text = dataGridView1.Rows[d].Cells[2].Value.ToString();
            textBox8.Text = dataGridView1.Rows[d].Cells[3].Value.ToString();

        }

    }
}