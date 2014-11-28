using System.Windows;
using System.Windows.Interactivity;

namespace SmallQyest.Behaviors
{
    /// <summary>
    /// Behavior for a Drag Operation.
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

        private void AssociatedObject_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.AssociatedObject.CaptureMouse();
        }

        private void AssociatedObject_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!this.AssociatedObject.IsMouseCaptured)
                return;
            this.AssociatedObject.ReleaseMouseCapture();
        }

        private void AssociatedObject_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!this.AssociatedObject.IsMouseCaptured)
                return;
            DragDrop.DoDragDrop(this.AssociatedObject, this.AssociatedObject.DataContext, DragDropEffects.Move);
        }

        #region Properties

        #endregion

        #region Fields

        #endregion
    }
}
