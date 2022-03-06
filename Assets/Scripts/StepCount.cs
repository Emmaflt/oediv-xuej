using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StepCount : MonoBehaviour
{
    public int maxStep = 10;
    public int stepCount;
    public Text stepCountText;
    public GameObject pause_menu = null;


    public bool stepLeft;
    public bool stepRight;

    public Transform movePointRight;
    public Transform playerSpriteRight;
    public Transform spawnerRight;
    public Transform winPointRight;
    public GameObject playerRight;

    public Transform movePointLeft;
    public Transform playerSpriteLeft;
    public Transform spawnerLeft;
    public Transform winPointLeft;
    public GameObject playerLeft;


    public string levelToLoad;

    void Awake() {
        playerSpriteRight.position = new Vector2(spawnerRight.transform.position.x, spawnerRight.transform.position.y + 0.5f);
        playerSpriteLeft.position = new Vector2(spawnerLeft.transform.position.x, spawnerLeft.transform.position.y + 0.5f);
        // movePointLeft.position = new Vector2(spawnerLeft.transform.position.x, spawnerLeft.transform.position.y);
        // movePointRight.position = new Vector2(spawnerRight.transform.position.x, spawnerRight.transform.position.y);
    }

    void Start() {
        stepCount = maxStep;
    }

    void Update()
    {
        //OUVRIR / FERMER MENU PAUSE
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            pause_menu.SetActive(!pause_menu.activeSelf);
        }

        //PAUSE
        if (pause_menu.activeSelf)
        {
            return;
        }

        if ((stepLeft && stepRight) || (stepLeft && !stepRight) || (!stepLeft && stepRight)) {
            stepCount--;
            stepLeft = false;
            stepRight = false;
        }
        stepCountText.text = (stepCount).ToString();

        if (movePointRight.position == winPointRight.position && movePointLeft.position == winPointLeft.position) {
            //WIN
            //FONDU AU NOIR
            SceneManager.LoadScene(levelToLoad);
        }

        //GAME OVER
        if (stepCount <= 0) {
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver() {
            playerRight.GetComponent<PlayerBehavior>().isDead = true;
            playerLeft.GetComponent<PlayerBehavior>().isDead = true;
            yield return new WaitForSeconds(2);
            movePointRight.position = new Vector2(spawnerRight.transform.position.x, spawnerRight.transform.position.y);
            playerSpriteRight.position = new Vector2(spawnerRight.transform.position.x, spawnerRight.transform.position.y + 0.5f);
            movePointLeft.position = new Vector2(spawnerLeft.transform.position.x, spawnerLeft.transform.position.y);
            playerSpriteLeft.position = new Vector2(spawnerLeft.transform.position.x, spawnerLeft.transform.position.y + 0.5f);
            playerRight.GetComponent<PlayerBehavior>().isDead = false;
            playerLeft.GetComponent<PlayerBehavior>().isDead = false;
            stepCount = maxStep;
            yield return null;
    }

}
