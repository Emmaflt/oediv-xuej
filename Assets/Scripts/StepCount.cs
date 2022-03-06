using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepCount : MonoBehaviour
{
    public int maxStep = 10;
    public int stepCount;
    public Text stepCountText;

    public bool stepLeft;
    public bool stepRight;

    public Transform movePointRight;
    public Transform playerSpriteRight;
    public Transform spawnerRight;

    public Transform movePointLeft;
    public Transform playerSpriteLeft;
    public Transform spawnerLeft;

    void Start() {
        //movePointRight.position = new Vector2(spawnerRight.transform.position.x, spawnerRight.transform.position.y);
        playerSpriteRight.position = new Vector2(spawnerRight.transform.position.x, spawnerRight.transform.position.y + 0.5f);
        playerSpriteLeft.position = new Vector2(spawnerLeft.transform.position.x, spawnerLeft.transform.position.y + 0.5f);

        stepCount = maxStep;
    }

    void Update()
    {
        if ((stepLeft && stepRight) || (stepLeft && !stepRight) || (!stepLeft && stepRight)) {
            stepCount--;
            stepLeft = false;
            stepRight = false;
        }
        stepCountText.text = (stepCount).ToString();

        //GAME OVER
        if (stepCount <= 0) {
            movePointRight.position = new Vector2(spawnerRight.transform.position.x, spawnerRight.transform.position.y);
            playerSpriteRight.position = new Vector2(spawnerRight.transform.position.x, spawnerRight.transform.position.y + 0.5f);
            movePointLeft.position = new Vector2(spawnerLeft.transform.position.x, spawnerLeft.transform.position.y);
            playerSpriteLeft.position = new Vector2(spawnerLeft.transform.position.x, spawnerLeft.transform.position.y + 0.5f);
            //animation de mort
            stepCount = maxStep;
        }
    }
}
