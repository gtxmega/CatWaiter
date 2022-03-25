using System;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Selector
{
    public interface ISelectorService
    {
        event Action<ISelectable, GameObject> OnSelect;
        event Action<ISelectable> OnUnselect;
        ISelectable GetCurrentSelecting();
    }
}