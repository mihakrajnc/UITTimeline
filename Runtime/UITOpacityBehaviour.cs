using System;
using UnityEngine;

namespace UITTimeline
{
    /// <summary>
    /// The behaviour / data of the opacity operation.
    /// 
    /// <see cref="UITOpacityClip"/>
    /// </summary>
    [Serializable]
    public class UITOpacityBehaviour : UITBehaviour
    {
        [Range(-1, 0)] public float Opacity;
    }
}