using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Assignment04.Classes;

using Xamarin.Essentials;

namespace Assignment04.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteDetails : ContentPage
    {
        Note note;

        public NoteDetails(Note note)
        {
            InitializeComponent();

            this.note = note;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            lblTitile.Text = note.title;
            lblDetails.Text = note.details;
            lblDate.Text = $"{note.date.Year} {note.date.Month} {note.date.Day}";

            if (note.status) lblStatus.Text = "COMPLETED";
            else lblStatus.Text = "NOT COMPLETED";
        }

        private async void btnSend_Clicked(object sender, EventArgs e)
        {


            SmsMessage sms = new SmsMessage();
            sms.Body = $"{lblTitile.Text} \n" +
                $"{lblDetails.Text}\n" +
                $"{lblDate.Text}\n" +
                $"{lblStatus.Text}";

            sms.Recipients = new List<string>() { "+420777098367" };

            await Sms.ComposeAsync(sms);

        }
    }
}