using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerVFX
    {
        private readonly Animator _animator;
        
        public PlayerVFX(Animator animator, PlayerHealth playerHealth, Finish.Finish finish)
        {
            _animator = animator;
            playerHealth.OnDie += OnDie;
            playerHealth.OnRevival += OnRevival;
            finish.OnFinished += OnFinished;
        }

        private void OnDie()
        {
            _animator.SetTrigger("Die");
            SceneManager.LoadScene(0);
        }

        private void OnRevival() => _animator.SetTrigger("Revival");

        private void OnFinished() => _animator.SetTrigger("Finish");
        
        public void OnMove() => _animator.SetTrigger("Move");
    }
}