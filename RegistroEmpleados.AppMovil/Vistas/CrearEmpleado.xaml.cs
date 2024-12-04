using Firebase.Database;
using Firebase.Database.Query;
using RegistroEmpleados.Modelos.Modelos;
namespace RegistroEmpleados.AppMovil.Vistas;

public partial class CrearEmpleado : ContentPage
{
    FirebaseClient client = new FirebaseClient("https://registroempleados-a6a40-default-rtdb.firebaseio.com/");
    public List<Cargo> Cargos { get; set; }
    public CrearEmpleado()
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

    private async void guardarButton_Clicked(object sender, EventArgs e)
    {
		Cargo cargo = cargoPicker.SelectedItem as Cargo;

        var empleado = new Empleado
        {
            PrimerNombre = primerNombreEntry.Text,
            SegundoNombre = segundoNombreEntry.Text,
            PrimerApellido = primerApellidoEntry.Text,
            SegundoApellido = segundoApellidoEntry.Text,
            CorreoElectronico = correoEntry.Text,
            FechaInicio = fechaInicioPicker.Date,
            Sueldo = int.Parse(sueldoEntry.Text),
            Cargo = cargo

        };

        try
        {
            await client.Child("Empleados").PostAsync(empleado); // Guardar el empleado en la base de datos
            
            await DisplayAlert("Exito", $"El Empleado {empleado.PrimerNombre} {empleado.PrimerApellido} fue guardado correctamente",
            "OK"); // Mostrar mensaje de alerta - Titulo, Mensaje, Boton
            
            await Navigation.PopAsync(); // Regresar a la pagina anterior
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error!", $"Ocurrio un error al guardar el empleado: {ex.Message}", "OK");
        }

    }
}