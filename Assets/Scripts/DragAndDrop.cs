using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private BackgroundMove _backGroundMove;
    [SerializeField] private Vector3 _maxScale;

    private Vector3 _offset;
    private bool _isDragging = false;
    private Rigidbody _rigidbody;

    private Vector3 _startScale;

    private void Awake() => _rigidbody = GetComponent<Rigidbody>();

    private void Start() => _startScale = transform.localScale;


    private void OnMouseDown()
    {
        _isDragging = true;
        _rigidbody.isKinematic = true;
        _backGroundMove.SetMovementAllowed(false);
        _offset = transform.position - GetMouseWorldPosition();
        UpScale();
    }

    private void OnMouseDrag()
    {
        if (_isDragging)
        {
            Vector3 mousePosition = GetMouseWorldPosition() + _offset;
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }
    }

    private void OnMouseUp()
    {
        _isDragging = false;
        _rigidbody.isKinematic = false;
        _backGroundMove.SetMovementAllowed(true);
        StartScale();
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }

    private void UpScale() => transform.localScale = _maxScale;

    private void StartScale() => transform.localScale = _startScale;
}