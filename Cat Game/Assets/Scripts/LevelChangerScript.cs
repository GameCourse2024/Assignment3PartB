using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangerScript : MonoBehaviour
{

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private static int levelToLoad;
    
    private static int keyTimesPressed = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            keyTimesPressed++;
            if (keyTimesPressed == 1)
            {
                FadeToLevel();
            }
        }
    }

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    private void OnFadeComplete()
    {
        levelToLoad++;
        SceneManager.LoadScene(levelToLoad);
    }

}
