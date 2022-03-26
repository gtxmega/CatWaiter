using CodeBase.Infrastructure.Services.QueueVisitors;
using CodeBase.Infrastructure.Services.Selector;
using CodeBase.Logic.Actors.Actors;
using CodeBase.Logic.Table;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.DistributionVisitors
{
    public class DistributionVisitors : MonoBehaviour
    {
        private Visitor _currentVisitor;
        private ISelectorService _selectorService;
        private IQueueVisitors _queueVisitors;

        
        [Inject]
        private void Construct(ISelectorService selectorService, IQueueVisitors queueVisitors)
        {
            _selectorService = selectorService;
            _queueVisitors = queueVisitors;
        }

        private void Start()
        {
            _selectorService.OnSelect += OnSelectActor;
        }

        private void OnSelectActor(ISelectable selectable, GameObject selectableObject)
        {
            if (_currentVisitor == null)
            {
                if (selectableObject.TryGetComponent<Visitor>(out Visitor visitor))
                {
                    if (_queueVisitors.IsFirstInQueue(visitor))
                    {
                        _currentVisitor = visitor;
                    }
                }
            }else
            {
                if (selectableObject.TryGetComponent<LittleTable>(out LittleTable table))
                {
                    if (table.IsFree())
                    {
                        _queueVisitors.DequeueVisitor();
                        table.GoSitDownAtTable(_currentVisitor);

                        _currentVisitor = null;
                    }
                }
            }
        }
    }
}