using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using EjemploEEF1.Model;

namespace EjemploEEF1.ViewModel
{
    //InotifyPropertyChanged: Cualquier cambio que haga en el modelo se ve reflejado en la vista.
    public class AlumnoViewModel : INotifyPropertyChanged
    {
        private EjemploEFF1DataContext _db = new EjemploEFF1DataContext();
        private List<Alumno> _listaAlumnos;

        private string _titulo;

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        public List<Alumno> ListaAlumnos
        {
            get
            {
                if (_listaAlumnos != null)
                {
                    return _listaAlumnos;
                }
                else
                {
                    _listaAlumnos = _db.Alumnos.ToList();
                    return _listaAlumnos;
                }                
            }

            set
            {
                _listaAlumnos = value;

                //Notifica el cambio de la propiedad
                NotificarCambio("ListaAlumnos");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void NotificarCambio(string propiedad)
        {
            if (PropertyChanged != null)
            {
                //Notificar el cambio a la vista
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }

        public AlumnoViewModel()
        {
            this.Titulo = "Ventana Alumos";
        }
    }
}
