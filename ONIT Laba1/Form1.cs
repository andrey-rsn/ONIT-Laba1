using ONIT_Laba1.Data.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ONIT_Laba1
{
    public partial class Form1 : Form
    {
        private ObservableCollection<Song> _songGrid;

        
        public Form1(Data.Repositories.ISongRepository songRepo)
        {
            _songRepo = songRepo;
            InitializeComponent();
            _songGrid = new ObservableCollection<Song>(_songRepo.GetAll());
            _songGrid.CollectionChanged += songGrid_CollectionChanged;
            this.dataGridView1.DataSource = _songGrid;
        }

        private void onDataModified()
        {
            _songGrid = new ObservableCollection<Song>(_songRepo.GetAll());
            RefreshSongGrid();

        }

        private void songGrid_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Remove:
                    {
                        if(e.NewItems?[0] is Song song) _songRepo.Delete(song);
                        break;
                    }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                _songGrid.Remove(row.DataBoundItem as Song);
            }
            RefreshSongGrid();
        }

        private void RefreshSongGrid()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = _songGrid;
            this.dataGridView1.Refresh();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var addForm = new AddForm(_songRepo);
            addForm.DataModified +=onDataModified;
            addForm.Show();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if(this.dataGridView1.SelectedRows.Count==0)
            {
                MessageBox.Show("Выберите элемент для изменения");
            }
            else
            {
                foreach(DataGridViewRow row in this.dataGridView1.SelectedRows)
                {
                    var updateForm = new UpdateForm(_songRepo, row.DataBoundItem as Song);
                    updateForm.UpdateEntity += onDataModified;
                    updateForm.Show();
                }
                
            }
        }
    }
}