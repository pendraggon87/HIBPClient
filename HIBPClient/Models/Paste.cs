using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIBPClient.Models
{
    public class Paste
    {
        /// <summary>
        /// The paste service the record was retrieved from. Current values are: Pastebin, Pastie, Slexy, Ghostbin, QuickLeak, JustPaste, AdHocUrl, OptOut
        /// </summary>
        /// <value>
        /// The source of the paste.
        /// </value>
        [JsonProperty("Source")]
        public string Source { get; protected internal set; }
        /// <summary>
        /// The ID of the paste as it was given at the source service. Combined with the "Source" attribute, this can be used to resolve the URL of the paste.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty("Id")]
        public string ID { get; protected internal set; }
        /// <summary>
        /// The title of the paste as observed on the source site. This may be null and if so will be omitted from the response.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [JsonProperty("Title")]
        public string Title { get; protected internal set; }
        /// <summary>
        /// The date and time (precision to the second) that the paste was posted. This is taken directly from the paste site when this information is available but may be null if no date is published.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        [JsonProperty("Date")]
        public DateTime Date { get; protected internal set; }
        /// <summary>
        /// The number of emails that were found when processing the paste. 
        /// </summary>
        /// <value>
        /// The email count.
        /// </value>
        /// <remarks>
        /// Emails are extracted by using the regular expression \b+(?!^.{256})[a-zA-Z0-9\.\-_\+]+@[a-zA-Z0-9\.\-_]+\.[a-zA-Z]+\b
        /// </remarks>
        [JsonProperty("EmailCount")]
        public int EmailCount { get; protected internal set; }

    }
}
