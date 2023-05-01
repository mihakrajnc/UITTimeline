using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;

namespace UITTimeline
{
    /// <summary>
    /// The behaviour / data of the class add / remove operation.
    /// 
    /// <see cref="UITClassClip"/>
    /// </summary>
    [Serializable]
    public class UITClassBehaviour : UITBehaviour
    {
        public string ClassName;

        [HideInInspector] public List<VisualElement> Elements;

        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            if (Elements == null || string.IsNullOrEmpty(ClassName)) return;
            foreach (var e in Elements)
            {
                e.AddToClassList(ClassName);
            }
        }

        public override void OnBehaviourPause(Playable playable, FrameData info)
        {
            if (Elements == null || string.IsNullOrEmpty(ClassName)) return;
            foreach (var e in Elements)
            {
                e.RemoveFromClassList(ClassName);
            }
        }
    }
}