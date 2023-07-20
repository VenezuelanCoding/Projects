using Logic.Implementations;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Sorting : UserControl
    {

        public Form1 _form;
        public IGenreLogic _genreLogic;
        public IAccountLogic _accountLogic;

        public Sorting(Form1 form, IAccountLogic accountLogic, IGenreLogic genreLogic)
        {
            _form = form;
            _accountLogic = accountLogic;
            _genreLogic=genreLogic;
            InitializeComponent();
            comboBoxSorting.Text = _form.SortContext.ToString();
            comboBoxSorting.DropDownStyle = ComboBoxStyle.DropDownList;

        }



        private void comboBoxSorting_SelectedIndexChanged(object sender, EventArgs e)
        { 
            _form.SortContext.SetStrategy(comboBoxSorting.Text,_genreLogic,_accountLogic);
        }

        private void linkLabelBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _form.changeToAdmin();
        }
    }
}
