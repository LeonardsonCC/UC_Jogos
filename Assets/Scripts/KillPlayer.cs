using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "kill player") {
            animator.Play("morrendo");
            Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length); 
        }
    }
}
