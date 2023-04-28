using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace UITTimeline
{
    /// <summary>
    /// A UI Toolkit timeline clip to change the position.
    ///
    /// <see cref="UITPositionBehaviour"/>
    /// </summary>
    [Serializable]
    public class UITPositionClip : PlayableAsset, ITimelineClipAsset
    {
        public UITPositionBehaviour _template = new();

        public ClipCaps clipCaps => ClipCaps.All;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<UITPositionBehaviour>.Create(graph, _template);
        }
    }
}