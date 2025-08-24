using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson_5_1_Graphic
{
    public partial class Form1 : Form
    {
        SqlConnection conn = null;
        SqlDataAdapter dataqAdapter = null;
        DataSet dataSet = null;
        string str = "";
        string fileName = "";

        public Form1()
        {
            InitializeComponent();

            str = ConfigurationManager.ConnectionStrings["Company_db"].ConnectionString;
            conn = new SqlConnection(str);
        }

        private void bt_LoadPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Графические файлы | *bmp; *.png; *.jpeg; *.gif";
            ofd.FileName = "";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileName = ofd.FileName;
                LoadPicture();
            }
        }

        private void LoadPicture()
        {
            try
            {
                byte[] bytes = CreateCopy();

                conn.Open();

                SqlCommand cmd = new SqlCommand("insert into dbo.Pictures(Customer_ID, _Name, Picture)" +
                                                "values (@customerID, @name, @picture);", conn);

                if (tb_InsertID.Text == null || tb_InsertID.Text.Length == 0)
                {
                    return;
                }

                int index = -1;
                int.TryParse(tb_InsertID.Text, out index);

                cmd.Parameters.Add("@customerID", SqlDbType.Int).Value= index;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 255).Value = fileName;
                cmd.Parameters.Add("@picture", SqlDbType.Image, bytes.Length).Value = bytes;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Error LoadPicture");
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private byte[] CreateCopy()
        {
            try
            {
                Image img = Image.FromFile(fileName);

                int maxWidth = 300, maxHeight = 300;
                double ratioX = (double)maxWidth / img.Width;
                double ratioY = (double)maxHeight / img.Height;
                double ratio = Math.Min(ratioX, ratioY);
                int newWidth = (int)(img.Width * ratio);
                int newHeight = (int)(img.Height * ratio);

                Image currentImage = new Bitmap(newWidth, newHeight);
                Graphics g = Graphics.FromImage(currentImage);
                g.DrawImage(currentImage, 0, 0, newWidth, newHeight);

                MemoryStream ms = new MemoryStream();
                currentImage.Save(ms, ImageFormat.Jpeg);

                ms.Flush();
                ms.Seek(0, SeekOrigin.Begin);

                BinaryReader br = new BinaryReader(ms);
                byte[] buf = br.ReadBytes((int)ms.Length);

                return buf;

            }
            catch (Exception)
            {
                MessageBox.Show("Error CreateCopy");

                return null;
            }
        }

        private void bt_ShowAll_Click(object sender, EventArgs e)
        {
            try

            {
                dataqAdapter = new SqlDataAdapter("select * from dbo.Pictures;", conn);

                SqlCommandBuilder cmd = new SqlCommandBuilder(dataqAdapter);

                dataSet=new DataSet();

                dataqAdapter.Fill(dataSet, "picture");

                dgv_ShowData.DataSource = dataSet.Tables["Picture"];

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }
        }

        private void bt_ShowOne_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_InsertID.Text == null || tb_InsertID.Text.Length == 0)
                {
                    MessageBox.Show("Укажите id клиента");
                    return;
                }
                int index = -1;
                int.TryParse(tb_InsertID.Text, out index);
                if (index == -1)
                {
                    MessageBox.Show("Укажите id клиента  в правильном формате");
                    return;
                }
                dataqAdapter = new SqlDataAdapter("select Picture from dbo.Pictures where Customer_ID=@Id", conn);
                SqlCommandBuilder cmb = new SqlCommandBuilder(dataqAdapter);
                dataqAdapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = index;
                dataSet = new DataSet();
                dataqAdapter.Fill(dataSet);
                byte[] bytes = (byte[])dataSet.Tables[0].Rows[0]["Picture"];
                MemoryStream ms = new MemoryStream(bytes);
                pb_ShowPicture.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
