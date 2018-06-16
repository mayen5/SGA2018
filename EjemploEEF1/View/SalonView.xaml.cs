using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EjemploEEF1.ViewModel;
using MahApps.Metro.Controls;

namespace EjemploEEF1.View
{
    /// <summary>
    /// Lógica de interacción para SalonView.xaml
    /// </summary>
    public partial class SalonView : MetroWindow
    {
        public SalonView()
        {
            InitializeComponent();
            SalonViewModel modelo = new SalonViewModel();
            this.DataContext = modelo;
        }
    }
}
