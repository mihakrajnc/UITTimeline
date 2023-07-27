using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace UITTimeline
{
    /// <summary>
    /// The behaviour / data of the background tint change.
    /// 
    /// <see cref="UITDisplayClip"/>
    /// </summary>
    [Serializable]
    public class UITBackgroundTintBehaviour : UITBehaviour
    {
        public override UsageHints Hints => UsageHints.DynamicColor;

        public Color Color = Color.white;
    }
}