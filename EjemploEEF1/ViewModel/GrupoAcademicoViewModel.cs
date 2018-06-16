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
    class GrupoAcademicoViewModel: INotifyPropertyChanged, ICommand
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

        private GrupoAcademico _elemento;

        public GrupoAcademico Elemento
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

        private GrupoAcademicoViewModel _instancia;

        public GrupoAcademicoViewModel Instancia
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

        private ObservableCollection<GrupoAcademico> _listaGruposAcademicos;

        public ObservableCollection<GrupoAcademico> ListaGruposAcademicos
        {
            get
            {
                if (_listaGruposAcademicos != null)
                {
                    return _listaGruposAcademicos;
                }
                else
                {
                    _listaGruposAcademicos = new ObservableCollection<GrupoAcademico>(_db.GruposAcademicos.ToList());
                    return _listaGruposAcademicos;
                }
            }
            set
            {
                _listaGruposAcademicos = value;
                NotificarCambio("ListaGruposAcademicos");
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
                var registro = new GrupoAcademico
                {
                    Descripcion = this.Descripcion
                };

                _db.GruposAcademicos.Add(registro);
                _db.SaveChanges();
                this.ListaGruposAcademicos.Add(registro);

            }
        }

        public GrupoAcademicoViewModel()
        {
            this.Titulo = "Ventana Grupos Academicos";
            this.Instancia = this;
        }
    }
}
