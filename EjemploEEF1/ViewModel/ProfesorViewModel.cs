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
    public class ProfesorViewModel : INotifyPropertyChanged, ICommand
    {
        private EjemploEFF1DataContext _db = new EjemploEFF1DataContext();
        private ObservableCollection<Profesor> _listaProfesores;
        // Variable
        private IDialogCoordinator _dialogCoordinator;

        private ACCION _accion = ACCION.NINGUNO;

        private Profesor _elemento;

        public Profesor Elemento
        {
            get { return _elemento; }
            set
            {
                _elemento = value;
                if (value != null)
                {
                    this.Apellidos = value.Apellidos;
                    this.Nombres = value.Nombres;
                    this.FechaNacimiento = value.FechaNacimiento;
                    this.NumeroCursos = value.NumeroCursos;
                    this.PuestoSeleccionado = value.Puesto;
                }
                NotificarCambio("Elemento");
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

        private int _numeroCursos;
        public int NumeroCursos
        {
            get { return _numeroCursos; }
            set
            {
                _numeroCursos = value;
                NotificarCambio("NumeroCursos");
            }
        }


        private Puesto _puestoSeleccionado;

        public Puesto PuestoSeleccionado
        {
            get { return _puestoSeleccionado; }
            set
            {
                _puestoSeleccionado = value;
                NotificarCambio("PuestoSeleccionado");
            }
        }

        private List<Puesto> _listaPuestos;

        public List<Puesto> ListaPuestos
        {
            get
            {
                if (_listaPuestos != null)
                {
                    return _listaPuestos;
                }
                else
                {
                    _listaPuestos = _db.Puestos.ToList();
                    return _listaPuestos;
                }
            }
            set
            {
                _listaPuestos = value;
                NotificarCambio("ListaPuestos");
            }
        }

        private string _titulo;

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        public ObservableCollection<Profesor> ListaProfesores
        {
            get
            {
                if (_listaProfesores != null)
                {
                    return _listaProfesores;
                }
                else
                {
                    _listaProfesores = new ObservableCollection<Profesor>(_db.Profesores.ToList());
                    return _listaProfesores;
                }
            }

            set
            {
                _listaProfesores = value;

                //Notifica el cambio de la propiedad
                NotificarCambio("ListaProfesores");
            }
        }

        private ProfesorViewModel _instancia;

        public ProfesorViewModel Instancia
        {
            get { return _instancia; }
            set
            {
                _instancia = value;
                NotificarCambio("Instancia");
            }
        }


        private bool _isReadOnlyApellidos = true;

        public bool IsReadOnlyApellidos
        {
            get { return _isReadOnlyApellidos; }
            set
            {
                _isReadOnlyApellidos = value;
                NotificarCambio("IsReadOnlyApellidos");
            }
        }

        private bool _isReadOnlyNombres = true;

        public bool IsReadOnlyNombres
        {
            get { return _isReadOnlyNombres; }
            set
            {
                _isReadOnlyNombres = value;
                NotificarCambio("IsReadOnlyNombres");
            }
        }

        private bool _IsEnabledFechaNacimiento = false;

        public bool IsEnabledFechaNacimiento
        {
            get { return _IsEnabledFechaNacimiento; }
            set
            {
                _IsEnabledFechaNacimiento = value;
                NotificarCambio("IsEnabledFechaNacimiento");
            }
        }

        private bool _isReadOnlyNumeroCursos = true;

        public bool IsReadOnlyNumeroCursos
        {
            get { return _isReadOnlyNumeroCursos; }
            set
            {
                _isReadOnlyNumeroCursos = value;
                NotificarCambio("IsReadOnlyNumeroCursos");
            }
        }

        private bool _IsEnabledPuesto = false;

        public bool IsEnabledPuesto
        {
            get { return _IsEnabledPuesto; }
            set
            {
                _IsEnabledPuesto = value;
                NotificarCambio("IsEnabledPuesto");
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
                    "Eliminar Profesor",
                    "Esta seguro de eliminar el registro?",
                    MessageDialogStyle.AffirmativeAndNegative);
                    if (resultado == MessageDialogResult.Affirmative)
                    {
                        try
                        {
                            _db.Profesores.Remove(Elemento);
                            _db.SaveChanges();
                            this.ListaProfesores.Remove(Elemento);
                            LimpiarCampos();
                        }
                        catch (Exception ex)
                        {

                            await this._dialogCoordinator.ShowMessageAsync(
                            this,
                            "Eliminar Profesor",
                            ex.Message);
                        }
                    }
                }
                else
                {
                    await this._dialogCoordinator.ShowMessageAsync(
                    this,
                    "Eliminar Profesor",
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
                            var registro = new Profesor
                            {

                                Apellidos = this.Apellidos,
                                Nombres = this.Nombres,
                                FechaNacimiento = this.FechaNacimiento,
                                NumeroCursos = this.NumeroCursos,
                                Puesto = this.PuestoSeleccionado
                            };

                            _db.Profesores.Add(registro);
                            _db.SaveChanges();
                            this.ListaProfesores.Add(registro);
                        }
                        catch (Exception ex)
                        {

                            await this._dialogCoordinator.ShowMessageAsync(
                            this,
                            "Guardar Profesor",
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
                            int posicion = ListaProfesores.IndexOf(Elemento);
                            var registro = _db.Profesores.Find(Elemento.ProfesorId);

                            if (registro != null)
                            {
                                registro.Apellidos = this.Apellidos;
                                registro.Nombres = this.Nombres;
                                registro.FechaNacimiento = this.FechaNacimiento;
                                registro.NumeroCursos = this.NumeroCursos;
                                registro.Puesto = this.PuestoSeleccionado;
                                _db.Entry(registro).State = EntityState.Modified;
                                _db.SaveChanges();
                                ListaProfesores.RemoveAt(posicion);
                                ListaProfesores.Insert(posicion, registro);
                            }
                        }
                        catch (Exception ex)
                        {

                            await this._dialogCoordinator.ShowMessageAsync(
                                    this,
                                    "Editar Profesor",
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
                                    "Editar Profesor",
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
            this.IsReadOnlyNombres = true;
            this.IsReadOnlyApellidos = true;
            this.IsEnabledFechaNacimiento = false;
            this.IsEnabledPuesto = false;
            this.IsEnableGuardar = false;
            this.IsEnableCancelar = false;

        }

        private void ActivarControles()
        {
            this.IsEnableNuevo = false;
            this.IsEnableEliminar = false;
            this.IsEnableEditar = false;
            this.IsReadOnlyNumeroCursos = false;
            this.IsReadOnlyNombres = false;
            this.IsReadOnlyApellidos = false;
            this.IsEnabledFechaNacimiento = true;
            this.IsEnabledPuesto = true;
            this.IsEnableGuardar = true;
            this.IsEnableCancelar = true;

        }

        private void LimpiarCampos()
        {
            this.Apellidos = string.Empty;
            this.Nombres = string.Empty;
            this.FechaNacimiento = DateTime.Now;
            this.NumeroCursos = 0;
            this.PuestoSeleccionado = null;
        }

        public ProfesorViewModel(IDialogCoordinator dialogCoordinator)
        {
            this.Titulo = "Ventana Profesores";
            this.FechaNacimiento = DateTime.Now;
            this.Instancia = this;
            this._dialogCoordinator = dialogCoordinator;
        }

    }
}
