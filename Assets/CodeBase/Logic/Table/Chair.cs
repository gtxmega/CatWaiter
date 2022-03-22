using UnityEngine;

namespace CodeBase.Logic.Table
{
    public class Chair : MonoBehaviour
    {
        public Transform ThisTransform { get; private set; }

        private void Start()
        {
            ThisTransform = GetComponent<Transform>();
        }
    }
}