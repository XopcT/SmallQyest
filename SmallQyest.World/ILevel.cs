using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using SmallQyest.World.Things;

namespace SmallQyest.World
{
    /// <summary>
    /// Defines an Interface of a Level.
    /// </summary>
    public interface ILevel : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes the Level.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Starts playing the Level.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops playing the Level.
        /// </summary>
        void Stop();

        /// <summary>
        /// Resets the Level to initial State.
        /// </summary>
        void Reset();

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
        Map Map { get; }

        /// <summary>
        /// Retrieves the Collection of Tools available for this Level.
        /// </summary>
        ObservableCollection<Thing> Tools { get; }

        /// <summary>
        /// Retrieves whether the Level is currently playing.
        /// </summary>
        bool IsPlaying { get; }
    }
}
