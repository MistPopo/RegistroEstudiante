using Firebase.Database;
using Firebase.Database.Query;
using RegistroEstudiante.Modelos.Modelos;
namespace RegistroEstudiante.AppMovil.Vistas;

public partial class CrearEstudiante : ContentPage
{
    FirebaseClient client = new FirebaseClient("https://registroestudiantes-c0b92-default-rtdb.firebaseio.com/");
    public List<Cargo> Cargos { get; set; }
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
    public CrearEstudiante()
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
    {
        InitializeComponent();
        ListarCargos();
        BindingContext = this;
    }

    private void ListarCargos()
    {
        var cargos = client.Child("Cargos").OnceAsync<Cargo>();
        Cargos = cargos.Result.Select(x => x.Object).ToList();

    }

    private async void GuardarButton_Clicked(object sender, EventArgs e)
    {
        Cargo? cargo = CursoPicker.SelectedItem as Cargo;

        var estudiante = new Estudiante
        {
            PrimerNombre = primerNombreEntry.Text,
            SegundoNombre = segundoNombreEntry.Text,
            PrimerApellido = primerApellidoEntry.Text,
            SegundoApellido = segundoApellidoEntry.Text,
            CorreoElectronico = correoEntry.Text,
            FechaInicio = fechaInicioPicker.Date,
            edad = int.Parse(edadEntry.Text),
            Cargo = cargo

        };

        try
        {
            await client.Child("Estudiante").PostAsync(estudiante); // Guardar el estudiante en la base de datos

            await DisplayAlert("Exito", $"El Estudiante {estudiante.PrimerNombre} {estudiante.PrimerApellido} fue guardado correctamente",
            "OK"); // Mostrar mensaje de alerta - Titulo, Mensaje, Boton

            await Navigation.PopAsync(); // Regresar a la pagina anterior
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error!", $"Ocurrio un error al guardar el Estudiante: {ex.Message}", "OK");
        }

    }
}