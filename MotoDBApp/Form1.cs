using MotoDBApp.FolderForModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotoDBApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static ModelDB DB = new ModelDB();

        List<Table_Motorbike> Motorbikes = DB.Table_Motorbike.ToList();
        int AccNumber = 0;


        private void Form1_Load(object sender, EventArgs e)
        {
            Loading();
        }
        private void Loading() 
        {
            userControlName1.Fill(Motorbikes[AccNumber]); 
            userControlName2.Fill(Motorbikes[AccNumber + 1]); 
        }
        private void Loading(bool Incr) //Перегрузка метода Loading, чтобы на вход были другие параметры
        {
            if (Incr == true && Motorbikes.Count > AccNumber + 2) //проверка при нажатии "Листать вправо"
                AccNumber++;
            else if (Incr == false && 0 <= AccNumber - 1) //проверка при нажатии "Листать влево"
                AccNumber--;
            else
                return; //Если проверка не пройдена выход из метода

            Loading();
        }
        private void buttonLeft_Click(object sender, EventArgs e)
        {
            Loading(false);
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            Loading(true);
        }

        private void userControlName2_Load(object sender, EventArgs e)
        {

        }
    }
}
