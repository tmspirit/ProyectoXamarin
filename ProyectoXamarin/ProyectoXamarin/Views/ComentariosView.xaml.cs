using ProyectoXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComentariosView : ContentPage
    {
        public ComentariosView()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            ComentariosViewModel viewModel = (ComentariosViewModel)this.BindingContext;
            viewModel.Comentarios = await viewModel.GetComentariosAsync();
        }
    }
}