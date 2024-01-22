using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Speed and keycodes to move
    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private KeyCode moveUpKey = KeyCode.W;

    [SerializeField]
    private KeyCode moveDownKey = KeyCode.S;

    [SerializeField]
    private KeyCode moveRightKey = KeyCode.D;
    [SerializeField]
    private KeyCode moveLeftKey = KeyCode.A;

    // Objects that hold the max/min of x/y
    [Tooltip("Maximum X object")]
    [SerializeField]
    private GameObject maxXObject;

    [Tooltip("Minimum X object")]
    [SerializeField]
    private GameObject minXObject;

    [Tooltip("Maximum Y object")]
    [SerializeField]
    private GameObject maxYObject;

    [Tooltip("Minimum Y object")]
    [SerializeField]
    private GameObject minYObject;

    void Update()
    {
        // Move Up
        if (Input.GetKey(moveUpKey))
        {
            if(transform.position.y > maxYObject.transform.position.y)
            {
                return;
            }
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }

        // Move Down
        if (Input.GetKey(moveDownKey))
        {
            if(transform.position.y < minYObject.transform.position.y)
            {
                return;
            }
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }

        // Move Right
        if (Input.GetKey(moveRightKey))
        {
            if(transform.position.x > maxXObject.transform.position.x)
            {
                return;
            }
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            FlipCharacter(Vector3.right);
        }

        // Move Left
        if (Input.GetKey(moveLeftKey))
        {
            if(transform.position.x < minXObject.transform.position.x)
            {
                return;
            }

            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            FlipCharacter(Vector3.left);

        }

    }
     void FlipCharacter(Vector3 direction)
    {
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); // Face right
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); // Face left
        }
    }
}