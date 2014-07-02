﻿using System;
using SmallQyest.ViewModels;
using SmallQyest.Core;

namespace SmallQyest
{
    /// <summary>
    /// Factory which creates View Models.
    /// </summary>
    public class ViewModelFactory : IViewModelFactory
    {
        /// <summary>
        /// Initializes a new Instance of current Class.
        /// </summary>
        /// <param name="appController">Application Controller Instance.s</param>
        public ViewModelFactory(IAppController appController)
        {
            this.appController = appController;
        }

        /// <summary>
        /// Retrieves View Model for Application main Menu.
        /// </summary>
        /// <returns>View Model Instance.</returns>
        public IViewModel GetMainMenuViewModel()
        {
            MenuViewModel viewModel = new MenuViewModel();
            viewModel.AppController = this.appController;
            viewModel.ViewModelFactory = this;
            return viewModel;
        }

        /// <summary>
        /// Retrieves View Model for a Game Level.
        /// </summary>
        /// <param name="level">Level to create View Model for.</param>
        /// <returns>View Model Instance.</returns>
        public IViewModel GetLevelViewModel(Level level)
        {
            LevelViewModel viewModel = new LevelViewModel();
            viewModel.AppController = this.appController;
            viewModel.ViewModelFactory = this;
            viewModel.Level = level;
            return viewModel;
        }

        #region Properties

        #endregion

        #region Fields

        private readonly IAppController appController = null;

        #endregion
    }
}