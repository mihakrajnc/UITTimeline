using System;
using UnityEngine.Playables;
using UnityEngine.UIElements;

namespace UITTimeline
{
    /// <summary>
    /// Generic behaviour for all UIT behaviours.
    /// </summary>
    [Serializable]
    public class UITBehaviour : PlayableBehaviour
    {
        /// <summary>
        /// Defines which usage hints, if any, should be used when this behaviour is active, to optimize performance.
        /// </summary>
        public virtual UsageHints Hints => UsageHints.None;
    }
}