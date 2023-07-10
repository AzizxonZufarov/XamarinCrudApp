using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace XamarinForms
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        /*private void Button_Click(object sender, EventArgs e)
        {
            button1.Text = "Нажато!!!";
        }*/
        protected override void OnAppearing()
        {
            ShowItems();
            /*StackLayout stack = new StackLayout();
            Label label = new Label();
            label.Text = "Hello World";
            label.TextTransform = TextTransform.Uppercase;
            label.FontSize = 25;
            Button button = new Button();
            button.Text = "Нажми меня";
            button.FontSize = 25;
            button.TextColor = Color.White;

            button.Clicked += ButtonClick;
            stack.Children.Add(label);
            stack.Children.Add(button);
            Content = stack;*/
        }

        private void ShowItems()
        {
            itemsCollection.ItemsSource = App.Db.GetItems();
        }

        private void DeleteItem(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (Item)button.BindingContext;
            App.Db.DeleteItem(item.ID);
            ShowItems();
        }

        private async void AddItem(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage());
        }

        private async void EditItem(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = button.CommandParameter as Item;
            await Navigation.PushAsync(new EditDetail(item));
        }

       
            /*private async void ButtonClick(object sender, EventArgs e)
        {
            button.Text = "Нажато";
            button.TextColor = Color.Green;
            
            if (string.IsNullOrEmpty(nameField.Text))
                errorText.Text = "Имя не указано";
            else if (string.IsNullOrEmpty(emailField.Text))
                errorText.Text = "Email не указано";
            else if (string.IsNullOrEmpty(passField.Text))
                errorText.Text = "Pass не указано";
            else if (!checkField.IsChecked)
                errorText.Text = "Checkbox не указано";
            else
            {
                errorText.Text = "";
                buttonSend.Text = "Done";
                buttonSend.TextColor = Color.Green;
                await DisplayAlert("Данные из формы", "Все данные получены", "Ok");
            }

        }*/
    }
}