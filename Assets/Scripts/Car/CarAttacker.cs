using Player;
using UnityEngine;

namespace Car
{
    public class CarAttacker : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out PlayerHealth playerHealth)) 
                playerHealth.Die();
        }
    }
}