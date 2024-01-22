using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class HumanMovement : MonoBehaviour
{
    [Tooltip("Movement Range")]
    [SerializeField]
    float movementRange = 2f; // Total movement range of the linear motion

    [Tooltip("Movement Speed")]
    [SerializeField]
    float speed = 1f;   // Speed of linear motion

    [Tooltip("Human Searches Up/Down, if not then Left/Right")]
    [SerializeField]
    private bool upDown;
    private float x;
    private float y;


    private UnityEngine.Vector3 startingSpot; // Initial position of the object

    // Start is called before the first frame update
    void Start()
    {
        // Set the object's initial position
        startingSpot = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(upDown)
        {
            moveUpDown();
        }
        else
        {
            moveSideToSide();
        }
    }

    private void moveUpDown()
    {
        

        y = transform.position.y;
        float verticalMovement = Mathf.PingPong(Time.time * speed, movementRange);
        transform.position = startingSpot + new UnityEngine.Vector3(0, verticalMovement, 0);

        // Check if the player is moving up or down
        if (y - transform.position.y > 0)
        {
            transform.rotation = UnityEngine.Quaternion.Euler(0f, 0f, 0f); // No rotation
        }
        else
        {
            transform.rotation = UnityEngine.Quaternion.Euler(180f, 0f, 0f); // 180 degrees rotation on the X axis
        }

    }

    private void moveSideToSide()
    {
        x = transform.position.x;
        float linearMovement = Mathf.PingPong(Time.time * speed, movementRange);
        transform.position = startingSpot + new UnityEngine.Vector3(linearMovement, 0, 0);

        // we calculate if he is moving to the right or to the left
        if(x-transform.position.x > 0)
        {
            // Added the unityengine. becuase the quaternion was ambiguois
            transform.rotation = UnityEngine.Quaternion.Euler(0f,180f,0f); 
        }
        else
        {
            transform.rotation = UnityEngine.Quaternion.Euler(0f,0f,0f); 
        }
    }
}
