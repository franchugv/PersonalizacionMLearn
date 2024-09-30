namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnHorizontalClicked(object sender, EventArgs e)
        {
            // Recursos
            bool esValido = true;
            string mensajeError = "";
            Button botones = (Button)sender;

            try
            {
                switch (botones.Text)
                {
                    case "Start":
                        target.HorizontalOptions = LayoutOptions.Start;
                        break;
                    case "Center":
                        target.HorizontalOptions = LayoutOptions.Center;    
                        break;
                    case "End":
                        target.HorizontalOptions = LayoutOptions.End;
                        break;
                    case "Fill":
                        target.HorizontalOptions = LayoutOptions.Fill;
                        break;

                }
            }
            catch(Exception error)
            {
                esValido = false;
                mensajeError = error.Message;
            }
            finally
            {
                if (!esValido) MostrarError(mensajeError);
            }
        }



        private void OnVerticalClicked(object sender, EventArgs e)
        {
            // Recursos
            bool esValido = true;
            string mensajeError = "";
            Button botones = (Button)sender;

            try
            {
                switch (botones.Text)
                {
                    case "Start":
                        target.VerticalOptions = LayoutOptions.Start;
                        break;
                    case "Center":
                        target.VerticalOptions = LayoutOptions.Center;
                        break;
                    case "End":
                        target.VerticalOptions = LayoutOptions.End;
                        break;
                    case "Fill":
                        target.VerticalOptions = LayoutOptions.Fill;
                        break;

                }
            }
            catch (Exception error)
            {
                esValido = false;
                mensajeError = error.Message;
            }
            finally
            {
                if (!esValido) MostrarError(mensajeError);
            }
        }


        private void MostrarError(string mensajeError)
        {
            DisplayAlert("Error", $"Error: {mensajeError}", "Ok");
        }
    }

}
