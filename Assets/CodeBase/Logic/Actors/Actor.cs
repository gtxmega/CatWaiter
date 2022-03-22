using UnityEngine;

namespace CodeBase.Logic.Actors
{
    public class Actor : MonoBehaviour
    {
        public Transform ThisTransform { get; private set; }

        private void Start()
        {
            ThisTransform = GetComponent<Transform>();
        }
    }
}