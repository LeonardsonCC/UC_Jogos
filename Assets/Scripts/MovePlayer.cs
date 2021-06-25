using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    public float velocidade = 10f;
    public float forcaPulo = 15f;
    private Rigidbody2D rigi;
    private float pulos = 0f;
    private float maxPulos = 2f;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        Pular();
    }

    void Mover() {
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movimento * Time.deltaTime * velocidade;

        if (Input.GetAxis("Horizontal") > 0) {
            animator.SetBool("correndo", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (Input.GetAxis("Horizontal") < 0) {
            animator.SetBool("correndo", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if (Input.GetAxis("Horizontal") == 0) {
            animator.SetBool("correndo", false);
        }
    }

    void Pular() {
        if (Input.GetKeyDown(KeyCode.Space) && pulos < maxPulos) 
        {
            animator.SetBool("pulando", true);
            pulos++;
            rigi.AddForce(new Vector2(0f, forcaPulo), ForceMode2D.Impulse);
            if (pulos == 2) {
                animator.SetBool("pulando duplo", true);
            } 
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.layer == 8) {
            pulos = 0;
        }
        animator.SetBool("pulando duplo", false);
        animator.SetBool("pulando", false);
    }
    
}
