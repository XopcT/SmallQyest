
namespace SmallQyest.Models
{
    /// <summary>
    /// Base Class for creating Wrappers.
    /// </summary>
    /// <typeparam name="WrappedType">Type to wrap.</typeparam>
    public class WrapperBase<WrappedType> : BindableBase
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        /// <param name="wrapped">Object to wrap.</param>
        public WrapperBase(WrappedType wrapped)
        {
            if (wrapped == null)
                throw new System.ArgumentNullException("wrapped");
            this.wrapped = wrapped;
        }

        #region Properties

        /// <summary>
        /// Retrieves the wrapped Object.
        /// </summary>
        public WrappedType Wrapped
        {
            get { return this.wrapped; }
        }

        #endregion

        #region Fields
        private readonly WrappedType wrapped = default(WrappedType);

        #endregion
    }
}
