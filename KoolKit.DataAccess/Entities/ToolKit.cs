using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoolKit.DataAccess.Entities {
    public class ToolKit {

        [JsonProperty("pulse_user_id")]
        public String PulseUserId { get; set; }
        
        [JsonProperty("student_name")]
        public String StudentName { get; set; }
        
        [JsonProperty("course")]
        public String Course { get; set; }

        [JsonProperty("course_id")]
        public int CourseId { get; set; }

        [JsonProperty("location")]
        public String Location { get; set; }

        [JsonProperty("location_id")]
        public int LocationId { get; set; }

        [JsonProperty("term")]
        public String Term { get; set; }

        [JsonProperty("term_id")]
        public int TermId { get; set; }

        [JsonProperty("last_backup")]
        public String LastBackup { get; set; }

        [JsonProperty("source_directory")]
        public String SourceDirectory { get; set; }

    }
}
