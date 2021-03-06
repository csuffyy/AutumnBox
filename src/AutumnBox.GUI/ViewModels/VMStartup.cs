﻿using AutumnBox.GUI.MVVM;
using AutumnBox.GUI.Util.Loader;
using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Windows;

namespace AutumnBox.GUI.ViewModels
{
    class VMStartup : ViewModelBase
    {
        protected override bool InjectProperties => false;

        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                RaisePropertyChanged();
            }
        }
        private string _status;

        public string VersionName => GetType()?.Assembly?.GetName()?.Version?.ToString(3) +

#if CANARY
            "-canary"
#elif DEBUG
            "-debug"
#else
            ""
#endif
            ;

        public double Progress
        {
            get
            {
                return _progress;
            }
            set
            {
                _progress = value;
                RaisePropertyChanged();
            }
        }
        private double _progress;

        public AppLoadingException Exception
        {
            get
            {
                return _exception;
            }
            set
            {
                _exception = value;
                RaisePropertyChanged();
            }
        }
        private AppLoadingException _exception;


        public bool Loaded
        {
            get
            {
                return _loaded;
            }
            set
            {
                _loaded = value;
                RaisePropertyChanged();
            }
        }
        private bool _loaded;

        public VMStartup()
        {
            RaisePropertyChangedOnUIThread = true;
            App.Current.AppLoader.StepFinished += AppLoader_StepFinished;
            App.Current.AppLoader.Succeced += AppLoader_Succeced;
            App.Current.AppLoader.Failed += AppLoader_Failed;
        }

        private void AppLoader_Failed(object sender, AppLoaderFailedEventArgs e)
        {
            Exception = e.Exception;
        }

        private void AppLoader_Succeced(object sender, System.EventArgs e)
        {
            Loaded = true;
        }

        private void AppLoader_StepFinished(object sender, StepFinishedEventArgs e)
        {
            Progress = 100.0 * e.FinishedStep / e.TotalStepCount;
        }
    }
}
