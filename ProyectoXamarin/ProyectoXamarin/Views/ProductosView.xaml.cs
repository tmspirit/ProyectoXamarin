﻿using ProyectoXamarin.Models;
using ProyectoXamarin.Repositories;
using ProyectoXamarin.ViewModels;
using Syncfusion.SfCarousel.XForms;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductosView : ContentPage
    {
        RepositoryMotores repo;
        public ProductosView()
        {
            InitializeComponent();
            CarouselViewModel carouselViewModel = App.Locator.CarouselViewModel;
            this.repo = new RepositoryMotores();
            SfCarousel carousel = new SfCarousel()
            {
                HeightRequest = 600,
                WidthRequest = 800,
                SelectedIndex = 2
            };

            StackLayout stackPrincipal = new StackLayout();

            Label titulo = new Label
            {
                Text = "Articulos Disponibles:",
                TextColor = Color.CadetBlue,
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

                Label motorId = new Label();
                motorId.SetBinding(Label.TextProperty, "MotorId");
                motorId.IsVisible = false;

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
                imagen.Clicked += Imagen_Clicked;
                imagen.BackgroundColor = Color.Transparent;

                stack.Children.Add(motorId);
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

        private async void Imagen_Clicked(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            StackLayout stack = (StackLayout)button.Parent;
            Label idLabel = (Label)stack.Children[0];
            int motorId = int.Parse(idLabel.Text);
            DetallesProductoView view = new DetallesProductoView(motorId);
            DetallesProductoViewModel viewmodel = new DetallesProductoViewModel();
            viewmodel.Producto = await GetProductoAsync(motorId);
            view.BindingContext = viewmodel;
            //App.Locator.MainMotoresView.Detail = new NavigationPage((Page)Activator.CreateInstance());
            await Navigation.PushModalAsync(view);
        }

        public async Task<Productos> GetProductoAsync(int motorId)
        {
            Productos produ = await repo.GetProducto(motorId);
            return produ;
        }
    }
}