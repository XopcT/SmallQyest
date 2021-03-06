﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmallQyest.Controls
{
    /// <summary>
    /// Interaction logic for MapControl.xaml
    /// </summary>
    public partial class MapControl : UserControl
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        public MapControl()
        {
            InitializeComponent();
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves a Command to add Things on the Map.
        /// </summary>
        public ICommand AddThing
        {
            get { return (ICommand)base.GetValue(addThingProperty); }
            set { base.SetValue(addThingProperty, value); }
        }

        #endregion

        #region Fields

        private static readonly DependencyProperty addThingProperty = DependencyProperty.Register("AddThing", typeof(ICommand), typeof(MapControl), new PropertyMetadata(null, (sender, e) => { System.Diagnostics.Debug.WriteLine("AddThing Command changed"); }));

        #endregion
    }
}
