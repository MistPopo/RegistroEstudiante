using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.Extensions.Logging;
using RegistroEstudiante.Modelos.Modelos;

namespace RegistroEstudiante.AppMovil
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
            FirebaseClient client = new FirebaseClient("https://registroestudiantes-c0b92-default-rtdb.firebaseio.com/");

            var cargos = client.Child("Cargos").OnceAsync<Cargo>();

            if (cargos.Result.Count == 0)
            {
                client.Child("Cargos").PostAsync(new Cargo { Nombre = "1 Medio" });
                client.Child("Cargos").PostAsync(new Cargo { Nombre = "2 Medio" });
                client.Child("Cargos").PostAsync(new Cargo { Nombre = "3 Medio" });
                client.Child("Cargos").PostAsync(new Cargo { Nombre = "4 Medio" });
            }
        }
    }
}
