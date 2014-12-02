﻿using System;
using System.Windows.Threading;
using SmallQyest.World;
using Logging;

namespace SmallQyest
{
    /// <summary>
    /// Level controlled by a WPF Dispatcher.
    /// </summary>
    public class DispatcherLevel : Level
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        /// <param name="map">Map of the Level.</param>
        /// <param name="logger">Logger for Level Messages.</param>
        public DispatcherLevel(Map map, ILogger logger)
            : base(map)
        {
            this.timer = new DispatcherTimer();
            this.timer.Tick += timer_Tick;
            this.timer.Interval = TimeSpan.FromSeconds(0.3);
        }

        private void timer_Tick(object sender, System.EventArgs e)
        {
            foreach (Item item in this.Map)
                item.Update();
        }

        /// <summary>
        /// Starts playing the Level.
        /// </summary>
        public override void Start()
        {
            this.logger.LogMessage("Level started");
            base.Start();
            this.timer.Start();
        }

        /// <summary>
        /// Stops playing the Level.
        /// </summary>
        public override void Stop()
        {
            base.Stop();
            this.timer.Stop();
            this.logger.LogMessage("Level stopped");
        }

        /// <summary>
        /// Passes the Level.
        /// </summary>
        /// <param name="levelId">ID of the next Level.</param>
        public override void Pass(int levelId)
        {
            this.logger.LogMessage("Passing to Level", levelId);
            base.Pass(levelId);
        }

        /// <summary>
        /// Fails the Level.
        /// </summary>
        public override void Fail()
        {
            this.logger.LogMessage("Level failed");
            base.Fail();
        }

        #region Properties

        #endregion

        #region Fields
        private DispatcherTimer timer = null;
        private ILogger logger = null;

        #endregion
    }
}
