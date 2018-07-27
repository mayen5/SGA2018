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
    class ClaseViewModel : INotifyPropertyChanged, ICommand
    {
        private EjemploEFF1DataContext _db = new EjemploEFF1DataContext();
        private ObservableCollection<Clase> _listaClases;
        // Variable
        private IDialogCoordinator _dialogCoordinator;

        private ACCION _accion = ACCION.NINGUNO;

        private Clase _elemento;

        public Clase Elemento
        {
            get { return _elemento; }
            set
            {
                _elemento = value;
                if (value != null)
                {
                    this.Nombre = value.Nombre;
                    this.FechaCreacion = value.FechaCreacion;
                    this.HoraInicio = value.HoraInicio;
                    this.HoraFin = value.HoraFin;
                    this.FechaInicio = value.FechaInicio;
                    this.FechaFinal = value.FechaFinal;
                    this.SalonSeleccionado = value.Salon;
                    this.GrupoAcademicoSeleccionado = value.GrupoAcademico;
                    this.ProfesorSeleccionado = value.Profesor;
                    this.CursoSeleccionado = value.Curso;
                }
                NotificarCambio("Elemento");
            }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                NotificarCambio("Nombre");
            }
        }


        private DateTime _fechaCreacion;

        public DateTime FechaCreacion
        {
            get { return _fechaCreacion; }
            set
            {
                _fechaCreacion = value;
                NotificarCambio("FechaCreacion");
            }
        }

        private TimeSpan _horaInicio;
        public TimeSpan HoraInicio
        {
            get { return _horaInicio; }
            set
            {
                _horaInicio = value;
                NotificarCambio("HoraInicio");
            }
        }

        private TimeSpan _horaFin;
        public TimeSpan HoraFin
        {
            get { return _horaFin; }
            set
            {
                _horaFin = value;
                NotificarCambio("HoraFin");
            }
        }

        private DateTime _fechaInicio;

        public DateTime FechaInicio
        {
            get { return _fechaInicio; }
            set
            {
                _fechaInicio = value;
                NotificarCambio("FechaInicio");
            }
        }

        private DateTime _fechaFinal;

        public DateTime FechaFinal
        {
            get { return _fechaFinal; }
            set
            {
                _fechaFinal = value;
                NotificarCambio("FechaFinal");
            }
        }


        private Salon _salonSeleccionado;

        public Salon SalonSeleccionado
        {
            get { return _salonSeleccionado; }
            set
            {
                _salonSeleccionado = value;
                NotificarCambio("SalonSeleccionado");
            }
        }

        private List<Salon> _listaSalones;

        public List<Salon> ListaSalones
        {
            get
            {
                if (_listaSalones != null)
                {
                    return _listaSalones;
                }
                else
                {
                    _listaSalones = _db.Salones.ToList();
                    return _listaSalones;
                }
            }
            set
            {
                _listaSalones = value;
                NotificarCambio("ListaSalones");
            }
        }

        private GrupoAcademico _grupoAcademicoSeleccionado;

        public GrupoAcademico GrupoAcademicoSeleccionado
        {
            get { return _grupoAcademicoSeleccionado; }
            set
            {
                _grupoAcademicoSeleccionado = value;
                NotificarCambio("GrupoAcademicoSeleccionado");
            }
        }

        private List<GrupoAcademico> _listaGruposAcademicos;

        public List<GrupoAcademico> ListaGruposAcademicos
        {
            get
            {
                if (_listaGruposAcademicos != null)
                {
                    return _listaGruposAcademicos;
                }
                else
                {
                    _listaGruposAcademicos = _db.GruposAcademicos.ToList();
                    return _listaGruposAcademicos;
                }
            }
            set
            {
                _listaGruposAcademicos = value;
                NotificarCambio("ListaGruposAcademicos");
            }
        }

        private Profesor _profesorSeleccionado;

        public Profesor ProfesorSeleccionado
        {
            get { return _profesorSeleccionado; }
            set
            {
                _profesorSeleccionado = value;
                NotificarCambio("ProfesorSeleccionado");
            }
        }

        private List<Profesor> _listaProfesores;

        public List<Profesor> ListaProfesores
        {
            get
            {
                if (_listaProfesores != null)
                {
                    return _listaProfesores;
                }
                else
                {
                    _listaProfesores = _db.Profesores.ToList();
                    return _listaProfesores;
                }
            }
            set
            {
                _listaProfesores = value;
                NotificarCambio("ListaProfesores");
            }
        }

        private Curso _cursoSeleccionado;

        public Curso CursoSeleccionado
        {
            get { return _cursoSeleccionado; }
            set
            {
                _cursoSeleccionado = value;
                NotificarCambio("CursoSeleccionado");
            }
        }

        private List<Curso> _listaCursos;

        public List<Curso> ListaCursos
        {
            get
            {
                if (_listaCursos != null)
                {
                    return _listaCursos;
                }
                else
                {
                    _listaCursos = _db.Cursos.ToList();
                    return _listaCursos;
                }
            }
            set
            {
                _listaCursos = value;
                NotificarCambio("ListaCursos");
            }
        }

        private string _titulo;

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        public ObservableCollection<Clase> ListaClases
        {
            get
            {
                if (_listaClases != null)
                {
                    return _listaClases;
                }
                else
                {
                    _listaClases = new ObservableCollection<Clase>(_db.Clases.ToList());
                    return _listaClases;
                }
            }

            set
            {
                _listaClases = value;

                //Notifica el cambio de la propiedad
                NotificarCambio("ListaClases");
            }
        }

        private ClaseViewModel _instancia;

        public ClaseViewModel Instancia
        {
            get { return _instancia; }
            set
            {
                _instancia = value;
                NotificarCambio("Instancia");
            }
        }


        private bool _isReadOnlyNombre = true;

        public bool IsReadOnlyNombre
        {
            get { return _isReadOnlyNombre; }
            set
            {
                _isReadOnlyNombre = value;
                NotificarCambio("IsReadOnlyNombre");
            }
        }

        private bool _IsEnabledFechaCreacion = false;

        public bool IsEnabledFechaCreacion
        {
            get { return _IsEnabledFechaCreacion; }
            set
            {
                _IsEnabledFechaCreacion = value;
                NotificarCambio("IsEnabledFechaCreacion");
            }
        }

        private bool _isReadOnlyHoraInicio = true;

        public bool IsReadOnlyHoraInicio
        {
            get { return _isReadOnlyHoraInicio; }
            set
            {
                _isReadOnlyHoraInicio = value;
                NotificarCambio("IsReadOnlyHoraInicio");
            }
        }

        private bool _isReadOnlyHoraFin = false;

        public bool IsReadOnlyHoraFin
        {
            get { return _isReadOnlyHoraFin; }
            set
            {
                _isReadOnlyHoraFin = value;
                NotificarCambio("IsReadOnlyHoraFin");
            }
        }

        private bool _IsEnabledFechaInicio = false;

        public bool IsEnabledFechaInicio
        {
            get { return _IsEnabledFechaInicio; }
            set
            {
                _IsEnabledFechaInicio = value;
                NotificarCambio("IsEnabledFechaInicio");
            }
        }

        private bool _IsEnabledFechaFinal = false;

        public bool IsEnabledFechaFinal
        {
            get { return _IsEnabledFechaFinal; }
            set
            {
                _IsEnabledFechaFinal = value;
                NotificarCambio("IsEnabledFechaFinal");
            }
        }

        private bool _IsEnabledSalonSeleccionado = false;

        public bool IsEnabledSalonSeleccionado
        {
            get { return _IsEnabledSalonSeleccionado; }
            set
            {
                _IsEnabledSalonSeleccionado = value;
                NotificarCambio("IsEnabledSalonSeleccionado");
            }
        }

        private bool _IsEnabledGrupoAcademicoSeleccionado = false;

        public bool IsEnabledGrupoAcademicoSeleccionado
        {
            get { return _IsEnabledGrupoAcademicoSeleccionado; }
            set
            {
                _IsEnabledGrupoAcademicoSeleccionado = value;
                NotificarCambio("IsEnabledGrupoAcademicoSeleccionado");
            }
        }

        private bool _IsEnabledProfesorSeleccionado = false;

        public bool IsEnabledProfesorSeleccionado
        {
            get { return _IsEnabledProfesorSeleccionado; }
            set
            {
                _IsEnabledProfesorSeleccionado = value;
                NotificarCambio("IsEnabledProfesorSeleccionado");
            }
        }

        private bool _IsEnabledCursoSeleccionado = false;

        public bool IsEnabledCursoSeleccionado
        {
            get { return _IsEnabledCursoSeleccionado; }
            set
            {
                _IsEnabledCursoSeleccionado = value;
                NotificarCambio("IsEnabledCursoSeleccionado");
            }
        }

        private bool _isEnabledGuardar = false;

        public bool IsEnabledGuardar
        {
            get { return _isEnabledGuardar; }
            set
            {
                _isEnabledGuardar = value;
                NotificarCambio("IsEnabledGuardar");
            }
        }

        private bool _isEnabledCancelar = false;

        public bool IsEnabledCancelar
        {
            get { return _isEnabledCancelar; }
            set
            {
                _isEnabledCancelar = value;
                NotificarCambio("IsEnabledCancelar");
            }
        }

        private bool _isEnabledNuevo = true;

        public bool IsEnabledNuevo
        {
            get { return _isEnabledNuevo; }
            set
            {
                _isEnabledNuevo = value;
                NotificarCambio("IsEnabledNuevo");
            }
        }

        private bool _isEnabledEliminar = true;

        public bool IsEnabledEliminar
        {
            get { return _isEnabledEliminar; }
            set
            {
                _isEnabledEliminar = value;
                NotificarCambio("IsEnabledEliminar");
            }
        }

        private bool _isEnabledEditar = true;

        public bool IsEnabledEditar
        {
            get { return _isEnabledEditar; }
            set
            {
                _isEnabledEditar = value;
                NotificarCambio("IsEnabledEditar");
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
                            _db.Clases.Remove(Elemento);
                            _db.SaveChanges();
                            this.ListaClases.Remove(Elemento);
                            LimpiarCampos();
                        }
                        catch (Exception ex)
                        {

                            await this._dialogCoordinator.ShowMessageAsync(
                            this,
                            "Eliminar Clase",
                            ex.Message);
                        }
                    }
                }
                else
                {
                    await this._dialogCoordinator.ShowMessageAsync(
                    this,
                    "Eliminar Clase",
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
                            var registro = new Clase
                            {

                                Nombre = this.Nombre,
                                FechaCreacion = this.FechaCreacion,
                                HoraInicio = this.HoraInicio,
                                HoraFin = this.HoraFin,
                                FechaInicio = this.FechaInicio,
                                FechaFinal = this.FechaFinal,
                                Salon = this.SalonSeleccionado,
                                GrupoAcademico = this.GrupoAcademicoSeleccionado,
                                Profesor = this.ProfesorSeleccionado,
                                Curso = this.CursoSeleccionado
                            };

                            _db.Clases.Add(registro);
                            _db.SaveChanges();
                            this.ListaClases.Add(registro);
                        }
                        catch (Exception ex)
                        {

                            await this._dialogCoordinator.ShowMessageAsync(
                            this,
                            "Guardar Clase",
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
                            int posicion = ListaClases.IndexOf(Elemento);
                            var registro = _db.Clases.Find(Elemento.ClaseId);

                            if (registro != null)
                            {
                                registro.Nombre = this.Nombre;
                                registro.FechaCreacion = this.FechaCreacion;
                                registro.HoraInicio = this.HoraInicio;
                                registro.HoraFin = this.HoraFin;
                                registro.FechaInicio = this.FechaInicio;
                                registro.FechaFinal = this.FechaFinal;
                                registro.Salon = this.SalonSeleccionado;
                                registro.GrupoAcademico = this.GrupoAcademicoSeleccionado;
                                registro.Profesor = this.ProfesorSeleccionado;
                                registro.Curso = this.CursoSeleccionado;
                                _db.Entry(registro).State = EntityState.Modified;
                                _db.SaveChanges();
                                ListaClases.RemoveAt(posicion);
                                ListaClases.Insert(posicion, registro);
                            }
                        }
                        catch (Exception ex)
                        {

                            await this._dialogCoordinator.ShowMessageAsync(
                                    this,
                                    "Editar Clase",
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
                                    "Editar Clase",
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
            this.IsEnabledNuevo = true;
            this.IsEnabledEliminar = true;
            this.IsEnabledEditar = true;
            this.IsReadOnlyNombre = true;
            this.IsEnabledFechaCreacion = false;
            this.IsReadOnlyHoraInicio = false;
            this.IsReadOnlyHoraFin = false;
            this.IsEnabledFechaInicio = false;
            this.IsEnabledFechaFinal = false;
            this.IsEnabledSalonSeleccionado = false;
            this.IsEnabledGrupoAcademicoSeleccionado = false;
            this.IsEnabledProfesorSeleccionado = false;
            this.IsEnabledCursoSeleccionado = false;
            this.IsEnabledGuardar = false;
            this.IsEnabledCancelar = false;

        }

        private void ActivarControles()
        {
            this.IsEnabledNuevo = false;
            this.IsEnabledEliminar = false;
            this.IsEnabledEditar = false;
            this.IsReadOnlyNombre = false;
            this.IsEnabledFechaCreacion = true;
            this.IsReadOnlyHoraInicio = true;
            this.IsReadOnlyHoraFin = true;
            this.IsEnabledFechaInicio = true;
            this.IsEnabledFechaFinal = true;
            this.IsEnabledSalonSeleccionado = true;
            this.IsEnabledGrupoAcademicoSeleccionado = true;
            this.IsEnabledProfesorSeleccionado = true;
            this.IsEnabledCursoSeleccionado = true;
            this.IsEnabledGuardar = true;
            this.IsEnabledCancelar = true;

        }

        private void LimpiarCampos()
        {
            this.Nombre = string.Empty;
            this.FechaCreacion = DateTime.Now;
            this.HoraInicio = TimeSpan.Zero;
            this.HoraFin = TimeSpan.Zero;
            this.FechaInicio = DateTime.Now;
            this.FechaFinal = DateTime.Now;
            this.SalonSeleccionado = null;
            this.GrupoAcademicoSeleccionado = null;
            this.ProfesorSeleccionado= null;
            this.CursoSeleccionado = null;
        }

        public ClaseViewModel(IDialogCoordinator dialogCoordinator)
        {
            this.Titulo = "Ventana Clases";
            this.FechaCreacion = DateTime.Now;
            this.FechaInicio = DateTime.Now;
            this.FechaFinal = DateTime.Now;
            this.Instancia = this;
            this._dialogCoordinator = dialogCoordinator;
        }

    }
}
