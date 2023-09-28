using CodeBase.Pickupables.Effects;
using UnityEngine;

namespace CodeBase.Pickupables.Coins
{
    /// <summary>
    /// It's a facade on the pickupable object
    /// For now it's just controlling picking up the object
    /// </summary>
    public class Pickupable : MonoBehaviour
    {
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
            gameObject.SetActive(false);
            EffectStrategy.Execute();
        }
    }
}
