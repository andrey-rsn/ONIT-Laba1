using ONIT_Laba1.Data.Models;
using ONIT_Laba1.Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ONIT_Laba1
{
    public partial class AddForm : Form
    {
        private readonly ISongRepository _songRepository;

        public delegate void DataModifiedDelegate();

        public event DataModifiedDelegate DataModified;
        public AddForm(ISongRepository songRepository)
        {
            _songRepository = songRepository;
            InitializeComponent();
        }


        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                var song = new Song()
                {
                    Name = this.NameTextBox.Text,
                    Genre = this.GenreTextBox.Text,
                    AuditionsQuantity = Int32.Parse(this.AQTextBox.Text)
                };
                _songRepository.Add(song);
                DataModified?.Invoke();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
