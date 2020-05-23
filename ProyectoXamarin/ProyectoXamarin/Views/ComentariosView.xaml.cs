using ProyectoXamarin.Models;
using ProyectoXamarin.Repositories;
using ProyectoXamarin.ViewModels;
using Syncfusion.XForms.Accordion;
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
    public partial class ComentariosView : ContentPage
    {
        public ComentariosView()
        {
            InitializeComponent();
        }
    }
}