using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace UITTimeline
{
    /// <summary>
    /// A UI Toolkit timeline clip to change the scale.
    ///
    /// <see cref="UITScaleBehaviour"/>
    /// </summary>
    [Serializable]
    public class UITScaleClip : PlayableAsset, ITimelineClipAsset
    {
        public UITScaleBehaviour _template = new();

        public ClipCaps clipCaps => ClipCaps.All;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<UITScaleBehaviour>.Create(graph, _template);
        }
    }
}