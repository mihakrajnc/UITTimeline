using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace UITTimeline
{
    /// <summary>
    /// A UI Toolkit timeline clip to change the opacity.
    ///
    /// <see cref="UITOpacityBehaviour"/>
    /// </summary>
    [Serializable]
    public class UITOpacityClip : PlayableAsset, ITimelineClipAsset
    {
        public UITOpacityBehaviour _template = new();

        public ClipCaps clipCaps => ClipCaps.All;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<UITOpacityBehaviour>.Create(graph, _template);
        }
    }
}