using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace UITTimeline
{
    /// <summary>
    /// A UI Toolkit timeline clip to enable a class on a VisualElement.
    ///
    /// <see cref="UITClassBehaviour"/>
    /// </summary>
    [Serializable]
    public class UITClassClip : PlayableAsset, ITimelineClipAsset
    {
        public UITClassBehaviour _template = new();

        public ClipCaps clipCaps => ClipCaps.None;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<UITClassBehaviour>.Create(graph, _template);
        }
    }
}