using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAnimator : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private bool Pausepush;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Pausepush == false)
        {
            animator.SetBool("Pause", true);
            Pausepush = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && Pausepush == true)
        {
            animator.SetBool("Pause", false);
            Pausepush = false;
        }

        animator.SetBool("Pause", false);
    }
}
