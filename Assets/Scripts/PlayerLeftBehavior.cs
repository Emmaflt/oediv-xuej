using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLeftBehavior : MonoBehaviour
{

    private Animator anim;
    private float x, y;
    private bool isWalking;

    public GameObject pause_menu = null;

    bool stepStarted = false;

    public int maxStep = 10;
    public int stepCount;

    public GameObject spawner; //la ou on apparait au debut

    void Start()
    {
        anim = GetComponent<Animator>();
        transform.position = new Vector2(spawner.transform.position.x, spawner.transform.position.y);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //OUVRIR / FERMER MENU PAUSE
        {
            pause_menu.SetActive(!pause_menu.activeSelf);
        }

        if (pause_menu.activeSelf)
        {
            return;
        }

        if (stepCount <= 0) {
            //GAME OVER
            transform.position = new Vector2(spawner.transform.position.x, spawner.transform.position.y);
            stepCount = maxStep;
        }

        //MOUVEMENTS ET ANIMATION DES MOUVEMENTS -------------------------------------------------------------------------------------------------

        x = Input.GetAxis("Horizontal"); //équivalent de X
        y = Input.GetAxis("Vertical"); // équivalent de Y

        //ANIMATION IDLE EN FONCTION DE L'ORIENTATION
        if(x > 0 || x < 0 || y > 0 || y < 0)
        {
            anim.SetFloat("LX", -x);
            anim.SetFloat("LY", y);
        }

        //ALGORITHME DE DÉPLACEMENTS (SANS DIAGONALE)
        bool isMovingHorizontal = Mathf.Abs(x) > 0.5f;
        bool isMovingVertical = Mathf.Abs(y) > 0.5f;

        if (isMovingHorizontal)
        {
            if (stepStarted == false) {
                if (x > 0) {
                    StartCoroutine(Walk(-1, 0));
                } else {
                    StartCoroutine(Walk(1, 0));
                }
            }
            anim.SetFloat("X", -x);
            anim.SetFloat("Y", 0);
        }
        else if (isMovingVertical)
        {
            if (stepStarted == false) {
                if (y > 0) {
                    StartCoroutine(Walk(0, 1));
                } else {
                    StartCoroutine(Walk(0, -1));
                }
            }
            anim.SetFloat("X", 0);
            anim.SetFloat("Y", y);
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

    IEnumerator Walk(int xValue, int yValue)
    {
        stepStarted = true;
        for (var i = 0; i <= 10; i++)
        {
            transform.Translate(new Vector2(0.1f * xValue, 0.1f * yValue));
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.2f);
        stepCount--;
        stepStarted = false;
    }
}
