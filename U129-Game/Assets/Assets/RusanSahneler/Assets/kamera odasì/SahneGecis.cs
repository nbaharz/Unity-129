using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SahneGecis : MonoBehaviour
{
    
    public Animator animator;
    private int levelToLoad;

    private void Update()
    {
        
    }
    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }
}
