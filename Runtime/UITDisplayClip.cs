using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace UITTimeline
{
    /// <summary>
    /// A UI Toolkit timeline clip to set a VisualElement ti Display.None or Display.Flex.
    ///
    /// <see cref="UITClassBehaviour"/>
    /// </summary>
    [Serializable]
    public class UITDisplayClip : PlayableAsset, ITimelineClipAsset
    {
        public UITDisplayBehaviour _template = new();

        public ClipCaps clipCaps => ClipCaps.None;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<UITDisplayBehaviour>.Create(graph, _template);
        }
    }
}