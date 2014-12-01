using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace SmallQyest.Behaviors
{
    /// <summary>
    /// Behavior to perform Drop Operation.
    /// </summary>
    public class DropBehavior : Behavior<FrameworkElement>
    {
        /// <summary>
        /// Attaches Behavior to Control.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            base.AssociatedObject.AllowDrop = true;
            base.AssociatedObject.DragEnter += this.AssociatedObject_DragEnter;
            base.AssociatedObject.Drop += this.AssociatedObject_Drop;
        }

        /// <summary>
        /// Detaches Behavior from Control.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            base.AssociatedObject.AllowDrop = false;
            base.AssociatedObject.PreviewDragEnter -= this.AssociatedObject_DragEnter;
            base.AssociatedObject.Drop -= this.AssociatedObject_Drop;
        }

        /// <summary>
        /// Handles entering a Mouse Pointer with an Object dragged.
        /// </summary>
        private void AssociatedObject_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(this.AcceptedDataFormat))
                e.Effects = DragDropEffects.None;
        }

        /// <summary>
        /// Handles dropping an Object.
        /// </summary>
        private void AssociatedObject_Drop(object sender, DragEventArgs e)
        {
            object data = e.Data.GetData(this.AcceptedDataFormat);
            if (data == null)
                return;
            var droppedEventArgs = new { Source = data, Target = base.AssociatedObject.DataContext };
            if (this.DropCommand != null && this.DropCommand.CanExecute(droppedEventArgs))
                this.DropCommand.Execute(droppedEventArgs);
        }

        #region Properties

        /// <summary>
        /// Sets/retrieves a Data Format which can be accepted by Drop Target.
        /// </summary>
        public string AcceptedDataFormat
        {
            get { return (string)base.GetValue(acceptedDataFormatProperty); }
            set { base.SetValue(acceptedDataFormatProperty, value); }
        }

        /// <summary>
        /// Sets/retrieves a Command performed when Drop happens.
        /// </summary>
        public ICommand DropCommand
        {
            get { return (ICommand)base.GetValue(dropCommandProperty); }
            set { base.SetValue(dropCommandProperty, value); }
        }

        #endregion

        #region Fields
        private static readonly DependencyProperty acceptedDataFormatProperty = DependencyProperty.Register("AcceptedDataFormat", typeof(string), typeof(DropBehavior), new PropertyMetadata(string.Empty));
        private static readonly DependencyProperty dropCommandProperty = DependencyProperty.Register("DropCommand", typeof(ICommand), typeof(DropBehavior), new PropertyMetadata(null));

        #endregion
    }
}
