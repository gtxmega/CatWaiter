using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Infrastructure.Services.Selector;
using CodeBase.Logic.Actors.Actors;
using UnityEngine;

namespace CodeBase.Logic.Table
{
    public class LittleTable : MonoBehaviour, ISelectable
    {
        public Transform ThisTransform { get; private set; }

        [SerializeField] private float _approachDistance;
        
        [Header("Chair parameters")]
        [SerializeField] private Chair[] _chairs;

        private bool _isFree;
        private List<Visitor> _visitors = new List<Visitor>();
        
        private Coroutine _sitDownProgress;
        
        
        private void Start()
        {
            ThisTransform = GetComponent<Transform>();
            _isFree = true;
        }


        public bool IsFree()
        {
            return _isFree;
        }

        public void GoSitDownAtTable(Visitor visitor)
        {
            if(_isFree == false)
                return;
            
            visitor.SetDestination(ThisTransform.position);
            
            _visitors.Add(visitor);
            _isFree = false;

            if(_sitDownProgress == null)
                _sitDownProgress = StartCoroutine(SitDownProgress());
        }
        
        public void GoSitDownAtTable(Visitor[] visitor)
        {
            if(_isFree == false)
                return;

            if(visitor == null || visitor.Length == 0)
                return;
            
            _visitors.AddRange(visitor);
            _isFree = false;
            
            for (int i = 0; i < visitor.Length; i++)
            {
                _visitors[i].SetDestination(ThisTransform.position);
            }
            
            if(_sitDownProgress == null)
                _sitDownProgress = StartCoroutine(SitDownProgress());
        }

        public void Selected(CatAwaiter catAwaiter)
        {
            
        }

        public void Unselect()
        {
            
        }

        private Chair GetFreeChair()
        {
            if (_chairs != null && _chairs.Length > 0)
            {
                for (int i = 0; i < _chairs.Length; i++)
                {
                    if (_chairs[i].IsFree)
                        return _chairs[i];
                }
            }

            throw new NullReferenceException(name);
        }
        
        private IEnumerator SitDownProgress()
        {

            while (_visitors.Count > 0)
            {
                for (int i = 0; i < _visitors.Count; ++i)
                {
                     float sqrDistance  = (_visitors[i].ThisTransform.position - ThisTransform.position).sqrMagnitude;
                     
                     if (sqrDistance <= _approachDistance)
                     {
                         Chair chair = GetFreeChair();
                         chair.SitDownVisitor(_visitors[i]);
                         
                         _visitors[i].SetChair(chair);
                         _visitors[i].SitDownOnLittleTable(this);
                         
                         _visitors.RemoveAt(i);
                         i--;
                     }
                }
                
                yield return null;
            }
            
            _sitDownProgress = null;
        }
        
    }
}