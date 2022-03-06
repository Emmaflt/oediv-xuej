using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Tilemap groundTilemap;
    
    [SerializeField]
    private Tilemap collisionTilemap;

    private PlayerMovement controls;

    public Transform playerSprite;

    public int maxStep = 10;
    public int stepCount;
    public Text stepCountText;

    private void Awake()
    {
        controls = new PlayerMovement();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Start() {
        stepCount = maxStep;
        controls.Main.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }

    public void Update() {
        stepCountText.text = (stepCount).ToString();

        //GAME OVER
        if (stepCount <= 0) {
           // transform.position = new Vector2(spawner.transform.position.x, spawner.transform.position.y);
            stepCount = maxStep;
        }
    }

    private void Move(Vector2 direction) {
        if (CanMove(direction)) {
            transform.position += (Vector3)direction;
            stepCount--;
        }
    }

    private bool CanMove(Vector2 direction) {
        Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)direction);
        if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition) || Vector3.Distance(transform.position, new Vector3(playerSprite.position.x, playerSprite.position.y - 0.5f, playerSprite.position.z)) != 0) {
            return false;
        } else {
            return true;
        }
        
    }
}

