   M S B A M L   `   `   `  ����F  BEjemploEEF1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:EjemploEEF1.ViewEjemploEEF1.View  5   	   5clr-namespace:EjemploEEF1.ModelEjemploEEF1.Model  5   	   H DMahApps.Metro, Version=1.6.0.0, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	   fCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.MetroMahApps.Metro.Controls.Dialogs 5
   	        EjemploEEF1.View.ClaseView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:EjemploEEF1.View     5   	   1Modelclr-namespace:EjemploEEF1.Model     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   VDialogCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.Metro     5
   	     � WindowStartupLocation$  CenterScreen=�5   	   $	��700��5   "   $
��1000��6/   8  2MahApps.Metro.Controls.Dialogs.DialogParticipation   Register 5   	   ��  � Title 5   	   �� *Titulo+.��5      � $��10q�6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5       �� 5!      .+�5#   
   �� $��0��6   $��0��6   $��Nombre��6-   $��Center=�6>   $��Center=�6b   $��26.667(�6�   �� 5$   
   *  $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton .    	Watermark$ Ingrese el nombre��6@   $��0��6�   $��1��6�   $��Center=�6�   $��Center=�6�   $��24(�6  $	��0,2q�6&   �� 
IsReadOnly 6u   �� *IsReadOnlyNombre+��6�   �� *Nombre+6&  �� 5%   
   $��1��6   $��0��6   $��Fecha de Creación��6-   $��Center=�6I   $��Center=�6m   $��26.667(�6�   (  "System.Windows.Controls.DatePicker  5&   
   -   5          Name$ tFechaCreacion��5&      $��1��6Z   $��1��6g   $��Stretch=�6  $��Stretch=�6*  $��26.667(�6M  	   FirstDayOfWeek$	 Monday=�6_  $	��0,2q�6w  {�6-   �� *IsEnabledFechaCreacion+
   Text
 6w   �� *FechaCreacion+ �� StringFormat$ {0:dd/MM/yyyy}�� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors .  � 	Resources 5'      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType �� Property �� Value ��Name �� Path �� RelativeSource �� AncestorType��%  '        �� 5(      "  6   .�5)      ��  � �� 5*      �� 5+      .R�5,   "   �� $ tDatePicker��6*   $��Center=�6�   $��Center=�6�   ��6?   �� $ SelectedDate�$ {0:dd/MM/yyyy}�� �� "  6�   5-      5/      50      51      52      �� 53   
   $��2��6   $��0��6   $��Hora Inicio��6-   $��Center=�6C   $��Center=�6g   $��26.667(�6�   �� 54   
    . $ Ingrese la Hora de Inicio��6@   $��2��6�   $��1��6�   $��Center=�6�   $��Center=�6  $��24(�6'  $	��0,2q�65   6}   �� *IsEnabledHoraInicio+��6�   �� *
HoraInicio+65  �� 55   
   $��3��6   $��0��6   $��Hora Fin��6-   $��Center=�6@   $��Center=�6d   $��26.667(�6�   �� 56   
    . $ Ingrese la Hora de Fin��6@   $��3��6�   $��1��6�   $��Center=�6�   $��Center=�6�   $��24(�6  $	��0,2q�6,   6z   �� *IsEnabledHoraFin+��6�   �� *	HoraFin+6,  �� 57   
   $��4��6   $��0��6   $��Fecha de Inicio��6-   $��Center=�6G   $��Center=�6k   $��26.667(�6�     58   
   -   5        $ tFechaInicio��58      $��4��6V   $��1��6c   $��Stretch=�6�   $��Stretch=�6$  $��26.667(�6G  $	 Monday=�6Y  $	��0,2q�6q  {�6+   �� *IsEnabledFechaInicio+
 6s   �� *FechaInicio+$ {0:dd/MM/yyyy}��$ TwoWay=�$ PropertyChanged=� .  59      ��%  '        �� 5:      "  6   .�5;      ��  � �� 5<      �� 5=      .R�5>   "   �� $ tDatePicker��6*   $��Center=�6�   $��Center=�6�   ��6?   �� $ SelectedDate�$ {0:dd/MM/yyyy}�� �� "  6�   5?      5A      5B      5C      5D      �� 5E   
   $��5��6   $��0��6   $��Fecha de Final��6-   $��Center=�6F   $��Center=�6j   $��26.667(�6�     5F   
   -   5        $ tFechaFinal��5F      $��5��6T   $��1��6a   $��Stretch=�6�   $��Stretch=�6!  $��26.667(�6D  $	 Monday=�6V  $	��0,2q�6n  {�6*   �� *IsEnabledFechaFinal+
 6q   �� *
FechaFinal+$ {0:dd/MM/yyyy}��$ TwoWay=�$ PropertyChanged=� .  5G      ��%  '        �� 5H      "  6   .�5I      ��  � �� 5J      �� 5K      .R�5L   "   �� $ tDatePicker��6*   $��Center=�6�   $��Center=�6�   ��6?   �� $ SelectedDate�$ {0:dd/MM/yyyy}�� �� "  6�   5M      5O      5P      5Q      5R      �� 5S   
   $��6��6   $��0��6   $��Salon��6-   $��Center=�6=    � UseLayoutRounding . $��Center=�6z   $��26.667(�6�   �� 5T   
   $ Seleccione un Salon:��6   $��6��6p   $��1��6}   $��24(�6�   $��Center=�6�   $
��Left=�6  $ �� IsSynchronizedWithCurrentItem$ FalseY�6/  $	��0,2q�6U  {�6K   �� *IsEnabledSalon+��6�   �� *ListaSalones+ �� SelectedItem 6�   �� *SalonSeleccionado+6U  �� 5U   
   $��7��6   $��0��6   $��Grupo Academico��6-   $��Center=�6G    . $��Center=�6�   $��26.667(�6�   �� 5V   
   $$ Seleccione un Grupo Academico:��6   $��7��6�   $��1��6�   $��24(�6�   $��Center=�6  $
��Left=�62  $ FalseY�6T  $	��0,2q�6z  {�6U   �� *IsEnabledGrupoAcademico+��6�   �� *ListaGruposAcademicos+ 6�   �� *GrupoAcademicoSeleccionado+6z  �� 5W   
   $��8��6   $��0��6   $��Profesor��6-   $��Center=�6@    . $��Center=�6}   $��26.667(�6�   �� 5X   
   $ Seleccione un Profesor:��6   $��8��6v   $��1��6�   $��24(�6�   $��Center=�6�   $
��Left=�6  $ FalseY�6;  $	��0,2q�6a  {�6N   �� *IsEnabledProfesor+��6�   �� *ListaProfesores+ 6�   �� *ProfesorSeleccionado+6a  �� 5Y   
   $��9��6   $��0��6   $��Curso��6-   $��Center=�6=    . $��Center=�6z   $��26.667(�6�   �� 5Z   
   $ Seleccione un Curso:��6   $��9��6p   $��1��6}   $��24(�6�   $��Center=�6�   $
��Left=�6  $ FalseY�6.  $	��0,2q�6T  {�6K   �� *IsEnabledCurso+��6�   �� *ListaCursos+ 6�   �� *CursoSeleccionado+6T  &   System.Windows.Controls.DataGrid  5[   
   -   5          Name$ dataGrid��5[   �      AzureDataGrid#��[  6   $��5,10,5,5q�6\      CanUserAddRows .  $��10��6�   $��3��6�   $��2��6�      AutoGenerateColumns .  $��Stretch=�6
  $��Stretch=�6/     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6R  $��10.667(�6b   6:   �� *
Elemento+��6�   �� *ListaClases+   Columns 5\      4  .System.Windows.Controls.DataGridCheckBoxColumn  5]        MetroDataGridCheckBox1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# �  6)       EditingElementStyle#  �  5^   )   ,	  &System.Windows.Controls.DataGridColumn! 	  Header$! 
IsSelected��5_   )   "   Binding" 5`   )   ��  �� $ DataGridRowL�$ 
IsSelected�$ OneWay=�0
  *System.Windows.Controls.DataGridTextColumn
  5b      $! Nombre��6%   " 65   �� *Nombre+
  5c      $! Fecha Creacion��6%   " 6=   �� *FechaCreacion+$ {0:dd/MM/yyyy}��
  5d      $! Hora Inicio��6%   " 6:   �� *
HoraInicio+
  5e      $! Hora Fin��6%   " 67   �� *	HoraFin+
  5f      $! Fecha Inicio��6%   " 6;   �� *FechaInicio+$ {0:dd/MM/yyyy}��
  5g      $! 	Fecha Fin��6%   " 68   �� *
FechaFinal+$ {0:dd/MM/yyyy}��
  5h      $! Salon��6%   " 64   �� *Salon.Descripcion+
  5i      $! 
Grupo Acad��6%   " 69   �� *GrupoAcademico.Descripcion+
  5j      $! Nombre Prof��6%   " 6:   �� *Profesor.Nombres+
  5k      $! Apellidos Prof��6%   " 6=   �� *Profesor.Apellidos+
  5l      $! Curso��6%   " 64   �� *Curso.Descripcion+5n      �� 5o   
   $��5q�6   $��13��6    $��0��6.   $��2��6>   # �� Orientation$# 
Horizontal=�6R   .+�5p      ��   AccentedSquareButtonStyle#��[ 6   $��Nuevo��6f   $��20(�6�   $��Nuevo��6�   $��Center=�6�   ��6H   �� *	Instancia+{�6   �� *IsEnableNuevo+6�   �� 5q      #��[ 6   $��Eliminar��6f   $��20(�6�   $��Eliminar��6�   $��Center=�6�   ��6H   �� *	Instancia+{�6�   �� *IsEnableEliminar+6�   �� 5r      #��[ 6   $��Editar��6f   $��20(�6�   $��Editar��6�   $��Center=�6�   ��6H   �� *	Instancia+{�6�   �� *IsEnableEditar+6�   �� 5s      #��[ 6   $��Guardar��6f   $��20(�6�   $��Guardar��6�   $��Center=�6�   ��6H   �� *	Instancia+{�6�   �� *IsEnableGuardar+6�   �� 5t      #��[ 6   $��Cancelar��6f   $��20(�6�   $��Cancelar��6�   $��Center=�6�   ��6H   �� *	Instancia+{�6�   �� *IsEnableCancelar+6�   5u      5v      5w      