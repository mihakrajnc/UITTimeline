using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace UITTimeline
{
    /// <summary>
    /// A UI Toolkit timeline clip to change the rotation.
    ///
    /// <see cref="UITRotationBehaviour"/>
    /// </summary>
    [Serializable]
    public class UITRotationClip : PlayableAsset, ITimelineClipAsset
    {
        public UITRotationBehaviour _template = new();

        public ClipCaps clipCaps => ClipCaps.All;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<UITRotationBehaviour>.Create(graph, _template);
        }
    }
}