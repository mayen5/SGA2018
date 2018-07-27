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
    class ClaseAlumnoViewModel : INotifyPropertyChanged, ICommand
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

        private ClaseAlumno _elemento;

        public ClaseAlumno Elemento
        {
            get { return _elemento; }
            set
            {
                _elemento = value;
                if (value != null)
                {
                    this.AlumnoSeleccionado = value.Alumno;
                    this.ClaseSeleccionada = value.Clase;
                    this.FechaAsignacion = value.FechaAsignacion;
                }
                NotificarCambio("Elemento");
            }
        }

        private ClaseAlumnoViewModel _instancia;

        public ClaseAlumnoViewModel Instancia
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

        private ObservableCollection<ClaseAlumno> _listaClasesAlumnos;

        public ObservableCollection<ClaseAlumno> ListaClasesAlumnos
        {
            get
            {
                if (_listaClasesAlumnos != null)
                {
                    return _listaClasesAlumnos;
                }
                else
                {
                    _listaClasesAlumnos = new ObservableCollection<ClaseAlumno>(_db.ClasesAlumnos.ToList());
                    return _listaClasesAlumnos;
                }
            }
            set
            {
                _listaClasesAlumnos = value;
                NotificarCambio("ListaClasesAlumnos");
            }
        }


        private DateTime _fechaAsignacion;

        public DateTime FechaAsignacion
        {
            get { return _fechaAsignacion; }
            set
            {
                _fechaAsignacion = value;
                NotificarCambio("FechaAsignacion");
            }
        }

        //
        private Alumno _alumnoSeleccionado;

        public Alumno AlumnoSeleccionado
        {
            get { return _alumnoSeleccionado; }
            set
            {
                _alumnoSeleccionado = value;
                NotificarCambio("AlumnoSeleccionado");
            }
        }

        private List<Alumno> _listaAlumnos;

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
                NotificarCambio("ListaAlumnos");
            }
        }

        //


        private Clase _claseSeleccionada;

        public Clase ClaseSeleccionada
        {
            get { return _claseSeleccionada; }
            set
            {
                _claseSeleccionada = value;
                NotificarCambio("ClaseSeleccionada");
            }
        }

        private List<Clase> _listaClases;

        public List<Clase> ListaClases
        {
            get
            {
                if (_listaClases != null)
                {
                    return _listaClases;
                }
                else
                {
                    _listaClases = _db.Clases.ToList();
                    return _listaClases;
                }
            }
            set
            {
                _listaClases = value;
                NotificarCambio("ListaClases");
            }
        }

        private bool _isEnabledAlumno = false;

        public bool IsEnabledAlumno
        {
            get { return _isEnabledAlumno; }
            set
            {
                _isEnabledAlumno = value;
                NotificarCambio("IsEnabledAlumno");
            }
        }

        private bool _isEnabledClase = false;

        public bool IsEnabledClase
        {
            get { return _isEnabledClase; }
            set
            {
                _isEnabledClase = value;
                NotificarCambio("IsEnabledClase");
            }
        }


        private bool _isEnabledFechaAsignacion = true;

        public bool IsEnabledFechaAsignacion
        {
            get { return _isEnabledFechaAsignacion; }
            set
            {
                _isEnabledFechaAsignacion = value;
                NotificarCambio("IsEnabledFechaAsignacion");
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
                    "Eliminar ClaseAlumno",
                    "Esta seguro de eliminar el registro?",
                    MessageDialogStyle.AffirmativeAndNegative);
                    if (resultado == MessageDialogResult.Affirmative)
                    {
                        try
                        {
                            _db.ClasesAlumnos.Remove(Elemento);
                            _db.SaveChanges();
                            this.ListaClasesAlumnos.Remove(Elemento);
                            LimpiarCampos();
                        }
                        catch (Exception ex)
                        {

                            await this._dialogCoordinator.ShowMessageAsync(
                            this,
                            "Eliminar ClaseAlumno",
                            ex.Message);
                        }
                    }
                }
                else
                {
                    await this._dialogCoordinator.ShowMessageAsync(
                    this,
                    "Eliminar ClaseAlumno",
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
                            var registro = new ClaseAlumno
                            {
                                Alumno = this.AlumnoSeleccionado,
                                Clase = this.ClaseSeleccionada,
                                FechaAsignacion = this.FechaAsignacion
                            };

                            _db.ClasesAlumnos.Add(registro);
                            _db.SaveChanges();
                            this.ListaClasesAlumnos.Add(registro);
                        }
                        catch (Exception ex)
                        {

                            await this._dialogCoordinator.ShowMessageAsync(
                            this,
                            "Guardar ClasesAlumnos",
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
                            int posicion = ListaClasesAlumnos.IndexOf(Elemento);
                            var registro = _db.ClasesAlumnos.Find(Elemento.AlumnoId);

                            if (registro != null)
                            {
                                registro.Alumno = this.AlumnoSeleccionado;
                                registro.Clase = this.ClaseSeleccionada;
                                registro.FechaAsignacion = this.FechaAsignacion;
                                _db.Entry(registro).State = EntityState.Modified;
                                _db.SaveChanges();
                                ListaClasesAlumnos.RemoveAt(posicion);
                                ListaClasesAlumnos.Insert(posicion, registro);
                            }
                        }
                        catch (Exception ex)
                        {

                            await this._dialogCoordinator.ShowMessageAsync(
                                    this,
                                    "Editar ClaseAlumno",
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
                                    "Editar ClaseAlumno",
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
            this.IsEnabledAlumno = false;
            this.IsEnabledClase = false;
            this.IsEnabledFechaAsignacion = false;
            this.IsEnableGuardar = false;
            this.IsEnableCancelar = false;

        }

        private void ActivarControles()
        {
            this.IsEnableNuevo = false;
            this.IsEnableEliminar = false;
            this.IsEnableEditar = false;
            this.IsEnabledAlumno = true;
            this.IsEnabledClase = true;
            this.IsEnabledFechaAsignacion = true;
            this.IsEnableGuardar = true;
            this.IsEnableCancelar = true;

        }

        private void LimpiarCampos()
        {
            this.AlumnoSeleccionado = null;
            this.ClaseSeleccionada = null;
            this.FechaAsignacion = DateTime.Now;
        }

        public ClaseAlumnoViewModel(IDialogCoordinator dialogCoordinator)
        {
            this.Titulo = "Ventana Clases Alumnos";
            this.Instancia = this;
            this._dialogCoordinator = dialogCoordinator;
        }
    }
}
