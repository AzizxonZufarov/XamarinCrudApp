using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        string filePath;
        public AddPage()
        {
            InitializeComponent();
        }

        private async void SaveItem(object sender, EventArgs e)
        {
            string title = titleField.Text.Trim();
            string desc = descField.Text.Trim();
            string image = filePath.ToString();
            int price = Convert.ToInt32(priceField.Text.Trim());
            if (title.Length < 5)
            {
                await DisplayAlert("Error", "Title min 5", "ok");
                return;
            }
            if (desc.Length < 10)
            {
                await DisplayAlert("Error", "Desc min 10", "ok");
                return;
            }
            if (desc.Length < 15)
            {
                await DisplayAlert("Error", "Desc min 15", "ok");
                return;
            }
            if (price < 20)
            {
                await DisplayAlert("Error", "Price min 20", "ok");
                return;
            }

            Item item = new Item
            {
                Title = title,
                Desc = desc,
                Image = image,
                Price = price,
            };
            App.Db.SaveItem(item);
            titleField.Text = "";
            descField.Text = "";
            imageField.Source = "";
            priceField.Text = "";
            await Navigation.PopAsync();
        }

        private async void GetImagePath(object sender, EventArgs e)
        {
            var file = await FilePicker.PickAsync();

            if (file == null)
                return;
            filePath = file.FullPath;
            imageField.Source = filePath.ToString();
        }
    }
}