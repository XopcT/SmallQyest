using System;

namespace SmallQyest.Core
{
    /// <summary>
    /// Defines an Interface of a Level.
    /// </summary>
    public interface ILevel
    {
        /// <summary>
        /// Initializes the Level.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Passes the Level.
        /// </summary>
        /// <param name="levelId">ID of the next Level.</param>
        void Pass(int levelId);

        /// <summary>
        /// Fails the Level.
        /// </summary>
        void Fail();

        /// <summary>
        /// Occurs when Player passes the Level.
        /// </summary>
        event EventHandler<LevelPassedEventArgs> LevelPassed;

        /// <summary>
        /// Occurs when Player fails with the Level.
        /// </summary>
        event EventHandler<EventArgs> LevelFailed;

        /// <summary>
        /// Sets/retrieves the Level Map.
        /// </summary>
        IMap Map { get; set; }
    }
}
