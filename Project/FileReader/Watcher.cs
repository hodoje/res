using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    public class Watcher
    {
        private IReader _reader;
        private ILogger _logger;
        private FileSystemWatcher _fileSystemWatcher;
        private Task _watcherTask;
        private string _directoryToWatch;

        public Watcher(IReader reader, ILogger logger, string directoryToWatch)
        {
            _reader = reader;
            _logger = logger;
            _directoryToWatch = directoryToWatch;
            _watcherTask = new Task(() =>
            {
                InitializeWatcher(_directoryToWatch);
            });
            _watcherTask.Start();
        }

        private void InitializeWatcher(string directoryToWatch)
        {
            _fileSystemWatcher = new FileSystemWatcher(directoryToWatch)
            {
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName,
                IncludeSubdirectories = false,
                Filter = "*.*"
            };
            _fileSystemWatcher.Created += new FileSystemEventHandler(OnNewFileAdded);
            _fileSystemWatcher.EnableRaisingEvents = true;
        }

        private void OnNewFileAdded(object sender, FileSystemEventArgs eventArgs)
        {
            
        }

        public IReader Reader { get => _reader; set => _reader = value; }
        public ILogger Logger { get => _logger; set => _logger = value; }
        public Task WatcherTask { get => _watcherTask; set => _watcherTask = value; }
    }
}
