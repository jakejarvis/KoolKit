using KoolKit.DataAccess.Entities;
using Newtonsoft.Json;
using System;
using System.IO;

namespace KoolKit.DataAccess {
    public class ToolKitJsonReader {

        // ToolKit Data Object
        public static ToolKit ToolKitData { get; private set; }
        // ToolKit Data Change Event Handler
        public delegate void ToolKitDataEventHandler(object sender, EventArgs e);
        // ToolKit Data Changed Event
        public event ToolKitDataEventHandler Changed;

        public ToolKitJsonReader(String pathToJson) {
            // register for file changes
            SetupToolKitJsonFileWatcher(pathToJson);
            // read the toolkit data
            ToolKitData = JsonConvert.DeserializeObject<ToolKit>(pathToJson);
            // invoke the OnChange event
            OnChanged(EventArgs.Empty);
        }

        // Invoke the Changed event; called whenever ToolKit Data changes
        protected virtual void OnChanged(EventArgs e) {
            if (Changed != null)
                Changed(this, e);
        }

        private void SetupToolKitJsonFileWatcher(String pathToJson) {
            // Create a new FileSystemWatcher and set its properties.
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = pathToJson;
            // Watch for changes in LastAccess and LastWrite times, and  the renaming of files or directories. 
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch toolkit data.json file.
            watcher.Filter = "data.json";

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(ToolKitDataChanged);
            watcher.Created += new FileSystemEventHandler(ToolKitDataChanged);
            watcher.Deleted += new FileSystemEventHandler(ToolKitDataChanged);

            // Begin watching.
            watcher.EnableRaisingEvents = true;
        }

        // Define the event handlers.
        private void ToolKitDataChanged(object source, FileSystemEventArgs e) {
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);

            if (e.ChangeType != System.IO.WatcherChangeTypes.Deleted) {
                // read the toolkit data
                ToolKitData = JsonConvert.DeserializeObject<ToolKit>(e.FullPath);
                // invoke the OnChange event
                OnChanged(EventArgs.Empty);
            } else {
                // the file was deleted :(
                Console.WriteLine("File: " + e.FullPath + " was DELETED");
            }
            
        }

    }
}
