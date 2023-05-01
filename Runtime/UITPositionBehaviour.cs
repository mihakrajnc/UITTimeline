using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace UITTimeline
{
    /// <summary>
    /// The behaviour / data of the position operation.
    /// 
    /// <see cref="UITPositionClip"/>
    /// </summary>
    [Serializable]
    public class UITPositionBehaviour : UITBehaviour
    {
        public override UsageHints Hints => UsageHints.DynamicTransform;

        public Vector2 Position;
    }
}