using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace UITTimeline
{
    /// <summary>
    /// A UI Toolkit timeline clip to change the background image tint of an element.
    ///
    /// <see cref="UITBackgroundTintBehaviour"/>
    /// </summary>
    [Serializable]
    public class UITBackgroundTintClip : PlayableAsset, ITimelineClipAsset
    {
        public UITBackgroundTintBehaviour _template = new();

        public ClipCaps clipCaps => ClipCaps.All;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<UITBackgroundTintBehaviour>.Create(graph, _template);
        }
    }
}