using UnityEngine;

namespace OL
{
#pragma warning disable 0649
    public class FullImage : MonoBehaviour
    {
        [SerializeField]
        SpriteRenderer FullImageObj;
        [SerializeField]
        Transform FullImageObjTransform;

        private void Awake()
        {
            TT.FitSpriteToCamera(FullImageObjTransform, FullImageObj);
        }
    }
}
