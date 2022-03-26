using UnityEngine;

namespace CodeBase.Infrastructure.Services.UIFollow
{
    public interface IUIFollowService
    {
        bool TryAddUIFollowObject(RectTransform who, Transform target, Vector2 offset);
        RectTransform DisableFollowAndReturn(Transform target);
    }
}