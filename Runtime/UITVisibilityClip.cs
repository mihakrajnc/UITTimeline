using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace UITTimeline
{
    /// <summary>
    /// A UI Toolkit timeline clip to make a VisualElement visible or invisible.
    ///
    /// <see cref="UITClassBehaviour"/>
    /// </summary>
    [Serializable]
    public class UITVisibilityClip : PlayableAsset, ITimelineClipAsset
    {
        public UITVisibilityBehaviour _template = new();

        public ClipCaps clipCaps => ClipCaps.None;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<UITVisibilityBehaviour>.Create(graph, _template);
        }
    }
}