using System;
using CodeBase.Infrastructure.Services.Selector;
using CodeBase.Logic.Actors.Actors;
using UnityEngine;

namespace CodeBase.Logic.Table
{
    public class Table : MonoBehaviour, ISelectable
    {
        public Transform ThisTransform { get; private set; }
        
        [Header("Chair parameters")]
        [SerializeField] private Chair _chairLeft;
        [SerializeField] private Chair _chairRight;

        private bool _isFree;

        private void Start()
        {
            ThisTransform = GetComponent<Transform>();

            _isFree = true;
        }


        public bool IsFree()
        {
            return _isFree;
        }

        public void GoToTable(Visitor visitor)
        {
            if(_isFree == false)
                return;

            Chair freeChair = GetFreeChair();
            freeChair.SitDownVisitor(visitor);
            _isFree = false;
        }

        public void Selected(CatAwaiter catAwaiter)
        {
            
        }

        public void Unselect()
        {
            
        }

        private Chair GetFreeChair()
        {
            if (_chairLeft.IsFree)
                return _chairLeft;

            if (_chairRight.IsFree)
                return _chairRight;

            throw new NullReferenceException(name);
        }
        
    }
}