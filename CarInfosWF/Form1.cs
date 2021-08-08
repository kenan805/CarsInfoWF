using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarInfosWF
{
    public partial class Form1 : Form
    {
        List<Car> cars;
        List<ImageList> imageLists;
        int index = 0;
        public Form1()
        {
            InitializeComponent();
            cars = new List<Car>()
            {
                 new Car(){ Vendor="BMW", Model="M5", Year=2018, Engine="Turbo 4.4l"},
                 new Car(){ Vendor="MERCEDES", Model="C43", Year=2017, Engine="Turbo 3.0l"},
                 new Car(){ Vendor="AUDI", Model="A4 Sport", Year=2016, Engine="Turbo 1.4l"},
                 new Car(){ Vendor="TESLA", Model="Model 3", Year=2019, Engine="Electric"},
            };
            imageLists = new List<ImageList>()
            {
                imageListBmw,
                imageListMerc,
                imageListAudi,
                imageListTesla
            };

        }

        private void Btn_Next_Click(object sender, EventArgs e)
        {
            label1.ImageIndex++;
            if (label1.ImageIndex > 0)
            {
                btn_Back.Visible = true;
            }
            if (label1.ImageIndex == imageListBmw.Images.Count - 1)
            {
                btn_Next.Visible = false;
            }
        }

        private void Image_Btn1_MouseHover(object sender, EventArgs e) => guna2TileButton1.BackColor = Color.Red;

        private void Image_Btn1_MouseLeave(object sender, EventArgs e) => guna2TileButton1.BackColor = Color.Transparent;

        private void Btn_Exit_Click(object sender, EventArgs e) => Application.Exit();

        private void Btn_Back_Click(object sender, EventArgs e)
        {
            label1.ImageIndex--;
            if (label1.ImageIndex < imageListBmw.Images.Count - 1)
            {
                btn_Next.Visible = true;
            }
            if (label1.ImageIndex == 0)
            {
                btn_Back.Visible = false;
            }
        }

        private void Btn_Change_Click(object sender, EventArgs e)
        {
            label1.ImageIndex = 0;
            btn_Back.Visible = false;
            btn_Next.Visible = true;
            ++index;
            if (index == cars.Count)
            {
                index = 0;
            }
            lbl_Model.Text = cars[index].Model;
            lbl_Vendor.Text = cars[index].Vendor;
            lbl_Year.Text = cars[index].Year.ToString();
            lbl_Engine.Text = cars[index].Engine;
            label1.ImageList = imageLists[index];

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbl_Model.Text = cars[0].Model;
            lbl_Vendor.Text = cars[0].Vendor;
            lbl_Year.Text = cars[0].Year.ToString();
            lbl_Engine.Text = cars[0].Engine;
            label1.ImageList = imageLists[0];
            label1.ImageIndex = 0;
        }

        private void Btn_Minimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;
    }
}
