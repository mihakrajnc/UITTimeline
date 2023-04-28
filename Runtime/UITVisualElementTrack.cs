using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

namespace UITTimeline
{
    /// <summary>
    /// A track supporting animation for UIDocuments / UIToolkit. A single track is responsible for a single query / element group.
    /// </summary>
    [Serializable]
    [TrackClipType(typeof(UITScaleClip)), TrackClipType(typeof(UITPositionClip)),
     TrackClipType(typeof(UITRotationClip)), TrackClipType(typeof(UITClassClip)),
     TrackClipType(typeof(UITOpacityClip)), TrackClipType(typeof(UITVisibilityClip)),
     TrackClipType(typeof(UITDisplayClip))]
    [TrackColor(0.259f, 0.529f, 0.961f)]
    public class UITVisualElementTrack : TrackAsset, ILayerable
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            var mixer = ScriptPlayable<UITMixerBehaviour>.Create(graph, inputCount);
            mixer.GetBehaviour().Elements =
                QueryElements(name, go.GetComponentInParent<UIDocument>().rootVisualElement);
            return mixer;
        }

        public Playable CreateLayerMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            return Playable.Null;
        }

        private List<VisualElement> QueryElements(string queryPath, VisualElement root)
        {
            var query = root.Query();
            var results = new List<VisualElement>(1);

            var path = queryPath.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < path.Length; i++)
            {
                var part = path[i];

                if (part.StartsWith('#'))
                {
                    if (part.IndexOf('#') != part.LastIndexOf('#'))
                    {
                        Debug.LogError($"Invalid pattern (only one Name(#) selector is allowed per part): {part}");
                        return results;
                    }

                    query.Name(part.Replace("#", ""));
                }
                else if (part.StartsWith('.'))
                {
                    if (part.Contains('#'))
                    {
                        Debug.LogError(
                            $"Invalid pattern (no mixing of Names(#) and Classes(#) in a part). Did you forget a space?: {part}");
                        return results;
                    }

                    var classes = part.Split('.', StringSplitOptions.RemoveEmptyEntries);
                    foreach (var @class in classes)
                    {
                        query.Class(@class);
                    }
                }
                else
                {
                    Debug.LogError($"Invalid pattern (only Name(#) and Class(.) is allowed): {part}");
                }

                if (i < path.Length - 1)
                {
                    query = query.Children<VisualElement>();
                }
            }

            return query.Build().ToList();
        }
    }
}