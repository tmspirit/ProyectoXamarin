using ProyectoXamarin.ViewModels;
using Syncfusion.SfCarousel.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Productos : ContentPage
    {
        public Productos()
        {
            InitializeComponent();
            CarouselViewModel carouselViewModel = new CarouselViewModel();

            SfCarousel carousel = new SfCarousel()
            {
                HeightRequest = 600,
                WidthRequest = 800,
                SelectedIndex = 1
            };

            StackLayout stackPrincipal = new StackLayout();

            Label titulo = new Label
            {
                Text = "Articulos Disponibles:",
                TextColor = Color.Blue,
                FontSize = 30,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            stackPrincipal.Children.Add(titulo);

            DataTemplate itemTemplate = new DataTemplate(() =>
            {
                StackLayout stack = new StackLayout();
                stack.HorizontalOptions = LayoutOptions.CenterAndExpand;
                stack.VerticalOptions = LayoutOptions.CenterAndExpand;

                Label nombreProducto = new Label();
                nombreProducto.SetBinding(Label.TextProperty, "Nombre");
                nombreProducto.FontSize = 25;
                nombreProducto.FontAttributes = FontAttributes.Bold;
                nombreProducto.HorizontalOptions = LayoutOptions.CenterAndExpand;

                Label descriProducto = new Label();
                descriProducto.SetBinding(Label.TextProperty, "Descripcion");
                descriProducto.FontSize = 15;
                descriProducto.FontAttributes = FontAttributes.Bold;
                descriProducto.HorizontalOptions = LayoutOptions.CenterAndExpand;

                ImageButton imagen = new ImageButton();
                imagen.SetBinding(ImageButton.SourceProperty, "Image");
                imagen.Clicked += Imagen_Clicked; ;
                imagen.BackgroundColor = Color.Transparent;

                stack.Children.Add(nombreProducto);
                stack.Children.Add(descriProducto);
                stack.Children.Add(imagen);

                return stack;
            });

            carousel.ItemTemplate = itemTemplate;
            carousel.ItemsSource = carouselViewModel.ImageCollection;

            stackPrincipal.Children.Add(carousel);
            this.Content = stackPrincipal;
        }

        private void Imagen_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DetallesProducto());
        }
    }
}