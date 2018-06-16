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
    class SalonViewModel : INotifyPropertyChanged, ICommand
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

        private Salon _elemento;

        public Salon Elemento
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

        private SalonViewModel _instancia;

        public SalonViewModel Instancia
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

        private ObservableCollection<Salon> _listaSalones;

        public ObservableCollection<Salon> ListaSalones
        {
            get
            {
                if (_listaSalones != null)
                {
                    return _listaSalones;
                }
                else
                {
                    _listaSalones = new ObservableCollection<Salon>(_db.Salones.ToList());
                    return _listaSalones;
                }
            }
            set
            {
                _listaSalones = value;
                NotificarCambio("ListaSalones");
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
                var registro = new Salon
                {
                    Descripcion = this.Descripcion
                };

                _db.Salones.Add(registro);
                _db.SaveChanges();
                this.ListaSalones.Add(registro);

            }
        }

        public SalonViewModel()
        {
            this.Titulo = "Ventana Salones";
            this.Instancia = this;
        }
    }
}
