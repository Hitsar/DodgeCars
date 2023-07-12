using System;
using Player;
using UnityEngine;

namespace Finish
{
    public class Finish : MonoBehaviour
    {
        public event Action OnFinished;

        private void OnTriggerEnter(Collider other) { if (!other.gameObject.TryGetComponent(out PlayerMovement _)) OnFinished?.Invoke(); }
    }
}