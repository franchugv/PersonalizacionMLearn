namespace MauiApp2;

public partial class Ejercicio2_vGrid : ContentPage
{
    public Ejercicio2_vGrid()
    {

        InitializeComponent();

        // Eventos
        // billInput.TextChanged += (s, e) => CalculateTip(false, false);
        // roundDown.Clicked += (s, e) => CalculateTip(false, true);
        // roundUp.Clicked += (s, e) => CalculateTip(true, false);

        tipPercentSlider.ValueChanged += (s, e) =>
        {
            double pct = Math.Round(e.NewValue);
            tipPercent.Text = pct + "%";
            CalculateTip(false, false);
        };



    }

    private void ClickedButton(object sender, EventArgs e)
    {
        // Recursos
        bool esValido = true;
        string mensajeError = "";
        Button botones = (Button)sender;

        try
        {

            switch (botones.Text)
            {
                case "15%":
                    tipPercentSlider.Value = 15;
                    break;
                case "20%":
                    tipPercentSlider.Value = 20;
                    break;
                case "Round Down":
                    CalculateTip(false, true);
                    break;
                case "Round Up":
                    CalculateTip(true, false);
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

    private void TextChanged(object sender, TextChangedEventArgs e)
    {
        // Recursos
        bool esValido = true;
        string mensajeError = "";
        Entry entry = (Entry)sender;

        try
        {
            switch (entry.Text)
            {
                case "Bill":
                    CalculateTip(false, false);
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

    private void ValueChangedSlider(object sender, ValueChangedEventArgs e)
    {
        // Recursos
        bool esValido = true;
        string mensajeError = "";
        Slider slider = (Slider)sender;

        try
        {
            //switch (slider.Id)
            //{
            //    case tipPercentSlider.Id:
            //        CalculateTip(false, false);
            //        break;
            //}
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


    void CalculateTip(bool roundUp, bool roundDown)
    {
        double t;
        if (double.TryParse(billInput.Text, out t) && t > 0)
        {
            double pct = Math.Round(tipPercentSlider.Value);
            double tip = Math.Round(t * (pct / 100.0), 2);

            double final = t + tip;

            if (roundUp)
            {
                final = Math.Ceiling(final);
                tip = final - t;
            }
            else if (roundDown)
            {
                final = Math.Floor(final);
                tip = final - t;
            }

            tipOutput.Text = tip.ToString("C");
            totalOutput.Text = final.ToString("C");


        }
    }


    private void MostrarError(string mensajeError)
    {
        DisplayAlert("Error", $"Error: {mensajeError}", "Ok");
    }
}