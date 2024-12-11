using RegistroEstudiante.AppMovil.Vistas;

namespace RegistroEstudiante.AppMovil
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListarEstudiante());
        }
    }
}
