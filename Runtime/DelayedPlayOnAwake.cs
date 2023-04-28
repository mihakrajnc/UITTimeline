using UnityEngine;
using UnityEngine.Playables;

namespace UITTimeline
{
    /// <summary>
    /// Delays the play call of the <see cref="PlayableDirector"/> until the
    /// first frame (I.E. After UIDocument is initialized).
    /// </summary>
    [RequireComponent(typeof(PlayableDirector))]
    public class DelayedPlayOnAwake : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<PlayableDirector>().Play();
        }
    }
}