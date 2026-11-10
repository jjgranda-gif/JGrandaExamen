namespace JGrandaExamen;

public partial class RegistroPage : ContentPage
{
    string usuario;
    double costoCurso = 1500;
    double montoInicial = 0;
    double pagoMensual = 0;

    // Países con sus ciudades
    Dictionary<string, List<string>> ciudades = new Dictionary<string, List<string>>()
    {
        { "Ecuador", new List<string> { "Cuenca", "Quito", "Guayaquil" } },
        { "Colombia", new List<string> { "Bogotá", "Medellín", "Cali" } },
        { "Perú", new List<string> { "Lima", "Cusco", "Arequipa" } }
    };

    public RegistroPage(string usuarioConectado)
    {
        InitializeComponent();
        usuario = usuarioConectado;
        lblUsuario.Text = "Usuario conectado: " + usuario;
        pickerPais.ItemsSource = new List<string>(ciudades.Keys);
    }

    // Cuando se elige un país, se cargan sus ciudades
    private void PickerPais_SelectedIndexChanged(object? sender, EventArgs e)
    {
        string? pais = pickerPais.SelectedItem?.ToString();

        if (pais != null)
        {
            pickerCiudad.ItemsSource = ciudades[pais];
        }
    }

    private async void BtnCalcular_Clicked(object? sender, EventArgs e)
    {
        if (!double.TryParse(txtMonto.Text, out montoInicial) || montoInicial < 0 || montoInicial > costoCurso)
        {
            await DisplayAlertAsync("Error", "Ingrese un monto válido (entre 0 y 1500)", "OK");
            return;
        }

        double resto = costoCurso - montoInicial;
        double cuota = resto / 4;
        double recargo = costoCurso * 0.04;   // 4% del costo

        pagoMensual = cuota + recargo;
        txtPagoMensual.Text = pagoMensual.ToString("F2");
    }

    private async void BtnResumen_Clicked(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
            string.IsNullOrWhiteSpace(txtApellido.Text) ||
            string.IsNullOrWhiteSpace(txtEdad.Text) ||
            pickerPais.SelectedItem == null ||
            pickerCiudad.SelectedItem == null ||
            string.IsNullOrWhiteSpace(txtPagoMensual.Text))
        {
            await DisplayAlertAsync("Error", "Complete todos los datos y calcule el pago mensual", "OK");
            return;
        }

        double pagoTotal = montoInicial + (pagoMensual * 4);

        string fecha = dpFecha.Date?.ToString("dd/MM/yyyy") ?? "";
        string pais = pickerPais.SelectedItem?.ToString() ?? "";
        string ciudad = pickerCiudad.SelectedItem?.ToString() ?? "";

        await Navigation.PushAsync(new ResumenPage(
            usuario,
            txtNombre.Text ?? "",
            txtApellido.Text ?? "",
            txtEdad.Text ?? "",
            fecha,
            ciudad,
            pais,
            montoInicial.ToString("F2"),
            pagoMensual.ToString("F2"),
            pagoTotal.ToString("F2")));
    }
}