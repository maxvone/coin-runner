using UnityEngine;

public class MovementAreaMove : MonoBehaviour
{
    private float _speed = 4;
    private void Update() => 
        transform.position += -transform.forward * _speed * Time.deltaTime;

}
