using CodeBase.Pickupables.Effects;
using UnityEngine;

namespace CodeBase.Pickupables.Coins
{
    public class Pickupable : MonoBehaviour
    {
        public IEffectStrategy EffectStrategy { get; set; } = new BoostSpeedEffect();

        private bool _pickedUp; 

        private void OnTriggerEnter(Collider other)
        {
            if (!_pickedUp) 
                PickUp();
        }

        private void PickUp()
        {
            if (_pickedUp || EffectStrategy.IsExecuting)
                return;
            
            _pickedUp = true;
            gameObject.SetActive(false);
            EffectStrategy.Execute();
        }
    }
}
