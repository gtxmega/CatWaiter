using CodeBase.Logic.Actors.Actors;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Selector
{
    public class SelectorService : MonoBehaviour
    {
        [SerializeField] private CatAwaiter _catAwaiter;
        [SerializeField] private float _maxDistance = 100.0f;
        [SerializeField] private LayerMask _layersSelecting;

        private ISelectable _currentSelect;

        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray rayFromCamera = _camera.ScreenPointToRay(Input.mousePosition);
                
                if (Physics.Raycast(rayFromCamera, out var hitResult, _maxDistance, _layersSelecting))
                {
                    if (hitResult.collider.TryGetComponent<ISelectable>(out var selectable))
                    {
                        if(_currentSelect != null) _currentSelect.Unselect();

                        _currentSelect = selectable;
                        _currentSelect.Selected(_catAwaiter);
                    }
                }
            }
        }
    }
}