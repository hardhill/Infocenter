using ic2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ic2
{
    /// <summary>
    /// Логика взаимодействия для ListContacts.xaml
    /// </summary>
    public partial class ListContacts : UserControl
    {
        public List<ContactUser> wpfListContacts;
        private ArrayList arrList;
        public ListContacts()
        {
            InitializeComponent();
            wpfListContacts = new List<ContactUser>();
            arrList = new ArrayList();
            MainListBox.Items.Add(new ListBoxItem() { Content = "HELLO" });

        }

        public void ChangeList(List<ContactUser> contactUsers)
        {
            //List<string> st = new List<string>() { "Еуче1","Текст2","Третий"};
            //ListBoxItem item = new ListBoxItem();
            //MainListBox.ItemsSource = st;

            //MainListBox.ItemsSource = LoadListBoxData();
            MainListBox.Items.Add(new ListBoxItem() { Content = "GOODBYE" });
            this.UpdateLayout();
        }

        private ArrayList LoadListBoxData()
        {
            ArrayList itemsList = new ArrayList();
            itemsList.Add("Coffie");
            itemsList.Add("Tea");
            itemsList.Add("Orange Juice");
            itemsList.Add("Milk");
            itemsList.Add("Mango Shake");
            itemsList.Add("Iced Tea");
            itemsList.Add("Soda");
            itemsList.Add("Water");
            return itemsList;
        }
    }
}
