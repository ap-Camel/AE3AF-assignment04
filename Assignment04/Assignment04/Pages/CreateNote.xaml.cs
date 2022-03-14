using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Assignment04.Classes;

namespace Assignment04.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateNote : ContentPage
    {

        Note note;
        public CreateNote()
        {
            InitializeComponent();

            note = new Note();
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            note.title = Title.Text;
            note.details = Details.Text;
            note.date = DatePicker.Date;
            note.status = Switch.IsToggled;

            await Navigation.PushAsync(new NoteDetails(note));
        }
    }
}