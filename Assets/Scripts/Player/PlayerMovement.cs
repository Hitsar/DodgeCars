using System.Collections;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Inject]
        private void Init(InputSystem inputSystem)
        {
            inputSystem.Player.MoveForward.performed += _ => Move(Vector3.forward);
            inputSystem.Player.MoveBack.performed += _ => Move(Vector3.back);
            inputSystem.Player.MoveLeft.performed += _ => Move(Vector3.left);
            inputSystem.Player.MoveRight.performed += _ => Move(Vector3.right);
            inputSystem.Player.Enable();
        }

        private void Move(Vector3 direction)
        {
            transform.DOMove(transform.position + direction, 0.2f);
            
            if (direction.z == 0)
                transform.rotation = Quaternion.Euler(0, direction.x * 90, 0);
            else if (direction.z != 0)
                transform.rotation = direction.z == 1 ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, direction.z * 180, 0);
        }
    }
}
