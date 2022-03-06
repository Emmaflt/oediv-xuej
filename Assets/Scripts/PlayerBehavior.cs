using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    private Animator anim;
    private float x, y;
    private bool isWalking;

    public Transform movePoint;
    public float moveSpeed = 2f;

    void Start()
    {
        anim = GetComponent<Animator>();
        movePoint.parent = null;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(movePoint.position.x, movePoint.position.y + 0.5f, movePoint.position.z), moveSpeed * Time.deltaTime);
        
        //ANIMATION DES MOUVEMENTS --------------------------------------------------------------------------------
        x = Input.GetAxis("Horizontal"); //équivalent de X
        y = Input.GetAxis("Vertical"); // équivalent de Y

        bool isMovingHorizontal = Mathf.Abs(x) > 0.5f;
        bool isMovingVertical = Mathf.Abs(y) > 0.5f;

        //DÉTECTION DE SI LE PLAYER MARCHE OU NON
        if (Vector3.Distance(transform.position, new Vector3(movePoint.position.x, movePoint.position.y + 0.5f, movePoint.position.z)) != 0) // = si x et y sont différents de 0
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

        //ANIMATION IDLE EN FONCTION DE L'ORIENTATION
        if(x > 0 || x < 0 || y > 0 || y < 0)
        {
            anim.SetFloat("LX", x);
            anim.SetFloat("LY", y);
        }

        if (isMovingHorizontal)
        {
            anim.SetFloat("X", x);
            anim.SetFloat("Y", 0);
        }
        else if (isMovingVertical)
        {
            anim.SetFloat("X", 0);
            anim.SetFloat("Y", y);
        } 
    }
}
