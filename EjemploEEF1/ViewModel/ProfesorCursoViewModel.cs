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
    class ProfesorCursoViewModel : INotifyPropertyChanged, ICommand
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

        private ProfesorCurso _elemento;

        public ProfesorCurso Elemento
        {
            get { return _elemento; }
            set
            {
                _elemento = value;
                if (value != null)
                {
                    this.CursoSeleccionado = value.Curso;
                    this.ProfesorSeleccionado = value.Profesor;
                    this.Tutor = value.Tutor;
                }
                NotificarCambio("Elemento");
            }
        }

        private ProfesorCursoViewModel _instancia;

        public ProfesorCursoViewModel Instancia
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

        private ObservableCollection<ProfesorCurso> _listaProfesoresCursos;

        public ObservableCollection<ProfesorCurso> ListaProfesoresCursos
        {
            get
            {
                if (_listaProfesoresCursos != null)
                {
                    return _listaProfesoresCursos;
                }
                else
                {
                    _listaProfesoresCursos = new ObservableCollection<ProfesorCurso>(_db.ProfesoresCursos.ToList());
                    return _listaProfesoresCursos;
                }
            }
            set
            {
                _listaProfesoresCursos = value;
                NotificarCambio("ListaProfesoresCursos");
            }
        }


        private string _tutor;

        public string Tutor
        {
            get { return _tutor; }
            set
            {
                _tutor = value;
                NotificarCambio("Tutor");
            }
        }

        //
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
                if (_listaCursos !=null)
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

        //


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

        private bool _IsEnabledCurso = false;

        public bool IsEnabledCurso
        {
            get { return _IsEnabledCurso; }
            set
            {
                _IsEnabledCurso = value;
                NotificarCambio("IsEnabledCurso");
            }
        }

        private bool _IsEnabledProfesor = false;

        public bool IsEnabledProfesor
        {
            get { return _IsEnabledProfesor; }
            set
            {
                _IsEnabledProfesor = value;
                NotificarCambio("IsEnabledProfesor");
            }
        }


        private bool _isReadOnlyTutor = true;

        public bool IsReadOnlyTutor
        {
            get { return _isReadOnlyTutor; }
            set
            {
                _isReadOnlyTutor = value;
                NotificarCambio("IsReadOnlyTutor");
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
                    "Eliminar ProfesorCurso",
                    "Esta seguro de eliminar el registro?",
                    MessageDialogStyle.AffirmativeAndNegative);
                    if (resultado == MessageDialogResult.Affirmative)
                    {
                        try
                        {
                            _db.ProfesoresCursos.Remove(Elemento);
                            _db.SaveChanges();
                            this.ListaProfesoresCursos.Remove(Elemento);
                            LimpiarCampos();
                        }
                        catch (Exception ex)
                        {

                            await this._dialogCoordinator.ShowMessageAsync(
                            this,
                            "Eliminar Curso",
                            ex.Message);
                        }
                    }
                }
                else
                {
                    await this._dialogCoordinator.ShowMessageAsync(
                    this,
                    "Eliminar Curso",
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
                            var registro = new ProfesorCurso
                            {
                                Curso = this.CursoSeleccionado,
                                Profesor = this.ProfesorSeleccionado,
                                Tutor = this.Tutor
                            };

                            _db.ProfesoresCursos.Add(registro);
                            _db.SaveChanges();
                            this.ListaProfesoresCursos.Add(registro);
                        }
                        catch (Exception ex)
                        {

                            await this._dialogCoordinator.ShowMessageAsync(
                            this,
                            "Guardar Curso",
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
                            int posicion = ListaProfesoresCursos.IndexOf(Elemento);
                            var registro = _db.ProfesoresCursos.Find(Elemento.CursoId);

                            if (registro != null)
                            {
                                registro.Curso = this.CursoSeleccionado;
                                registro.Profesor = this.ProfesorSeleccionado;
                                registro.Tutor = this.Tutor;
                                _db.Entry(registro).State = EntityState.Modified;
                                _db.SaveChanges();
                                ListaProfesoresCursos.RemoveAt(posicion);
                                ListaProfesoresCursos.Insert(posicion, registro);
                            }
                        }
                        catch (Exception ex)
                        {

                            await this._dialogCoordinator.ShowMessageAsync(
                                    this,
                                    "Editar Curso",
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
                                    "Editar Curso",
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
            this.IsReadOnlyTutor = true;
            this.IsEnabledCurso = false;
            this.IsEnabledProfesor = false;
            this.IsEnableGuardar = false;
            this.IsEnableCancelar = false;

        }

        private void ActivarControles()
        {
            this.IsEnableNuevo = false;
            this.IsEnableEliminar = false;
            this.IsEnableEditar = false;
            this.IsReadOnlyTutor = false;
            this.IsEnabledCurso = true;
            this.IsEnabledProfesor = true;
            this.IsEnableGuardar = true;
            this.IsEnableCancelar = true;

        }

        private void LimpiarCampos()
        {
            this.Tutor = string.Empty;
        }

        public ProfesorCursoViewModel(IDialogCoordinator dialogCoordinator)
        {
            this.Titulo = "Ventana Profesores Cursos";
            this.Instancia = this;
            this._dialogCoordinator = dialogCoordinator;
        }
    }
}
