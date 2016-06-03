using GuildWars2Guild.Classes;
using GuildWars2Guild.Classes.IO;
using GuildWars2Guild.Classes.Logger;
using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
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

            //OpenApplication();
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
            if(_mainWindow == null)
                _mainWindow = new MainWindow();

            App.Current.MainWindow = _mainWindow;
            _mainWindow.Show();
            this.Close();
        }

        #region BackgroundWorker

        private void _bg_DoWork(object sender, DoWorkEventArgs e) {
            var bg = sender as BackgroundWorker;
            var statusList = new List<Status>();

            if(!HasInternetConnection()) {
                statusList.Add(Status.NoConnection);
            }
            else {
                bg.ReportProgress(0, "Retrieving Information...");      //Download new Database
                var downloaded = UpdateManager.DownloadDb();
                if(!downloaded) {
                    statusList.Add(Status.DowloadFailed);
                }
                else {
                    bg.ReportProgress(0, "Saving Information...");      //Retrieve new Guild log and add them to the Database
                    UpdateManager.AddNewLogs();

                    bg.ReportProgress(0, "Sychronizing...");            //Upload the new Database
                    if(!UpdateManager.UploadDb())
                        statusList.Add(Status.UploadFailed);

                    bg.ReportProgress(0, "Initializing...");            //Create MainWindow
                    if(statusList.Count == 0) {
                        Dispatcher.Invoke(() => {
                            _mainWindow = new MainWindow();
                        });
                    }

                    UpdateManager.InitializeTimer();                    //Create Update Timer
                }
            }
            e.Result = statusList;
        }

        private void _bg_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            progress_TxtBlock.Text = e.UserState.ToString();
        }

        private void _bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            var statusList = e.Result as List<Status>;
            if(statusList.Count > 0) {
                LogManager.LogMessage(GetStatusErrorMessage(statusList), LogType.Message, false);
                this.Dialog_Label.Text = GetStatusMessage(statusList);
                this.DialogHost.IsOpen = true;
            }
            else {
                OpenApplication();
            }
        }

        #endregion BackgroundWorker

        #region Status
        
        private string GetStatusMessage(List<Status> statusList) {
            string result = "";
            foreach(Status status in statusList) {
                if(status == Status.DowloadFailed) {
                    result += "- Unable to download the database";
                }
                else if(status == Status.UploadFailed) {
                    result += "- Unable to upload the database";
                }
                else if(status == Status.NoConnection) {
                    result += "- Unable to find an internet connection";
                }
                else if(status == Status.NoDatabaseFound) {
                    result += "- Unable to locate the database file";
                }
                else {
                    continue;
                }
                result += Environment.NewLine;
            }
            return result;
        }

        private string GetStatusErrorMessage(List<Status> statusList) {
            string result = "Status errors on start-up: ";
            foreach(Status status in statusList) {
                result += Enum.GetName(typeof(Status), status) + ";";
            }
            return result;
        }

        #endregion
    }

    enum Status
    {
        NoConnection,
        DowloadFailed,
        UploadFailed,
        NoDatabaseFound
    }
}