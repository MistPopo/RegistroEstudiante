using Firebase.Database;
using RegistroEstudiante.Modelos.Modelos;
using System.Collections.ObjectModel;

namespace RegistroEstudiante.AppMovil.Vistas;

public partial class ListarEstudiante : ContentPage
{
    FirebaseClient client = new FirebaseClient("https://registroestudiantes-c0b92-default-rtdb.firebaseio.com/");
    public ObservableCollection<Estudiante> Lista { get; set; } = new ObservableCollection<Estudiante>();
    public ListarEstudiante()
    {
        InitializeComponent();
        BindingContext = this;
        CargarLista();
    }

    private void CargarLista()
    {
        client.Child("Estudiante").AsObservable<Estudiante>().Subscribe((estudiante) =>
        {
            if (estudiante != null)
            {
                Lista.Add(estudiante.Object);
            }
        });
    }

    private void filtroSearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        string filtro = filtroSearchBar.Text.ToLower();

        if (filtro.Length > 0)
        {
            ListaCollection.ItemsSource = Lista.Where(x => x.NombreCompleto.ToLower().Contains(filtro));
        }
        else
        {
            ListaCollection.ItemsSource = Lista;
        }
    }

    private async void NuevoEstudianteBoton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CrearEstudiante());
    }
}