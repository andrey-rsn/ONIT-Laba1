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
    public partial class UpdateForm : Form
    {
        private readonly ISongRepository _songRepository;
        private Song _songToUpdate;

        public delegate void UpdateEntityDelegate();

        public event UpdateEntityDelegate UpdateEntity;
        public UpdateForm(ISongRepository songRepository,Song song)
        {
            InitializeComponent();
            _songRepository = songRepository;
            _songToUpdate = song;
            this.NameTextBox.Text = song.Name;
            this.GenreTextBox.Text = song.Genre;
            this.AQTextBox.Text = Convert.ToString(song.AuditionsQuantity);
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var song = _songRepository.GetById(_songToUpdate.SongId);

                song.Name = this.NameTextBox.Text;
                song.Genre = this.GenreTextBox.Text;
                song.AuditionsQuantity = Int32.Parse(this.AQTextBox.Text);

                _songRepository.Update(song);
                UpdateEntity?.Invoke();
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
