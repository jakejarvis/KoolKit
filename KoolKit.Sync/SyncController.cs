using Arendee.BTSyncLib;
using Arendee.BTSyncLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoolKit.Sync {
    public class SyncController {

        private const string HOSTNAME = "localhost";
        private const int TCP_PORT = 8888;
        private const string USERNAME = "api";
        private const string PASSWORD = "secret";
        private const bool SELECTIVE_SYNC = false;

        private BTSyncClient syncClient;

        public SyncController() {
            syncClient = new BTSyncClient(HOSTNAME, TCP_PORT, USERNAME, PASSWORD);
        }

        public void SetupSync(String folderToSync, String folderSecret) {
            // add folder to sync client
            var addFolderTask = syncClient.AddFolder(folderToSync, folderSecret, SELECTIVE_SYNC);
            // block until task is complete
            addFolderTask.Wait();
        }


    }
}
