using ProyectoXamarin.Models;
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
    public partial class DetallesProductoView : ContentPage
    {
        public DetallesProductoView(Productos prod)
        {
            InitializeComponent();
            ObservableCollection<Productos> productos = new ObservableCollection<Productos>();
            productos.Add(prod);
            lsvProducto.ItemsSource = productos;
        }
    }
}