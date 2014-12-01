using System.Windows;
using System.Windows.Interactivity;

namespace SmallQyest.Behaviors
{
    /// <summary>
    /// Behavior to perform Drag Operation.
    /// </summary>
    public class DragBehavior : Behavior<FrameworkElement>
    {
        /// <summary>
        /// Attaches Behavior to Control.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            base.AssociatedObject.MouseLeftButtonDown += this.AssociatedObject_MouseLeftButtonDown;
            base.AssociatedObject.MouseLeftButtonUp += this.AssociatedObject_MouseLeftButtonUp;
            base.AssociatedObject.MouseMove += this.AssociatedObject_MouseMove;
        }

        /// <summary>
        /// Detaches Behavior from Control.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            base.AssociatedObject.MouseDown -= this.AssociatedObject_MouseLeftButtonDown;
            base.AssociatedObject.MouseUp -= this.AssociatedObject_MouseLeftButtonUp;
            base.AssociatedObject.MouseMove -= this.AssociatedObject_MouseMove;
        }

        /// <summary>
        /// Handles Pressing the left Mouse Button over the Dragged Object.
        /// </summary>
        private void AssociatedObject_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.AssociatedObject.CaptureMouse();
        }

        /// <summary>
        /// Handles Releasing the left Mouse Button over the Dragged Object.
        /// </summary>
        private void AssociatedObject_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!this.AssociatedObject.IsMouseCaptured)
                return;
            this.AssociatedObject.ReleaseMouseCapture();
        }

        /// <summary>
        /// Handles moving a Mouse over the Dragged Object.
        /// </summary>
        private void AssociatedObject_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!this.AssociatedObject.IsMouseCaptured)
                return;
            // TODO Add some Distance the Mouse moves before Drag Operation starts.
            DataObject data = new DataObject(this.DataFormat, this.AssociatedObject.DataContext);
            DragDrop.DoDragDrop(this.AssociatedObject, data, DragDropEffects.Move);
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves the Format of Dragged Data.
        /// </summary>
        public string DataFormat
        {
            get { return (string)base.GetValue(dataFormatProperty); }
            set { base.SetValue(dataFormatProperty, value); }
        }

        #endregion

        #region Fields

        private static readonly DependencyProperty dataFormatProperty = DependencyProperty.Register("DataFormat", typeof(string), typeof(DragBehavior), new PropertyMetadata(string.Empty));

        #endregion
    }
}
