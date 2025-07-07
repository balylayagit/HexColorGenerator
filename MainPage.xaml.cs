namespace HexColorGenerator
{
    public partial class MainPage : ContentPage
    {
 
        public MainPage()
        {
            InitializeComponent();
        }

        bool isRandom;
        string hexValue = "";
        private void sldRed_ValueChanged(System.Object sender, Microsoft.Maui.Controls.ValueChangedEventArgs e)
        {
            if (!isRandom)
            {
                var red = sldRed.Value;
                var green = sldGreen.Value;
                var blue = sldBlue.Value;

                Color color = Color.FromRgb(red, green, blue);

                SetColor(color);
                btnRandom.Background = Container.Background;

            }
        }
        private void SetColor(Color color)
        {
            Container.Background = color;
            Container.BackgroundColor = color;
            hexValue = color.ToHex();
            lblHex.Text = hexValue;
        }

        private void btnRandom_Clicked(System.Object sender, System.EventArgs e)
        {
            isRandom = true;
            var random = new Random();

            var color = Color.FromRgb(random.Next(0, 256),
                random.Next(0, 256),
                random.Next(0, 256));

            SetColor(color);

            sldRed.Value = color.Red;
            sldGreen.Value = color.Green;
            sldBlue.Value = color.Blue;
            isRandom = false;

            btnRandom.Background = Container.Background;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(hexValue);
            /*var toast = Toast.Make("Color copied",
                CommunityToolkit.Maui.Core.ToastDuration.Short,
                12);
            await toast.Show();*/

        }
    }
}


