using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int maxStep = 10;
    public int stepCount;
    public Text stepCountText;
    public GameObject pause_menu = null;

    public bool stepLeft;
    public bool stepRight;

    public Transform movePointRight;
    public Transform spawnerRight;
    public Transform winPointRight;
    public GameObject playerRight;

    public Transform movePointLeft;
    public Transform spawnerLeft;
    public Transform winPointLeft;
    public GameObject playerLeft;
    public GameObject winFade;

    public AudioSource audioSource; 
    public AudioClip gameOverNoise;

    public string levelToLoad;

    public bool canMove = true;

    void Awake() {
        playerRight.GetComponent<Transform>().position = new Vector2(spawnerRight.transform.position.x, spawnerRight.transform.position.y + 0.5f);
        playerLeft.GetComponent<Transform>().position = new Vector2(spawnerLeft.transform.position.x, spawnerLeft.transform.position.y + 0.5f);
    }

    void Start() {
        stepCount = maxStep;
    }

    public void Reset()
    {
        StartCoroutine(GameOver());
    }

    void Update()
    {
        //OUVRIR / FERMER MENU PAUSE
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause_menu.GetComponent<PauseMenu>().gameIsPaused) {
                pause_menu.GetComponent<PauseMenu>().Resume();            
            } else {
                pause_menu.GetComponent<PauseMenu>().Pause();            
            }
        }   

        if (Vector3.Distance(movePointRight.position, new Vector3(playerRight.GetComponent<Transform>().position.x, playerRight.GetComponent<Transform>().position.y - 0.5f, playerRight.GetComponent<Transform>().position.z)) == 0 
        && Vector3.Distance(movePointLeft.position, new Vector3(playerLeft.GetComponent<Transform>().position.x, playerLeft.GetComponent<Transform>().position.y - 0.5f, playerLeft.GetComponent<Transform>().position.z)) == 0
        ) {  
            if (this.GetComponent<DialogManager>() != null)
            {
                if (this.GetComponent<DialogManager>().dialogWorking)
                {
                    canMove = false;
                }
                else
                {
                    canMove = true;
                }
            } else
            {
                canMove = true;
            }
        } else {
            canMove = false;
        }

        //PAUSE
        if (pause_menu.activeSelf)
        {
            return;
        }

        if (movePointRight.position == winPointRight.position && movePointLeft.position == winPointLeft.position) {
            StartCoroutine(Win());
        }

        if ((stepLeft && stepRight) || (stepLeft && !stepRight) || (!stepLeft && stepRight)) {
            stepCount--;
            stepLeft = false;
            stepRight = false;
        }
        stepCountText.text = (stepCount).ToString();



        //GAME OVER
        if (stepCount <= 0) {
            StartCoroutine(GameOver());
        }

        //RESET
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver() {
            stepCount = 0;
            if (playerRight.GetComponent<PlayerBehavior>().isDead == false) {
                StartCoroutine(MyPlayDelay());

            }
            playerRight.GetComponent<PlayerBehavior>().isDead = true;
            playerLeft.GetComponent<PlayerBehavior>().isDead = true;
            yield return new WaitForSeconds(2.5f);
            playerRight.GetComponent<PlayerBehavior>().isDead = false;
            playerLeft.GetComponent<PlayerBehavior>().isDead = false;
            movePointRight.position = new Vector2(spawnerRight.transform.position.x, spawnerRight.transform.position.y);
            movePointLeft.position = new Vector2(spawnerLeft.transform.position.x, spawnerLeft.transform.position.y);
            playerRight.GetComponent<Transform>().position = new Vector2(spawnerRight.transform.position.x, spawnerRight.transform.position.y + 0.5f);
            playerLeft.GetComponent<Transform>().position = new Vector2(spawnerLeft.transform.position.x, spawnerLeft.transform.position.y + 0.5f);
            stepCount = maxStep;
            yield return null;
    }
    
    IEnumerator Win() {
            stepCount = 0;
            yield return new WaitForSeconds(2f);
            winFade.SetActive(true);
            yield return new WaitForSeconds(1f);
            //fondu au noir
            SceneManager.LoadScene(levelToLoad);
            yield return null;
    }

        IEnumerator MyPlayDelay() {
                yield return new WaitForSeconds(0.6f);
                audioSource.PlayOneShot(gameOverNoise, 0.5f);
        }


}
