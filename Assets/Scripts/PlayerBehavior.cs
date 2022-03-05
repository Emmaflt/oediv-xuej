using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    private Animator anim;
    private float x, y;
    public float speed = 10f;
    private bool isWalking;

    public GameObject pause_menu = null;

    bool wasMovingVertical = true;
    bool wasMovingHorizontal = false;

    Rigidbody2D rb2D;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        //renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //OUVRIR / FERMER MENU PAUSE
        {
            pause_menu.SetActive(!pause_menu.activeSelf);
        }

        if (pause_menu.activeSelf)
        {
            rb2D.velocity = Vector2.zero; //pour s'arrêter dès que le joueur cesse de bouger
            return;
        }


        //MOUVEMENTS ET ANIMATION DES MOUVEMENTS -------------------------------------------------------------------------------------------------

        x = Input.GetAxis("Horizontal"); //équivalent de X
        y = Input.GetAxis("Vertical"); // équivalent de Y

        //ANIMATION IDLE EN FONCTION DE L'ORIENTATION
        if(x > 0 || x < 0 || y > 0 || y < 0)
        {
            anim.SetFloat("LX", x);
            anim.SetFloat("LY", y);
        }

        //ALGORITHME DE DÉPLACEMENTS (SANS DIAGONALE)
        bool isMovingHorizontal = Mathf.Abs(x) > 0.5f;
        bool isMovingVertical = Mathf.Abs(y) > 0.5f;

        if (isMovingVertical && isMovingHorizontal)
        {
            //moving in both directions, prioritize later
            if (wasMovingVertical)
            {
                rb2D.velocity = new Vector2(x * speed, 0);
                anim.SetFloat("X", x);
                anim.SetFloat("Y", 0);
            }
            else if (wasMovingHorizontal)
            {
                rb2D.velocity = new Vector2(0, y * speed);                
                anim.SetFloat("X", 0);
                anim.SetFloat("Y", y);
            }
        }
        else if (isMovingHorizontal)
        {
            rb2D.velocity = new Vector2(x * speed, 0);
            wasMovingVertical = false;
            wasMovingHorizontal = true;
            anim.SetFloat("X", x);
            anim.SetFloat("Y", 0);
        }
        else if (isMovingVertical)
        {
            rb2D.velocity = new Vector2(0, y * speed);
            wasMovingVertical = true;
            wasMovingHorizontal = false;
            anim.SetFloat("X", 0);
            anim.SetFloat("Y", y);
        }
        else
        {
            rb2D.velocity = Vector2.zero; //pour s'arrêter dès que le joueur cesse de bouger
        }
        //FIN ALGORITHME DE DÉPLACEMENTS


        //ALGORITHME D'ANIMATION DE MARCHE EN FONCTION DE L'ORIENTATION DU PERSONNAGE
        // Détection de si le personnage bouge ou non
        if (x != 0 || y != 0) // = si x et y sont différents de 0
        {
            if (!isWalking)
            {
                isWalking = true;
                anim.SetBool("isWalking", isWalking);
            }
        }
        else
        {
            if (isWalking)
            {
                isWalking = false;
                anim.SetBool("isWalking", isWalking);
            }
        }
    }
}
