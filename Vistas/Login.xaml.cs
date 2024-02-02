namespace proyectoMaui.Vistas;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private void btnIngresar_Clicked(object sender, EventArgs e)
    {
        string usuario = txtUsuario.Text;
        string contrasena = txtContrasena.Text;

        if (txtUsuario.Text == "admin" && txtContrasena.Text == "admin123")
        {
            DisplayAlert("Bienvenido", "Usuario : " + usuario, "OK");
            Navigation.PushAsync(new Vistas.Compras());
        }
        if (txtUsuario.Text == "Ana" && txtContrasena.Text == "ana123")
        {
            DisplayAlert("Bienvenido", "Usuario : " + usuario, "OK");
            Navigation.PushAsync(new Vistas.Compras());
        }
        if (txtUsuario.Text == "Jose" && txtContrasena.Text == "jose123")
        {
            DisplayAlert("Bienvenido", "Usuario : " + usuario, "OK");

            Navigation.PushAsync(new Vistas.Compras());
        }

        else


        {
            DisplayAlert("alerta", "El usuario no existe o ingresaste mal la contraseña", "Cancel");
        }

    }
}