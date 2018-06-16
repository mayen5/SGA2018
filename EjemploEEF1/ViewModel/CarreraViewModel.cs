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
    class CarreraViewModel : INotifyPropertyChanged, ICommand
    {

        private EjemploEFF1DataContext _db = new EjemploEFF1DataContext();

        // Variable
        private IDialogCoordinator _dialogCoordinator;

        private Carrera _elemento;

        public Carrera Elemento
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

        public void NotificarCambio(string propiedad)
        {
            if (PropertyChanged != null)
            {
                //Notificar el cambio a la vista
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }

        private CarreraViewModel _instancia;

        public CarreraViewModel Instancia
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

        private ObservableCollection<Carrera> _listaCarreras;

        public ObservableCollection<Carrera> ListaCarreras
        {
            get
            {
                if (_listaCarreras != null)
                {
                    return _listaCarreras;
                }
                else
                {
                    _listaCarreras = new ObservableCollection<Carrera>(_db.Carreras.ToList());
                    return _listaCarreras;
                }
            }
            set
            {
                _listaCarreras = value;
                NotificarCambio("ListaCarreras");
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
                var registro = new Carrera
                {
                    Descripcion = this.Descripcion
                };

                _db.Carreras.Add(registro);
                _db.SaveChanges();
                this.ListaCarreras.Add(registro);
            }else if(control.Equals("Nuevo")){

            }
        }

        public CarreraViewModel()
        {
            this.Titulo = "Ventana Carreras";
            this.Instancia = this;
        }
    }
}
