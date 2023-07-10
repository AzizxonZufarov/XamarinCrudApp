using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
namespace XamarinForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditDetail : ContentPage
    {
        
        Item _item;
        string filePath;
        public EditDetail()
        {
            InitializeComponent();
        }

        public EditDetail(Item item)
        {
            InitializeComponent();
            _item = item;
            titleField.Text = item.Title;
            descField.Text = item.Desc;
            imageField.Source = item.Image;
            filePath = item.Image;
            priceField.Text = item.Price.ToString();

        }      
        
        private async void UpdateItem(object sender, EventArgs e)
        {
            _item.Title = titleField.Text;
            _item.Desc = descField.Text;
            _item.Image = filePath.ToString();
            _item.Price = Convert.ToInt32(priceField.Text.Trim());
            App.Db.UpdateItem(_item);
            await Navigation.PopAsync();
        }

        private async void GetImagePath(object sender, EventArgs e)
        {
            var file = await FilePicker.PickAsync();

            if (file == null)
                return;
            filePath = file.FullPath.ToString();
            imageField.Source = filePath;
        }
    }
}