using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandlePlayerCollision : MonoBehaviour
{
    [SerializeField]
    private float timeToReset;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with " + other.gameObject.name);
            PlayerMovement movementScript = other.GetComponent<PlayerMovement>();
            HumanMovement humanMovementScript = GetComponent<HumanMovement>();

            if(movementScript != null && humanMovementScript != null)
            {
                movementScript.enabled = false;
                humanMovementScript.enabled = false;
                Debug.Log("Disabled Movement");
                StartCoroutine(ResetLevelAfterDelay(timeToReset));
            }
            else
            {
                Debug.LogWarning("Player Movement Script Not Found");
            }
        }
    }

    private IEnumerator ResetLevelAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
