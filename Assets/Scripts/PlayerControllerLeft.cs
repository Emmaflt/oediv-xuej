using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerControllerLeft : MonoBehaviour
{
    [SerializeField]
    private Tilemap groundTilemap;
    
    [SerializeField]
    private Tilemap collisionTilemap;

    [SerializeField]
    private Tilemap obstacleTilemap;

    private PlayerMovementLeft controls;
    public Transform playerSprite;
    public GameObject gameManager;


    private void Awake()
    {
        controls = new PlayerMovementLeft();
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
        controls.Main.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }

    private void Move(Vector2 direction) {
        if (CanMove(direction)) {
            transform.position += (Vector3)direction;
            gameManager.GetComponent<GameManager>().stepLeft = true;
        }
    }

    //Vector3.Distance(transform.position, new Vector3(playerSprite.position.x, playerSprite.position.y - 0.5f, playerSprite.position.z)) != 0
    private bool CanMove(Vector2 direction) {
        Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)direction);
        if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition) || obstacleTilemap.HasTile(gridPosition) 
        ||  gameManager.GetComponent<GameManager>().canMove == false
        || gameManager.GetComponent<GameManager>().stepCount <= 0) {
            return false;
        } else {
            return true;
        }
        
    }
}
