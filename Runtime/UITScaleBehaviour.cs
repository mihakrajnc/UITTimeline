using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace UITTimeline
{
    /// <summary>
    /// The behaviour / data of the scale operation.
    /// 
    /// <see cref="UITScaleClip"/>
    /// </summary>
    [Serializable]
    public class UITScaleBehaviour : UITBehaviour
    {
        public override UsageHints Hints => UsageHints.DynamicTransform;

        public Vector2 Scale;
    }
}