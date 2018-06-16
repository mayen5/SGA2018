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
    class PuestoViewModel : INotifyPropertyChanged, ICommand
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

        private Puesto _elemento;

        public Puesto Elemento
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

        private PuestoViewModel _instancia;

        public PuestoViewModel Instancia
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

        private ObservableCollection<Puesto> _listaPuestos;

        public ObservableCollection<Puesto> ListaPuestos
        {
            get
            {
                if (_listaPuestos != null)
                {
                    return _listaPuestos;
                }
                else
                {
                    _listaPuestos = new ObservableCollection<Puesto>(_db.Puestos.ToList());
                    return _listaPuestos;
                }
            }
            set
            {
                _listaPuestos = value;
                NotificarCambio("ListaPuestos");
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
                var registro = new Puesto
                {
                    Descripcion = this.Descripcion
                };

                _db.Puestos.Add(registro);
                _db.SaveChanges();
                this.ListaPuestos.Add(registro);
            }
            else if (control.Equals("Nuevo"))
            {

            }
        }

        public PuestoViewModel()
        {
            this.Titulo = "Ventana Puestos";
            this.Instancia = this;
        }
    }
}
