namespace JGrandaExamen;

public partial class LoginPage : ContentPage
{
    // Matriz 2x2: usuario y contraseña
    string[,] usuarios = {
        { "estudiante", "moviles" },
        { "suda", "2025" }
    };

    public LoginPage()
    {
        InitializeComponent();
    }

    private async void BtnIniciar_Clicked(object? sender, EventArgs e)
    {
        bool correcto = false;

        for (int i = 0; i < 2; i++)
        {
            if (txtUsuario.Text == usuarios[i, 0] && txtClave.Text == usuarios[i, 1])
            {
                correcto = true;
            }
        }

        if (correcto)
        {
            await Navigation.PushAsync(new RegistroPage(txtUsuario.Text ?? ""));
        }
        else
        {
            await DisplayAlertAsync("Error", "Usuario o contraseña incorrectos", "OK");
        }
    }
}