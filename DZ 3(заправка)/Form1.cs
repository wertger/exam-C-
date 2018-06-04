using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ_3_заправка_
{
    public partial class Form1 : Form
    {
        public Form1()//конструктор
        {
            InitializeComponent();
            lblPayCafe.Text = "0";          
            lblPayOil.Text = "0";
            lblPayAll.Text = "0";
        }

        //если выбран радиобатон "литры"
        private void rBtnKol_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton Tmp = (RadioButton)sender;
            if (Tmp.Checked == true)
            {
                txtBxLitr.Enabled = true;
                txtBxGrn.Enabled = false;
            }
        }
        //подсчет по кафе при выборе количества еды
        private void cbBxCntHotD_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPayCafe.Text = ((Convert.ToDouble(txtBxPrHotD.Text) * Convert.ToDouble(cbBxCntHotD.Text)) + (Convert.ToDouble(txtBxPrGamb.Text) * Convert.ToDouble(cbBxCntGamb.Text)) + (Convert.ToDouble(txtBxPrPotFr.Text) * Convert.ToDouble(cbBxCntPotFr.Text)) + (Convert.ToDouble(txtBxPrCola.Text) * Convert.ToDouble(cbBxCntCola.Text))).ToString();
        }

        private void cbBxCntGamb_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPayCafe.Text = ((Convert.ToDouble(txtBxPrHotD.Text) * Convert.ToDouble(cbBxCntHotD.Text)) + (Convert.ToDouble(txtBxPrGamb.Text) * Convert.ToDouble(cbBxCntGamb.Text)) + (Convert.ToDouble(txtBxPrPotFr.Text) * Convert.ToDouble(cbBxCntPotFr.Text)) + (Convert.ToDouble(txtBxPrCola.Text) * Convert.ToDouble(cbBxCntCola.Text))).ToString();
        }

        private void cbBxCntPotFr_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPayCafe.Text = ((Convert.ToDouble(txtBxPrHotD.Text) * Convert.ToDouble(cbBxCntHotD.Text)) + (Convert.ToDouble(txtBxPrGamb.Text) * Convert.ToDouble(cbBxCntGamb.Text)) + (Convert.ToDouble(txtBxPrPotFr.Text) * Convert.ToDouble(cbBxCntPotFr.Text)) + (Convert.ToDouble(txtBxPrCola.Text) * Convert.ToDouble(cbBxCntCola.Text))).ToString();
        }

        private void cbBxCntCola_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPayCafe.Text = ((Convert.ToDouble(txtBxPrHotD.Text) * Convert.ToDouble(cbBxCntHotD.Text)) + (Convert.ToDouble(txtBxPrGamb.Text) * Convert.ToDouble(cbBxCntGamb.Text)) + (Convert.ToDouble(txtBxPrPotFr.Text) * Convert.ToDouble(cbBxCntPotFr.Text)) + (Convert.ToDouble(txtBxPrCola.Text) * Convert.ToDouble(cbBxCntCola.Text))).ToString();
        }

        //вносишь сколько литров - система выдает сколько с тебя денег
        private void txtBxLitr_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtBxLitr.Text))
            lblPayOil.Text = (Convert.ToDouble(txtBxLitr.Text) * Convert.ToDouble(txtBxPrBenz.Text)).ToString();
        }

        //если выбран радиобатон "сума"
        private void rBtnSum_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton Tmp = (RadioButton)sender;
            if (Tmp.Checked == true)
            {
                txtBxGrn.Enabled = true;
                txtBxLitr.Enabled = false;
            }
        }

        //вносим деньги - система считает литры бензина к заправке
        private void txtBxGrn_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBxGrn.Text))
            {
                txtBxLitr.Text = (Convert.ToDouble(txtBxGrn.Text) / Convert.ToDouble(txtBxPrBenz.Text)).ToString();
                lblPayOil.Text = txtBxGrn.Text;
            }
        }
     
       
        private void Form1_Load(object sender, EventArgs e)
        {
            //заполнение Comboboxов цен и количество в кафе
            string[] kol = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            
            cbBxCntHotD.Items.AddRange(kol);
            cbBxCntGamb.Items.AddRange(kol);
            cbBxCntPotFr.Items.AddRange(kol);
            cbBxCntCola.Items.AddRange(kol);

            txtBxLitr.Enabled = false;
            txtBxGrn.Enabled = false;

            txtBxPrHotD.Text = "25";
            txtBxPrGamb.Text = "30";
            txtBxPrPotFr.Text = "12,50";
            txtBxPrCola.Text = "10,50";          
        } 
             
        //заполнение полей марка бензина и его цена
        private void cbBxBenz_SelectedIndexChanged(object sender, EventArgs e)
        {
            double[] priceOil = { 22.5, 23.50, 25.50, 23.00 };
            if (cbBxBenz.Text == "А-92") txtBxPrBenz.Text = Convert.ToString(priceOil[0]);
            if (cbBxBenz.Text == "А-95") txtBxPrBenz.Text = Convert.ToString(priceOil[1]);
            if (cbBxBenz.Text == "А-98") txtBxPrBenz.Text = Convert.ToString(priceOil[2]);
            if (cbBxBenz.Text == "А-Дизель") txtBxPrBenz.Text = Convert.ToString(priceOil[3]);
            lblPayOil.Text = (Convert.ToDouble(txtBxPrBenz.Text) * Convert.ToDouble(txtBxLitr.Text)).ToString();
        }

        //общая сумма к оплате
        private void BtnCount_Click(object sender, EventArgs e)
        {
            lblPayAll.Text = ((Convert.ToDouble(lblPayOil.Text) + (Convert.ToDouble(lblPayCafe.Text)))).ToString();
        }

        //очистить поля после рассчета;
        private void btnClear_Click(object sender, EventArgs e)
        {
            //    cbBxBenz.Text = "Оберіть";
            //    txtBxPrBenz.Text = "0";
            //    rBtnKol.Checked = false;
            //    rBtnSum.Checked = false;
            //    txtBxLitr.Text = " ";
            //    txtBxGrn.Text = " ";
            //    cbBxCntHotD.Text = "0";
            //    cbBxCntGamb.Text = "0";
            //    cbBxCntPotFr.Text = "0";
            //    cbBxCntCola.Text = "0";
        }
    }
}

