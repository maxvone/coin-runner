using DG.Tweening;
using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] public Animator _animator;

        private static readonly int RunHash = Animator.StringToHash("Run");
        private static readonly int FlyHash = Animator.StringToHash("Fly");
        private static readonly int ReturnToRunHash = Animator.StringToHash("ReturnToRun");
        
        private void Update()
        {
            _animator.SetFloat(RunHash, _characterController.velocity.magnitude, 0.1f, Time.deltaTime);
        }

        public void PlayFly()
        {
            _animator.SetTrigger(FlyHash);
            
            Transform animatorTransform = _animator.transform;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(animatorTransform.DOLocalMove(new Vector3(0, 0.1f, 0), 0.5f));
            sequence.Join(animatorTransform.DOLocalRotate(new Vector3(70, 0, 0), 0.5f));
            
        }
        
        public void ReturnToMove()
        {
            _animator.SetTrigger(ReturnToRunHash);
            
            Transform animatorTransform = _animator.transform;
            Sequence sequence = DOTween.Sequence();
            
            sequence.Append(animatorTransform.DOLocalMove(new Vector3(0, -0.9f), 0.5f));
            sequence.Join(animatorTransform.DOLocalRotate(Vector3.zero, 0.5f));
            
        }
    }
}