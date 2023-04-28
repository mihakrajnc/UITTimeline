using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;

namespace UITTimeline
{
    /// <summary>
    /// A mixer for mixing / blending together UIT clips (behaviours).
    /// </summary>
    [Serializable]
    public class UITMixerBehaviour : PlayableBehaviour
    {
        public List<VisualElement> Elements;

        public override void OnGraphStart(Playable playable)
        {
            // Initialize clips
            for (int i = 0; i < playable.GetInputCount(); i++)
            {
                var playableInput = (ScriptPlayable<UITBehaviour>) playable.GetInput(i);
                var behaviour = playableInput.GetBehaviour();

                switch (behaviour)
                {
                    case UITClassBehaviour cls:
                        // Class behaviour handles it's own logic - doesn't use a mixer
                        cls.Elements = Elements;
                        break;
                    case UITDisplayBehaviour dsp:
                        dsp.Elements = Elements;
                        break;
                    case UITVisibilityBehaviour vis:
                        vis.Elements = Elements;
                        break;
                }
            }
        }

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            var position = new Vector2();
            var rotation = 0f;
            var scale = new Vector2(1f, 1f);
            var opacity = 1f;

            for (int i = 0; i < playable.GetInputCount(); i++)
            {
                var playableInput = (ScriptPlayable<UITBehaviour>) playable.GetInput(i);
                var behaviour = playableInput.GetBehaviour();

                switch (behaviour)
                {
                    case UITPositionBehaviour trs:
                        position += trs.Position * playable.GetInputWeight(i);
                        break;
                    case UITScaleBehaviour scl:
                        scale += scl.Scale * playable.GetInputWeight(i);
                        break;
                    case UITRotationBehaviour rot:
                        rotation += rot.Rotation * playable.GetInputWeight(i);
                        break;
                    case UITOpacityBehaviour op:
                        opacity += op.Opacity * playable.GetInputWeight(i);
                        break;
                }
            }

            foreach (var e in Elements)
            {
                e.transform.position = position;
                e.transform.scale = scale;
                e.transform.rotation = Quaternion.Euler(0, 0, rotation);
                e.style.opacity = opacity;
            }
        }
    }
}