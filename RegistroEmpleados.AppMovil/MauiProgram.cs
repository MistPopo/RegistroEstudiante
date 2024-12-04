using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.Extensions.Logging;
using RegistroEmpleados.Modelos.Modelos;

namespace RegistroEmpleados.AppMovil
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            Registrar();
            return builder.Build();


        }

        public static void Registrar()
        {
            FirebaseClient client = new FirebaseClient("https://registroempleados-a6a40-default-rtdb.firebaseio.com/");

            var cargos = client.Child("Cargos").OnceAsync<Cargo>();

            if (cargos.Result.Count == 0) 
            {
                client.Child("Cargos").PostAsync(new Cargo { Nombre = "Administrador" });
                client.Child("Cargos").PostAsync(new Cargo { Nombre = "Supervisor" });
                client.Child("Cargos").PostAsync(new Cargo { Nombre = "Usuario" });
            }
        }
    }
}
