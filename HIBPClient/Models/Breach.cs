using System;
using System.Collections.Generic;

namespace HIBPClient.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// TODO Find a way to make Breach immutable when returned.
    public class Breach
    {
        /// <summary>
        /// A Pascal-cased name representing the breach which is unique across all other breaches. This value never changes and may be used to name dependent assets (such as images) but should not be shown directly to end users (see the <see cref="Title" /> attribute instead).
        /// </summary>
        /// <value>
        /// The unique name of the breach.
        /// </value>
        public string Name { get; }
        /// <summary>
        /// A descriptive title for the breach suitable for displaying to end users. It's unique across all breaches but individual values may change in the future (i.e. if another breach occurs against an organization already in the system). If a stable value is required to reference the breach, refer to the <see cref="Name"/> attribute instead.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; protected internal set; }
        /// <summary>
        /// The domain of the primary website the breach occurred on. This may be used for identifying other assets external systems may have for the site.
        /// </summary>
        /// <value>
        /// The domain.
        /// </value>
        public string Domain { get; protected internal set; }
        /// <summary>
        /// The date (with no time) the breach originally occurred on in ISO 8601 format. This is not always accurate — frequently breaches are discovered and reported long after the original incident. Use this attribute as a guide only.
        /// </summary>
        /// <value>
        /// The breach date.
        /// </value>
        /// <remarks>
        /// The date will never have an associated time
        /// </remarks>
        public DateTime BreachDate { get; protected internal set; }
        /// <summary>
        /// The date and time (precision to the minute) the breach was added to the system in ISO 8601 format.
        /// </summary>
        /// <value>
        /// The added date.
        /// </value>
        public DateTime AddedDate { get; protected internal set; }
        /// <summary>
        /// The date and time (precision to the minute) the breach was modified in ISO 8601 format. This will only differ from the <see cref="AddedDate"/> attribute if other attributes represented here are changed or data in the breach itself is changed (i.e. additional data is identified and loaded). 
        /// </summary>
        /// <value>
        /// The modified date.
        /// </value>
        /// <remarks>
        /// This field is always either equal to or greater then the <see cref="AddedDate"/> attribute, never less than.
        /// </remarks>
        public DateTime ModifiedDate { get; protected internal set; }
        /// <summary>
        /// The total number of accounts loaded into the system. This is usually less than the total number reported by the media due to duplication or other data integrity issues in the source data.
        /// </summary>
        /// <value>
        /// The total number of accounts loaded into the system.
        /// </value>
        public int PwnCount { get; protected internal set; }
        /// <summary>
        /// Contains an overview of the breach represented in HTML markup. The description may include markup such as emphasis and strong tags as well as hyperlinks.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; protected internal set; }
        /// <summary>
        /// This attribute describes the nature of the data compromised in the breach and contains an alphabetically ordered string array of impacted data classes.
        /// </summary>
        /// <value>
        /// The data classes.
        /// </value>
        public IReadOnlyList<string> DataClasses { get; protected internal set; }
        /// <summary>
        /// Indicates that the breach is considered <see href="https://haveibeenpwned.com/FAQs#UnverifiedBreach">unverified</see>. An unverified breach may not have been hacked from the indicated website. An unverified breach is still loaded into HIBP when there's sufficient confidence that a significant portion of the data is legitimate.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is verified; otherwise, <c>false</c>.
        /// </value>
        public bool IsVerified { get; protected internal set; }
        /// <summary>
        /// Indicates that the breach is considered <see href="https://haveibeenpwned.com/FAQs#FabricatedBreach">fabricated</see>. A fabricated breach is unlikely to have been hacked from the indicated website and usually contains a large amount of manufactured data. However, it still contains legitimate email addresses and asserts that the account owners were compromised in the alleged breach.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is fabricated; otherwise, <c>false</c>.
        /// </value>
        public bool IsFabricated { get; protected internal set; }
        /// <summary>
        /// Indicates if the breach is considered <see href="https://haveibeenpwned.com/FAQs#SensitiveBreach">sensitive</see>. The public API will not return any accounts for a breach flagged as sensitive.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is sensitive; otherwise, <c>false</c>.
        /// </value>
        public bool IsSensitive { get; protected internal set; }
        /// <summary>
        /// Indicates if the breach has been <see href="https://haveibeenpwned.com/FAQs#RetiredBreach">retired</see>. This data has been permanently removed and will not be returned by the API.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is retired; otherwise, <c>false</c>.
        /// </value>
        public bool IsRetired { get; protected internal set; }
        /// <summary>
        /// Indicates if the breach is considered a <see href="https://haveibeenpwned.com/FAQs#SpamList"/>spam list</see>. This flag has no impact on any other attributes but it means that the data has not come as a result of a security compromise.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is spam list; otherwise, <c>false</c>.
        /// </value>
        public bool IsSpamList { get; protected internal set; }

    }
}
