using EjemploEEF1.Model;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EjemploEEF1.ViewModel
{
    class CursoViewModel : INotifyPropertyChanged, ICommand
    {
        private EjemploEFF1DataContext _db = new EjemploEFF1DataContext();

        public void NotificarCambio(string propiedad)
        {
            if (PropertyChanged != null)
            {
                //Notificar el cambio a la vista
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }

        // Variable
        private IDialogCoordinator _dialogCoordinator;

        private Curso _elemento;

        public Curso Elemento
        {
            get { return _elemento; }
            set
            {
                _elemento = value;
                if (value != null)
                {
                    this.Descripcion = value.Descripcion;
                }
                NotificarCambio("Elemento");
            }
        }

        private CursoViewModel _instancia;

        public CursoViewModel Instancia
        {
            get { return _instancia; }
            set
            {
                _instancia = value;
                NotificarCambio("Instancia");
            }
        }

        private string _titulo;

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        private ObservableCollection<Curso> _listaCursos;

        public ObservableCollection<Curso> ListaCursos
        {
            get
            {
                if (_listaCursos != null)
                {
                    return _listaCursos;
                }
                else
                {
                    _listaCursos = new ObservableCollection<Curso>(_db.Cursos.ToList());
                    return _listaCursos;
                }
            }
            set
            {
                _listaCursos = value;
                NotificarCambio("ListaCursos");
            }
        }


        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set
            {
                _descripcion = value;
                NotificarCambio("Descripcion");
            }
        }



        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object control)
        {
            if (control.Equals("Guardar"))
            {
                var registro = new Curso
                {
                    Descripcion = this.Descripcion
                };

                _db.Cursos.Add(registro);
                _db.SaveChanges();
                this.ListaCursos.Add(registro);
            }
            else if (control.Equals("Nuevo"))
            {

            }
        }

        public CursoViewModel()
        {
            this.Titulo = "Ventana Cursos";
            this.Instancia = this;
        }
    }
}
