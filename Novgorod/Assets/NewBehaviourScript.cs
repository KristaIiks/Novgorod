using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private InputActionReference _move;
    [SerializeField] private InputActionReference _up;

    private Rigidbody _rb;

    private void OnValidate()
    {
        _rb ??= GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector2 _horizontalValue = -_move.action.ReadValue<Vector2>();
        Vector2 _verticalValue = _up.action.ReadValue<Vector2>();

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(_horizontalValue.x * 15f, 0f, _horizontalValue.y * 15f)), .1f);

        _rb.velocity = new Vector3(-_horizontalValue.y, _verticalValue.y, _horizontalValue.x);
    }

}
