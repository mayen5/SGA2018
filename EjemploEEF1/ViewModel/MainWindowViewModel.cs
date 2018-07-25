using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EjemploEEF1.View;

namespace EjemploEEF1.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged, ICommand
    {
        public MainWindowViewModel Instancia { get; set; }

        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            this.Instancia = this;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object objeto)
        {
            if (objeto.Equals("Alumnos"))
            {
                AlumnoView ventana = new AlumnoView();
                ventana.ShowDialog();
            }
            else if (objeto.Equals("Carreras"))
            {
                CarreraView ventana = new CarreraView();
                ventana.ShowDialog();
            }
            else if (objeto.Equals("Salones"))
            {
                SalonView ventana = new SalonView();
                ventana.ShowDialog();
            }
            else if (objeto.Equals("Puestos"))
            {
                PuestoView ventana = new PuestoView();
                ventana.ShowDialog();
            }
            else if (objeto.Equals("Cursos"))
            {
                CursoView ventana = new CursoView();
                ventana.ShowDialog();
            }
            else if (objeto.Equals("GruposAcademicos"))
            {
                GrupoAcademicoView ventana = new GrupoAcademicoView();
                ventana.ShowDialog();
            }
            else if (objeto.Equals("Profesores"))
            {
                ProfesorView ventana = new ProfesorView();
                ventana.ShowDialog();
            }
            else if (objeto.Equals("ProfesoresCursos"))
            {
                ProfesorCursoView ventana = new ProfesorCursoView();
                ventana.ShowDialog();
            }
        }
    }
}
