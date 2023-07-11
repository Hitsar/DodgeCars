using UnityEngine;

namespace Player
{
    public class PlayerVFX
    {
        private Animator _animator;
        
        public PlayerVFX(Animator animator, PlayerHealth playerHealth)
        {
            _animator = animator;
            playerHealth.OnDie += OnDie;
            playerHealth.OnRevival += OnRevival;
        }

        private void OnDie() => _animator.SetTrigger("Die");

        private void OnRevival() => _animator.SetTrigger("Revival");

        public void OnMove() => _animator.SetTrigger("Move");
    }
}