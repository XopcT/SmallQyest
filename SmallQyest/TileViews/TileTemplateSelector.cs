using System.Windows;
using System.Windows.Controls;
using SmallQyest.Models;

namespace SmallQyest.TileViews
{
    public class TileTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is GroundTileModel)
                return this.GroundTemplate;
            return base.SelectTemplate(item, container);
        }

        #region Properties

        public DataTemplate GroundTemplate { get; set; }

        #endregion

        #region Fields

        #endregion
    }
}
