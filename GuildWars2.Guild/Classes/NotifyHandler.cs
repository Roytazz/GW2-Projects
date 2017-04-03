using System;
using System.Collections.Generic;
using System.Timers;

namespace GuildWars2.Guild.Classes
{
    public sealed class NotifyHandler : IDisposable
    {
        public static event NotificationEvent NotificationAdded;

        public delegate void NotificationEvent(object sender, NotifyEventArgs e);

        private DateTime _lastDate;
        private Queue<string> _queue;

        private Timer _timer;
        private static TimeSpan INTERVAL = new TimeSpan(0, 0, 3);

        private static object lockObj = new object();
        private static volatile NotifyHandler _instance;

        public static NotifyHandler Instance {
            get {
                if(_instance == null) {
                    lock (lockObj) {
                        if(_instance == null)
                            _instance = new NotifyHandler();
                    }
                }
                return _instance;
            }
        }

        public NotifyHandler() {
            _timer = new Timer();
            _timer.Interval = INTERVAL.TotalMilliseconds;
            _timer.Elapsed += (sender, e) => TryToPush();

            _queue = new Queue<string>();
        }

        public void AddNotification(string notification) {
            _queue.Enqueue(notification);
            if(!_timer.Enabled) {
                TryToPush();
            }
        }

        private void TryToPush() {
            _timer.Stop();

            if(_lastDate == null || IsIntervalOver()) {
                PushNotification(_queue.Dequeue());

                if(_queue.Count > 0) {
                    _timer.Start();
                }
            }
            else {
                _timer.Start();
            }
        }

        private void PushNotification(string notification) {
            _lastDate = DateTime.Now;
            NotificationAdded?.Invoke(this, new NotifyEventArgs() { Notification = notification });
        }

        private bool IsIntervalOver() => (DateTime.Now - _lastDate).TotalSeconds > INTERVAL.TotalSeconds;

        public void Dispose() {
            _timer.Dispose();
        }
    }

    public class NotifyEventArgs : EventArgs
    {
        public string Notification { get; set; }
    }
}