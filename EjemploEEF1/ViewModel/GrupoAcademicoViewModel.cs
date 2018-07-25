using EjemploEEF1.Model;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
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

        private ACCION _accion = ACCION.NINGUNO;

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


        private bool _isReadOnlyDescripcion = true;

        public bool IsReadOnlyDescripcion
        {
            get { return _isReadOnlyDescripcion; }
            set
            {
                _isReadOnlyDescripcion = value;
                NotificarCambio("IsReadOnlyDescripcion");
            }
        }

        private bool _isEnableGuardar = false;

        public bool IsEnableGuardar
        {
            get { return _isEnableGuardar; }
            set
            {
                _isEnableGuardar = value;
                NotificarCambio("IsEnableGuardar");
            }
        }

        private bool _isEnableCancelar = false;

        public bool IsEnableCancelar
        {
            get { return _isEnableCancelar; }
            set
            {
                _isEnableCancelar = value;
                NotificarCambio("IsEnableCancelar");
            }
        }

        private bool _isEnableNuevo = true;

        public bool IsEnableNuevo
        {
            get { return _isEnableNuevo; }
            set
            {
                _isEnableNuevo = value;
                NotificarCambio("IsEnableNuevo");
            }
        }

        private bool _isEnableEliminar = true;

        public bool IsEnableEliminar
        {
            get { return _isEnableEliminar; }
            set
            {
                _isEnableEliminar = value;
                NotificarCambio("IsEnableEliminar");
            }
        }

        private bool _isEnableEditar = true;

        public bool IsEnableEditar
        {
            get { return _isEnableEditar; }
            set
            {
                _isEnableEditar = value;
                NotificarCambio("IsEnableEditar");
            }
        }

        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object control)
        {
            if (control.Equals("Nuevo"))
            {
                LimpiarCampos();
                ActivarControles();
                this._accion = ACCION.NUEVO;


            }
            else if (control.Equals("Eliminar"))
            {
                if (Elemento != null)
                {
                    MessageDialogResult resultado = await this._dialogCoordinator.ShowMessageAsync(
                    this,
                    "Eliminar Grupo Academico",
                    "Esta seguro de eliminar el registro?",
                    MessageDialogStyle.AffirmativeAndNegative);
                    if (resultado == MessageDialogResult.Affirmative)
                    {
                        try
                        {
                            _db.GruposAcademicos.Remove(Elemento);
                            _db.SaveChanges();
                            this.ListaGruposAcademicos.Remove(Elemento);
                            LimpiarCampos();
                        }
                        catch (Exception ex)
                        {

                            await this._dialogCoordinator.ShowMessageAsync(
                            this,
                            "Eliminar Grupo Academico",
                            ex.Message);
                        }
                    }
                }
                else
                {
                    await this._dialogCoordinator.ShowMessageAsync(
                    this,
                    "Eliminar Grupo Academico",
                    "Debe seleccionar un elemento");
                }
            }
            else if (control.Equals("Guardar"))
            {
                switch (this._accion)
                {
                    case ACCION.NINGUNO:
                        break;
                    case ACCION.NUEVO:
                        try
                        {
                            var registro = new GrupoAcademico
                            {
                                Descripcion = this.Descripcion
                            };

                            _db.GruposAcademicos.Add(registro);
                            _db.SaveChanges();
                            this.ListaGruposAcademicos.Add(registro);
                        }
                        catch (Exception ex)
                        {

                            await this._dialogCoordinator.ShowMessageAsync(
                            this,
                            "Guardar Grupo Academico",
                            ex.Message);
                        }
                        finally
                        {
                            DesactivarControles();
                            this._accion = ACCION.NINGUNO;
                        }
                        break;
                    case ACCION.GUARDAR:
                        try
                        {
                            int posicion = ListaGruposAcademicos.IndexOf(Elemento);
                            var registro = _db.GruposAcademicos.Find(Elemento.GrupoAcademicoId);

                            if (registro != null)
                            {
                                registro.Descripcion = this.Descripcion;
                                _db.Entry(registro).State = EntityState.Modified;
                                _db.SaveChanges();
                                ListaGruposAcademicos.RemoveAt(posicion);
                                ListaGruposAcademicos.Insert(posicion, registro);
                            }
                        }
                        catch (Exception ex)
                        {

                            await this._dialogCoordinator.ShowMessageAsync(
                                    this,
                                    "Editar Grupo Academico",
                                    ex.Message);
                        }
                        finally
                        {
                            DesactivarControles();
                            this._accion = ACCION.NINGUNO;
                        }
                        break;
                    default:
                        break;
                }

            }
            else if (control.Equals("Editar"))
            {
                if (Elemento != null)
                {
                    ActivarControles();
                    this._accion = ACCION.GUARDAR;
                }
                else
                {
                    await this._dialogCoordinator.ShowMessageAsync(
                                    this,
                                    "Editar Grupo Academico",
                                    "Debe seleccionar un elemento");
                }
            }
            else if (control.Equals("Cancelar"))
            {
                DesactivarControles();
                this._accion = ACCION.NINGUNO;
            }
        }

        private void DesactivarControles()
        {
            this.IsEnableNuevo = true;
            this.IsEnableEliminar = true;
            this.IsEnableEditar = true;
            this.IsReadOnlyDescripcion = true;
            this.IsEnableGuardar = false;
            this.IsEnableCancelar = false;

        }

        private void ActivarControles()
        {
            this.IsEnableNuevo = false;
            this.IsEnableEliminar = false;
            this.IsEnableEditar = false;
            this.IsReadOnlyDescripcion = false;
            this.IsEnableGuardar = true;
            this.IsEnableCancelar = true;

        }

        private void LimpiarCampos()
        {
            this.Descripcion = string.Empty;
        }

        public GrupoAcademicoViewModel(IDialogCoordinator dialogCoordinator)
        {
            this.Titulo = "Ventana Grupos Academicos";
            this.Instancia = this;
            this._dialogCoordinator = dialogCoordinator;
        }
    }
}
