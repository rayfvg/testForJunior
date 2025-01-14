using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private bool canMove = true;

    private void Update()
    {
        if (!canMove)
            return;

        if (Input.GetMouseButton(0)) 
        {
            float moveDelta = Input.GetAxis("Mouse X") * moveSpeed * Time.deltaTime;

            transform.position += new Vector3(moveDelta, 0, 0);
        }
    }

    public void SetMovementAllowed(bool isAllowed) => canMove = isAllowed;
}