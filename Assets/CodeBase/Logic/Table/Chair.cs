using System.Collections;
using CodeBase.Logic.Actors.Actors;
using UnityEngine;

namespace CodeBase.Logic.Table
{
    public class Chair : MonoBehaviour
    {
        [SerializeField] private float _sitDownDistance;
        
        public Transform ThisTransform { get; private set; }
        public bool IsFree => _isFree;

        private bool _isFree;
        private Visitor _currentVisitor;
        private Coroutine _sitDownCoroutine;

        private void Start()
        {
            ThisTransform = GetComponent<Transform>();
            _isFree = true;
            _sitDownDistance *= _sitDownDistance;
        }

        public void SitDownVisitor(Visitor visitor)
        {
            _currentVisitor = visitor;
            _isFree = false;

            if(_sitDownCoroutine == null)
                _sitDownCoroutine = StartCoroutine(SitDownProgress());
        }

        private IEnumerator SitDownProgress()
        {
            float sqrDistance = 0.0f;
            
            do
            {
                sqrDistance = (ThisTransform.position - _currentVisitor.ThisTransform.position).sqrMagnitude;
                yield return null;
            } while (sqrDistance > _sitDownDistance);
            
            _currentVisitor.SitDownOnChair(this);
            _sitDownCoroutine = null;
        }
    }
}