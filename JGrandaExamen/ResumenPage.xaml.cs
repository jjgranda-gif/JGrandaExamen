namespace JGrandaExamen;

public partial class ResumenPage : ContentPage
{
    public ResumenPage(string usuario, string nombre, string apellido, string edad,
                       string fecha, string ciudad, string pais,
                       string inicial, string mensual, string total)
    {
        InitializeComponent();

        lblUsuario.Text = "Usuario conectado: " + usuario;
        lblNombre.Text = nombre;
        lblApellido.Text = apellido;
        lblEdad.Text = edad;
        lblFecha.Text = fecha;
        lblCiudad.Text = ciudad;
        lblPais.Text = pais;
        lblInicial.Text = "$" + inicial;
        lblMensual.Text = "$" + mensual;
        lblTotal.Text = "$" + total;
    }
}