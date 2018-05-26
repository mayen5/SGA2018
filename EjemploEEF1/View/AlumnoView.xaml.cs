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

namespace EjemploEEF1.View
{
    /// <summary>
    /// Lógica de interacción para AlumnoView.xaml
    /// </summary>
    public partial class AlumnoView : Window
    {
        public AlumnoView()
        {
            InitializeComponent();
            AlumnoViewModel modelo = new AlumnoViewModel();
            this.DataContext = modelo;
        }
    }
}
