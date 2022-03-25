using System;
using CodeBase.Logic.Actors.Actors;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Selector
{
    public class SelectorService : MonoBehaviour, ISelectorService
    {
        public event Action<ISelectable, GameObject> OnSelect;
        public event Action<ISelectable> OnUnselect;
    
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
                        if (_currentSelect != null)
                        {
                            _currentSelect.Unselect();
                            OnUnselect?.Invoke(_currentSelect);
                        }
                        
                        _currentSelect = selectable;
                        _currentSelect.Selected(_catAwaiter);
                        OnSelect?.Invoke(_currentSelect, hitResult.collider.gameObject);
                    }
                }
            }
        }

        public ISelectable GetCurrentSelecting()
        {
            return _currentSelect;
        }
    }
}