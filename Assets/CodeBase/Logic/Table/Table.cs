using CodeBase.Infrastructure.Services.Selector;
using CodeBase.Logic.Actors.Actors;
using UnityEngine;

namespace CodeBase.Logic.Table
{
    public class Table : MonoBehaviour, ISelectable
    {
        public Transform ThisTransform { get; private set; }
        
        
        [SerializeField] private Chair _chairLeft;
        [SerializeField] private Chair _chairRight;

        private bool _isFree;

        private void Start()
        {
            ThisTransform = GetComponent<Transform>();
        }


        public void Selected(CatAwaiter catAwaiter)
        {
            
        }

        public void Unselect()
        {
            
        }
    }
}