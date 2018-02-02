using ic2.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ic2
{
    public partial class FormOP : Form
    {
        IMongoDatabase db;
        IMongoCollection<Person> collection;
        //List<Person> people = new List<Person>();
        dbContext dbCont;
        public FormOP()
        {
            InitializeComponent();
            DbInit();
        }

        private void DbInit()
        {
            string con = ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString;
            MongoClient client = new MongoClient(con);
            db = client.GetDatabase("infocenter");
            collection = db.GetCollection<Person>("people");
            dbCont = new dbContext(collection);
        }
        //добавить данные
        private void bAddUser_Click(object sender, EventArgs e)
        {
            Person person = new Person();
            person.Winlogin = txtWinlogin.Text;
            person.Fa = txtFa.Text;
            person.Im = txtIm.Text;
            person.Ot = txtOt.Text;
            person.Bday = dtpBday.Value.Date.Ticks;
            dbCont.Insert(person);
            personBindingSource.DataSource = dbCont.All();
            dataGridView1.Rows[dataGridView1.RowCount - 1].Selected = true;
            txtFa.Text = ""; txtIm.Text = ""; txtOt.Text = ""; txtWinlogin.Text = "";
            dtpBday.Value = new DateTime(1901, 1, 1);
        }

        private void FormOP_Load(object sender, EventArgs e)
        {
            //people = dbCont.All();
            personBindingSource.DataSource = dbCont.All();
        }

        //двигаемся по гриду
        private void personBindingSource_PositionChanged(object sender, EventArgs e)
        {
            txtWinlogin.Text = (personBindingSource.Current as Person).Winlogin;
            txtFa.Text = (personBindingSource.Current as Person).Fa;
            txtIm.Text = (personBindingSource.Current as Person).Im;
            txtOt.Text = (personBindingSource.Current as Person).Ot;
            if((personBindingSource.Current as Person).Bday>=0)
            dtpBday.Value = new DateTime((personBindingSource.Current as Person).Bday);
        }

        private void bSaveUser_Click(object sender, EventArgs e)
        {
            Person person = new Person();
            person._id = (personBindingSource.Current as Person)._id;
            person.Winlogin = txtWinlogin.Text;
            person.Fa = txtFa.Text;
            person.Im = txtIm.Text;
            person.Ot = txtOt.Text;
            person.Bday = dtpBday.Value.Date.Ticks;
            dbCont.Update(person);
            personBindingSource.DataSource = dbCont.All();
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            dbCont.Delete(personBindingSource.Current as Person);
            personBindingSource.DataSource = dbCont.All();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                long v = (long)e.Value;
                e.Value = new DateTime(v).Date;
            }
        }
    }
}
