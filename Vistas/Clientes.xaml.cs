using Newtonsoft.Json;
using proyectoMaui.Modelos;
using System.Collections.ObjectModel;

namespace proyectoMaui.Vistas;

public partial class Clientes : ContentPage
{
    private const string Url = "http://192.168.200.8:8080/licoreria/post.php";
    private readonly HttpClient promo = new HttpClient();
    private ObservableCollection<Clientes> clie;

    public Clientes()

    {
        InitializeComponent();
        Obtener();
    }
    public async void Obtener()
    {
        try
        {
            var content = await promo.GetStringAsync(Url);
            List<Clientes> mostrarclie = JsonConvert.DeserializeObject<List<Clientes>>(content);
            clie = new ObservableCollection<Clientes>(mostrarclie);
            listaClientes.ItemsSource = clie;
        }
        catch (Exception ex)
        {
            // Mostrar mensaje de error o registrar la excepción para su posterior análisis.
            Console.WriteLine("Error al obtener los Datos:" + ex.Message);

        }
    }


    private void listaClientes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            var objetopromo = (Clientes)e.SelectedItem;
            //Navigation.PushAsync(new ActualizarEliminar(objetoestudiante));

            // Deseleccionar el elemento de la lista
           
            listaClientes.SelectedItem = null;
        }
    }
}