using UnityEngine;

namespace Car
{
    public class CarMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void FixedUpdate() => transform.Translate(Vector3.left * (_speed * Time.fixedDeltaTime), Space.World);
    }
}