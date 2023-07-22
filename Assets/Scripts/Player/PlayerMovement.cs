using DG.Tweening;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private PlayerVFX _vfx;
        private InputSystem _inputSystem;
        private float _time = 0.2f;

        private void Start()
        {
            Finish.Finish finish = FindObjectOfType<Finish.Finish>();
            finish.OnFinished += OnDisable;
            
            _vfx = new PlayerVFX(GetComponent<Animator>(), GetComponent<PlayerHealth>(), finish);

            _inputSystem = new InputSystem();
            _inputSystem.Player.MoveForward.performed += _ => Move(Vector3.forward);
            _inputSystem.Player.MoveLeft.performed += _ => Move(Vector3.left);
            _inputSystem.Player.MoveRight.performed += _ => Move(Vector3.right);
            _inputSystem.Player.Enable();
            
            GetComponent<PlayerHealth>().OnDie += OnDisable;
        }

        private void FixedUpdate() => _time -= Time.fixedDeltaTime;

        private void Move(Vector3 direction)
        {
            if (_time > 0 || transform.position.x + direction.x < -2 || transform.position.x + direction.x > 2) return;
            
            transform.DOMove(transform.position + direction, 0.2f);
            
            if (direction.z == 0)
                transform.rotation = Quaternion.Euler(0, direction.x * 90, 0);
            else if (direction.z != 0)
                transform.rotation = direction.z == 1 ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, direction.z * 180, 0);
            
            _vfx.OnMove();
            _time = 0.2f;
        }

        private void OnDisable() => _inputSystem.Player.Disable();
    }
}
