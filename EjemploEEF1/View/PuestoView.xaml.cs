﻿using EjemploEEF1.ViewModel;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EjemploEEF1.View
{
    /// <summary>
    /// Lógica de interacción para PuestoView.xaml
    /// </summary>
    public partial class PuestoView : MetroWindow
    {
        public PuestoView()
        {
            InitializeComponent();
            PuestoViewModel modelo = new PuestoViewModel(DialogCoordinator.Instance);
            this.DataContext = modelo;
        }

    }
}