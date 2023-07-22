using DG.Tweening;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Animations
{
    public class LoseMenuAnimator : MonoBehaviour
    {
        [SerializeField] private Image _panel, _button;

        private void Start() => FindObjectOfType<PlayerHealth>().OnDie += Enable;

        private void Enable()
        {
            _panel.DOFade(0.6f, 1);
            _button.transform.DOMoveY(350, 0.8f).SetEase(Ease.OutElastic);
        }
    }
}