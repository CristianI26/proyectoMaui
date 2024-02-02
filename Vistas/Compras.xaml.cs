using Newtonsoft.Json;
using System.Collections.ObjectModel;
using proyectoMaui.Modelos;


namespace proyectoMaui.Vistas;

public partial class Compras : ContentPage
{
	
	
        private const string Url = "http://192.168.200.8:8080/licoreria/mercancia.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Productos> prod;

    public Compras()

    {
        InitializeComponent();
        Obtener();
    }
    public async void Obtener()
    {
        try
        {
            var content = await cliente.GetStringAsync(Url);
            List<Productos> mostrarProd = JsonConvert.DeserializeObject<List<Productos>>(content);
            prod = new ObservableCollection<Productos>(mostrarProd);
            listaProductos.ItemsSource = prod;
        }
        catch (Exception ex)
        {
            // Mostrar mensaje de error o registrar la excepción para su posterior análisis.
            Console.WriteLine("Error al obtener los Datos:" + ex.Message);

        }
    }

    private void listaProductos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            var objetoproductos = (Productos) e.SelectedItem;
            //Navigation.PushAsync(new ActualizarEliminar(objetoestudiante));

            // Deseleccionar el elemento de la lista
            listaProductos.SelectedItem = null;

        }
    }

    private void btnClientes_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Vistas.Clientes());
    }
}