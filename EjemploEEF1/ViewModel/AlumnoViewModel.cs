using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using EjemploEEF1.Model;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MahApps.Metro.Controls.Dialogs;
using System.Data.Entity;

namespace EjemploEEF1.ViewModel
{

    enum ACCION
    {
        NINGUNO,
        NUEVO,
        GUARDAR
    }

    //InotifyPropertyChanged: Cualquier cambio que haga en el modelo se ve reflejado en la vista.
    public class AlumnoViewModel : INotifyPropertyChanged, ICommand
    {
        private EjemploEFF1DataContext _db = new EjemploEFF1DataContext();
        private ObservableCollection<Alumno> _listaAlumnos;
        // Variable
        private IDialogCoordinator _dialogCoordinator;

        private ACCION _accion = ACCION.NINGUNO;

        private Alumno _elemento;

        public Alumno Elemento
        {
            get { return _elemento; }
            set
            {
                _elemento = value;
                if (value != null)
                {
                    this.Carne = value.Carne;
                    this.Apellidos = value.Apellidos;
                    this.Nombres = value.Nombres;
                    this.FechaNacimiento = value.FechaNacimiento;
                    this.CarreraSeleccionada = value.Carrera;
                }
                NotificarCambio("Elemento");
            }
        }

        private bool _isReadOnlyCarne = true;

        public bool IsReadOnlyCarne
        {
            get { return _isReadOnlyCarne; }
            set
            {
                _isReadOnlyCarne = value;
                NotificarCambio("IsReadOnlyCarne");
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

        private bool _IsEnabledCarrera = false;

        public bool IsEnabledCarrera
        {
            get { return _IsEnabledCarrera; }
            set
            {
                _IsEnabledCarrera = value;
                NotificarCambio("IsEnabledCarrera");
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
                    "Eliminar Alumno",
                    "Esta seguro de eliminar el registro?",
                    MessageDialogStyle.AffirmativeAndNegative);
                    if (resultado == MessageDialogResult.Affirmative)
                    {
                        try
                        {
                            _db.Alumnos.Remove(Elemento);
                            _db.SaveChanges();
                            this.ListaAlumnos.Remove(Elemento);
                            LimpiarCampos();
                        }
                        catch (Exception ex)
                        {

                            await this._dialogCoordinator.ShowMessageAsync(
                            this,
                            "Eliminar Alumno",
                            ex.Message);
                        }
                    }
                }
                else
                {
                    await this._dialogCoordinator.ShowMessageAsync(
                    this,
                    "Eliminar Alumno",
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
                            var registro = new Alumno
                            {
                                Carne = this.Carne,
                                Apellidos = this.Apellidos,
                                Nombres = this.Nombres,
                                FechaNacimiento = this.FechaNacimiento,
                                Carrera = this.CarreraSeleccionada
                            };

                            _db.Alumnos.Add(registro);
                            _db.SaveChanges();
                            this.ListaAlumnos.Add(registro);
                        }
                        catch (Exception ex)
                        {

                            await this._dialogCoordinator.ShowMessageAsync(
                            this,
                            "Guardar Alumno",
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
                            int posicion = ListaAlumnos.IndexOf(Elemento);
                            var registro = _db.Alumnos.Find(Elemento.AlumnoId);

                            if (registro != null)
                            {
                                registro.Apellidos = this.Apellidos;
                                registro.Nombres = this.Nombres;
                                registro.FechaNacimiento = this.FechaNacimiento;
                                registro.Carrera = this.CarreraSeleccionada;
                                _db.Entry(registro).State = EntityState.Modified;
                                _db.SaveChanges();
                                ListaAlumnos.RemoveAt(posicion);
                                ListaAlumnos.Insert(posicion, registro);
                            }
                        }
                        catch (Exception ex)
                        {

                            await this._dialogCoordinator.ShowMessageAsync(
                                    this,
                                    "Editar Alumno",
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
                    this.IsReadOnlyCarne = true;
                    this._accion = ACCION.GUARDAR;
                }
                else
                {
                    await this._dialogCoordinator.ShowMessageAsync(
                                    this,
                                    "Editar Alumno",
                                    "Debe seleccionar un elemento");
                }
            }
        }

        private void DesactivarControles()
        {
            this.IsEnableNuevo = true;
            this.IsEnableEliminar = true;
            this.IsEnableEditar = true;
            this.IsReadOnlyCarne = true;
            this.IsReadOnlyNombres = true;
            this.IsReadOnlyApellidos = true;
            this.IsEnabledFechaNacimiento = false;
            this.IsEnabledCarrera = false;
            this.IsEnableGuardar = false;
            this.IsEnableCancelar = false;
            
        }

        private void ActivarControles()
        {
            this.IsEnableNuevo = false;
            this.IsEnableEliminar = false;
            this.IsEnableEditar = false;
            this.IsReadOnlyCarne = false;
            this.IsReadOnlyNombres = false;
            this.IsReadOnlyApellidos = false;
            this.IsEnabledFechaNacimiento = true;
            this.IsEnabledCarrera = true;
            this.IsEnableGuardar = true;
            this.IsEnableCancelar = true;
            
        }

        private void LimpiarCampos()
        {
            this.Carne = string.Empty;
            this.Apellidos = string.Empty;
            this.Nombres = string.Empty;
            this.FechaNacimiento = DateTime.Now;
            this.CarreraSeleccionada = null;
        }

        public AlumnoViewModel(IDialogCoordinator dialogCoordinator)
        {
            this.Titulo = "Ventana Alumnos";
            this.FechaNacimiento = DateTime.Now;
            this.Instancia = this;
            this._dialogCoordinator = dialogCoordinator;
        }
    }
}
