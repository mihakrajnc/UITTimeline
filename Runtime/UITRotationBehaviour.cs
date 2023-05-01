using System;
using UnityEngine.UIElements;

namespace UITTimeline
{
    /// <summary>
    /// The behaviour / data of the rotation operation.
    /// 
    /// <see cref="UITScaleClip"/>
    /// </summary>
    [Serializable]
    public class UITRotationBehaviour : UITBehaviour
    {
        public override UsageHints Hints => UsageHints.DynamicTransform;

        public float Rotation;
    }
}