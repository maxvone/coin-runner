using CodeBase.Pickupables.Effects;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace CodeBase.Pickupables.Coins
{
    /// <summary>
    /// It's a facade on the pickupable object
    /// For now it's just controlling picking up the object
    /// </summary>
    public class Pickupable : MonoBehaviour
    {
        [SerializeField] private TMP_Text _effectText;
        [SerializeField] private MeshRenderer _meshRenderer;
        public IEffectStrategy EffectStrategy { get; set; }

        private bool _pickedUp; 

        private void OnTriggerEnter(Collider other)
        {
            if (!_pickedUp && EffectStrategy != null) 
                PickUp();
        }

        private void PickUp()
        {
            if (_pickedUp)
                return;
            
            _pickedUp = true;
            _meshRenderer.enabled = false;
            EffectStrategy.Execute();
            EnableTextEffect();
        }

        private void EnableTextEffect()
        {
            _effectText.transform.DOLocalMove(Vector3.zero, 0);
            _effectText.DOColor(new Color(255, 255, 255, 0), 0);
            _effectText.text = EffectStrategy.Text;

            Sequence sequence = DOTween.Sequence();
            sequence.Append(_effectText.transform.DOLocalMove(new Vector3(0, 1.5f, 0), 0.5f));
            sequence.Join(_effectText.DOColor(new Color(255, 255, 255, 255), 0.5f));
            sequence.Append(_effectText.DOColor(new Color(255, 255, 255, 0), 0.2f));
        }
    }
}
