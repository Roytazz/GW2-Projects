using GuildWars2Guild.Classes;
using GuildWars2Guild.Controls.Widgets;
using GuildWars2Guild.Model.ViewModel;
using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace GuildWars2Guild
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : MetroWindow {

        MainWindow _mainWindow;

        public SplashScreen() {    
            InitializeComponent(); 

            var _bg = new BackgroundWorker { WorkerReportsProgress = true };
            _bg.DoWork += _bg_DoWork;
            _bg.ProgressChanged += _bg_ProgressChanged;
            _bg.RunWorkerCompleted += _bg_RunWorkerCompleted;
            _bg.RunWorkerAsync();
        }

        private static bool HasInternetConnection() {
            try {
                using(var stream = new WebClient().OpenRead("http://www.google.com")) {
                    return true;
                }
            } catch { }

            return false;
        }

        public void DialogHost_OnDialogClosing(object sender, DialogClosingEventArgs eventArgs) {
            OpenApplication();
        }

        private void OpenApplication() {
            _mainWindow.Show();
            this.Close();
        }

        #region BackgroundWorker

        private void _bg_DoWork(object sender, DoWorkEventArgs e) {
            var bg = sender as BackgroundWorker;
            var statusList = new List<Status>();

            if(HasInternetConnection()) {
                bg.ReportProgress(0, "Retrieving Information...");  //Download new Database
                if(!UpdateManager.DownloadDb())
                    statusList.Add(Status.DowloadFailed);
                
                bg.ReportProgress(0, "Saving Information...");      //Retrieve new Guild log and add them to the Database
                UpdateManager.AddNewLogs();
                
                bg.ReportProgress(0, "Sychronizing...");            //Upload the new Database
                if(!UpdateManager.UploadDb())
                    statusList.Add(Status.UploadFailed);

                UpdateManager.InitializeTimer();                    //Create Update Timer
            }
            else {
                statusList.Add(Status.NoConnection);
            }
            e.Result = statusList;
            
            bg.ReportProgress(0, "Initializing...");                //Create MainWindow
            Dispatcher.Invoke(() => {
                _mainWindow = new MainWindow();
            });
        }

        private void _bg_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            progress_TxtBlock.Text = e.UserState.ToString();
        }

        private void _bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            var statusList = e.Result as List<Status>;      //TODO Show a more detailed message depending on the status.
            if(statusList.Count > 0) {
                this.DialogHost.IsOpen = true;
            }
            else {
                OpenApplication();
            }
        }

        #endregion BackgroundWorker
    }

    enum Status
    {
        NoConnection,
        DowloadFailed,
        UploadFailed
    }
}