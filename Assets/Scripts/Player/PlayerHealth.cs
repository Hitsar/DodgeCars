using System;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public event Action OnDie;
        public event Action OnRevival;
            
        public void Die() => OnDie?.Invoke();

        public void Revival() => OnRevival?.Invoke();
    }
}