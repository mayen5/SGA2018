using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using EjemploEEF1.Model;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace EjemploEEF1.ViewModel
{
    //InotifyPropertyChanged: Cualquier cambio que haga en el modelo se ve reflejado en la vista.
    public class AlumnoViewModel : INotifyPropertyChanged, ICommand
    {
        private EjemploEFF1DataContext _db = new EjemploEFF1DataContext();
        private ObservableCollection<Alumno> _listaAlumnos;

        private string _carne;
        public string Carne
        {
            get { return _carne; }
            set
            {
                _carne = value;
                NotificarCambio("Carne");
            }
        }

        private string _nombres;

        public string Nombres
        {
            get { return _nombres; }
            set
            {
                _nombres = value;
                NotificarCambio("Nombres");
            }
        }

        private string _apellidos;

        public string Apellidos
        {
            get { return _apellidos; }
            set
            {
                _apellidos = value;
                NotificarCambio("Apellidos");
            }
        }

        private DateTime _fechaNacimiento;

        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set
            {
                _fechaNacimiento = value;
                NotificarCambio("FechaNacimiento");
            }
        }

        private Carrera _carreraSeleccionada;

        public Carrera CarreraSeleccionada
        {
            get { return _carreraSeleccionada; }
            set
            {
                _carreraSeleccionada = value;
                NotificarCambio("CarreraSeleccionada");
            }
        }

        private List<Carrera> _listaCarreras;

        public List<Carrera> ListaCarreras
        {
            get
            {
                if (_listaCarreras != null)
                {
                    return _listaCarreras;
                }
                else
                {
                    _listaCarreras = _db.Carreras.ToList();
                    return _listaCarreras;
                }
            }
            set
            {
                _listaCarreras = value;
                NotificarCambio("ListaCarreras");
            }
        }


        private string _titulo;

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        public ObservableCollection<Alumno> ListaAlumnos
        {
            get
            {
                if (_listaAlumnos != null)
                {
                    return _listaAlumnos;
                }
                else
                {
                    _listaAlumnos = new ObservableCollection<Alumno>(_db.Alumnos.ToList());
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

        private AlumnoViewModel _instancia;

        public AlumnoViewModel Instancia
        {
            get { return _instancia; }
            set
            {
                _instancia = value;
                NotificarCambio("Instancia");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;

        public void NotificarCambio(string propiedad)
        {
            if (PropertyChanged != null)
            {
                //Notificar el cambio a la vista
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object control)
        {
            if (control.Equals("Guardar"))
            {
                /*Alumno nuevo = new Alumno();
                nuevo.Carne = this.Carne;
                nuevo.Apellidos = this.Apellidos;
                nuevo.Nombres = this.Nombres;
                nuevo.FechaNacimiento = this.FechaNacimiento;
                nuevo.Carrera = this.CarreraSeleccionada;*/

                var registro = new Alumno
                {
                    Carne = this.Carne,
                    Apellidos = this.Apellidos,
                    Nombres = this.Nombres,
                    FechaNacimiento = this.FechaNacimiento,
                    Carrera = this.CarreraSeleccionada
                };

                //_db.Alumnos.Add(nuevo);
                _db.Alumnos.Add(registro);
                _db.SaveChanges();
                this.ListaAlumnos.Add(registro);
                
            }
        }

        public AlumnoViewModel()
        {
            this.Titulo = "Ventana Alumos";
            this.FechaNacimiento = DateTime.Now;
            this.Instancia = this;
        }
    }
}
