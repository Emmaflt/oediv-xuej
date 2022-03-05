using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{



    // private Animator anim;
    // private float x, y;
    // private bool isWalking;

    // public GameObject pause_menu = null;

    // bool stepStarted = false;

    // public int maxStep = 10;
    // public int stepCount;
    // public Text stepCountText;

    // Rigidbody2D rb2D;

    // public GameObject spawner; //la ou on apparait au debut

    // private Vector2 _direction = Vector2.zero; 

    // public float oldX = 0;
    // public float oldY = 0;


    // void Start()
    // {
    //     transform.position = new Vector2(spawner.transform.position.x, spawner.transform.position.y);
    //     anim = GetComponent<Animator>();
    //     stepCount = maxStep;
    //     rb2D = gameObject.GetComponent<Rigidbody2D>();

    // }

    // void Update()
    // {
    //     stepCountText.text = (stepCount).ToString();
        
    //     //OUVRIR / FERMER MENU PAUSE
    //     if (Input.GetKeyDown(KeyCode.Escape)) 
    //     {
    //         pause_menu.SetActive(!pause_menu.activeSelf);
    //     }

    //     //PAUSE
    //     if (pause_menu.activeSelf)
    //     {
    //         return;
    //     }

    //     //GAME OVER
    //     if (stepCount <= 0) {
    //         transform.position = new Vector2(spawner.transform.position.x, spawner.transform.position.y);
    //         stepCount = maxStep;
    //     }

    //     //ANIMATION DES MOUVEMENTS --------------------------------------------------------------------------------
    //     x = Input.GetAxis("Horizontal"); //équivalent de X
    //     y = Input.GetAxis("Vertical"); // équivalent de Y

    //     //MOUVEMENTS -------------------------------------------------------------------------------------------------

    //     bool isMovingHorizontal = Mathf.Abs(x) > 0.5f;
    //     bool isMovingVertical = Mathf.Abs(y) > 0.5f;

    //     if (transform.position.x == oldX++ || transform.position.x == oldX--) {
    //         Debug.Log("j'ai bougé ! ");
    //         _direction = new Vector2 (0, 0);

    //     }

    //     if (stepStarted) {
    //         return;
    //     } else {
    //         oldX = Mathf.Round(this.transform.position.x);
    //         oldY = Mathf.Round(this.transform.position.y);
    //     }

    //     if (isMovingHorizontal)
    //     {
    //         if (x > 0) {
    //             _direction = new Vector2 (1, 0);
    //             stepStarted = true;
    //             //StartCoroutine(Walk());
    //         } else {
    //             _direction = new Vector2 (-1, 0);
    //             stepStarted = true;
    //             //StartCoroutine(Walk());
    //         }
    //         anim.SetFloat("X", x);
    //         anim.SetFloat("Y", 0);
    //     }
    //     else if (isMovingVertical)
    //     {
    //         if (y > 0) {
    //             _direction = new Vector2 (0, 1);
    //             stepStarted = true;
    //             // StartCoroutine(Walk());
    //         } else {
    //             _direction = new Vector2 (0, -1);
    //             stepStarted = true;
    //             // StartCoroutine(Walk());
    //         }
    //         anim.SetFloat("X", 0);
    //         anim.SetFloat("Y", y);
    //     } else {
    //         _direction = new Vector2 (0, 0);
    //     }
    //     //FIN ALGORITHME DE DÉPLACEMENTS

    //     //ALGORITHME D'ANIMATION DE MARCHE EN FONCTION DE L'ORIENTATION DU PERSONNAGE
    //     // Détection de si le personnage bouge ou non
    //     if (x != 0 || y != 0) // = si x et y sont différents de 0
    //     {
    //         if (!isWalking)
    //         {
    //             isWalking = true;
    //             anim.SetBool("isWalking", isWalking);
    //         }
    //     }
    //     else
    //     {
    //         if (isWalking)
    //         {
    //             isWalking = false;
    //             anim.SetBool("isWalking", isWalking);
    //         }
    //     }

    //     //ANIMATION IDLE EN FONCTION DE L'ORIENTATION
    //     if(x > 0 || x < 0 || y > 0 || y < 0)
    //     {
    //         anim.SetFloat("LX", x);
    //         anim.SetFloat("LY", y);
    //     }

    // }

    // private void FixedUpdate() {
    //     this.transform.position = new Vector3(
    //         Mathf.Round(this.transform.position.x) + _direction.x ,
    //         Mathf.Round(this.transform.position.y) + _direction.y,
    //         0.0f
    //     );
    // }

    // IEnumerator Walk(int xValue, int yValue)
    // {
    //     if (timeMoving < 2.0f)
    //     {
    //         rb2D.velocity = new Vector2( 0.1f * xValue, 0.1f * yValue);
    //     } else {
    //         rb2D.velocity = Vector2.zero;
    //         timeMoving = 0.0f;
    //         Debug.Log("temps dépassé");
    //     }

    //     // if (!stepStarted) {
    //     //     stepStarted = true;
    //     //     rb2D.velocity = new Vector2( 0.1f * xValue, 0.1f * yValue);
    //     //     yield return new WaitForSeconds(2);
    //     // }
    //     /*for (var i = 0; i <= 10; i++)
    //     {
    //         //rb2D.MovePosition(rb2D.position + new Vector2( 0.1f * xValue, 0.1f * yValue));
    //         //rb2D.MovePosition(new Vector2(transform.position.x + 0.1f * xValue, transform.position.y + 0.1f * yValue));
    //         //transform.Translate(new Vector2(0.1f * xValue, 0.1f * yValue));
    //         yield return new WaitForSeconds(0.02f);
    //     }*/
    //     yield return new WaitForSeconds(0.2f);
    //     stepCount--;
    //     stepStarted = false;
        
    // }

    // IEnumerator Walk() {

    //     // } else {
    //     //     Debug.Log(transform.position.y);
    //     //     _direction = new Vector2 (0, 0);
    //     //     stepCount--;
    //     //     Debug.Log("Les coordonnées du player ont changé");
    //     //     stepStarted = false;
    //     // }
    // }

}
