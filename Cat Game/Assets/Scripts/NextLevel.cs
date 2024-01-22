using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    LevelChangerScript scriptComponent;

    private void Start() 
    {
        GameObject levelChanger = GameObject.Find("Canvas");
        if(levelChanger!= null)
        {
            scriptComponent = levelChanger.GetComponent<LevelChangerScript>();
            if(scriptComponent == null)
            {
                Debug.Log("Error finding script");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
             
            Debug.Log("New Level Loaded");
            scriptComponent.FadeToLevel();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Collision exited with: " + other.gameObject.name);
    }
}