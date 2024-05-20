using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    Vector3 notTerrainPosition;
    public LayerMask terrainMask;
    public GameObject currentChunk;
    PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        ChunkChecker();
    }

    void ChunkChecker()
    {
        //if (!currentChunk)
        //{
        //    return;
        //}
        if (playerMovement.moveDir.x > 0 && playerMovement.moveDir.y == 0) //right
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
            {
                notTerrainPosition = currentChunk.transform.Find("Right").position;
                Debug.Log($"RIGHT");
                SpawnChunk();
            }
        }

        else if (playerMovement.moveDir.x < 0 && playerMovement.moveDir.y == 0) //left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
            {
                notTerrainPosition = currentChunk.transform.Find("Left").position;
                Debug.Log($"LEFT");
                SpawnChunk();
            }
        }
        else if (playerMovement.moveDir.x == 0 && playerMovement.moveDir.y > 0) //up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
            {
                notTerrainPosition = currentChunk.transform.Find("Up").position;
                Debug.Log($"UP");
                SpawnChunk();
            }
        }

        else if (playerMovement.moveDir.x == 0 && playerMovement.moveDir.y < 0) //down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
            {
                notTerrainPosition = currentChunk.transform.Find("Down").position;
                Debug.Log($"DOWN");
                SpawnChunk();
            }
        }

        else if (playerMovement.moveDir.x > 0 && playerMovement.moveDir.y > 0) //right up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("UpRight").position, checkerRadius, terrainMask))
            {
                notTerrainPosition = currentChunk.transform.Find("UpRight").position;
                Debug.Log($"RIGHTUP");
                SpawnChunk();
            }
        }

        else if (playerMovement.moveDir.x > 0 && playerMovement.moveDir.y < 0) //right down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("DownRight").position, checkerRadius, terrainMask))
            {
                notTerrainPosition = currentChunk.transform.Find("DownRight").position;
                Debug.Log($"RIGHTDOWN");
                SpawnChunk();
            }
        }

        else if (playerMovement.moveDir.x < 0 && playerMovement.moveDir.y > 0) //left up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("UpLeft").position, checkerRadius, terrainMask))
            {
                notTerrainPosition = currentChunk.transform.Find("UpLeft").position;
                Debug.Log($"LEFTUP");
                SpawnChunk();
            }
        }

        else if (playerMovement.moveDir.x < 0 && playerMovement.moveDir.y < 0) //left down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("DownLeft").position, checkerRadius, terrainMask))
            {
                notTerrainPosition = currentChunk.transform.Find("DownLeft").position;
                Debug.Log($"LEFTDOWN");
                SpawnChunk();
            }
        }

    }
    void SpawnChunk()
    {
        int rand = Random.Range(0, terrainChunks.Count);
        Instantiate(terrainChunks[0], notTerrainPosition, Quaternion.identity);
    }
}
