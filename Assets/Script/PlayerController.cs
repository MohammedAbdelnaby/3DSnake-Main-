using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float PlayerMoveTimer;
    private float PlayerMoveTimerMax;
    Transform PlayerTransform;
    private Vector3 Direction;
    private int SnakeBodySize;
    private List<Vector3> SnakeMoveList;
    [SerializeField]
    private GameObject SnakeBodyPrefab;
    // Start is called before the first frame update
    void Awake()
    {
        PlayerTransform = transform;
        PlayerMoveTimerMax = 0.1f;
        PlayerMoveTimer = PlayerMoveTimerMax;
        Direction = new Vector3(0,0,0.5f);
        SnakeMoveList = new List<Vector3>();
        SnakeBodySize = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Direction.z != -0.5)
            {
                Direction = new Vector3(0.0f, 0.0f, 0.5f);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (Direction.z != +0.5)
            {
                Direction = new Vector3(0.0f, 0.0f, -0.5f);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Direction.x != +0.5)
            {
                Direction = new Vector3(-0.5f, 0.0f, 0.0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (Direction.x != -0.5)
            {
                Direction = new Vector3(0.5f, 0.0f, 0.0f);
            }
        }

        PlayerMoveTimer += Time.deltaTime;
        if (PlayerMoveTimer >= PlayerMoveTimerMax)
        {
            SnakeMoveList.Insert(0, PlayerTransform.position);

            PlayerTransform.position += Direction;
            PlayerMoveTimer -= PlayerMoveTimerMax;

            if (SnakeMoveList.Count >= SnakeBodySize + 1)
            {
                SnakeMoveList.RemoveAt(SnakeMoveList.Count - 1);
            }

            for (int i = 0; i < SnakeMoveList.Count; i++)
            {
               GameObject temp = Instantiate(SnakeBodyPrefab, new Vector3(SnakeMoveList[i].x, SnakeMoveList[i].y, SnakeMoveList[i].z), Quaternion.identity);
                Destroy(temp, PlayerMoveTimerMax);
            }
            PlayerTransform.eulerAngles = new Vector3(0.0f, GetAngleFromVector(new Vector2(Direction.z, Direction.x)), 0.0f);
        }
    }

    private float GetAngleFromVector(Vector2 dir)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0)
        {
            n += 360;
        }
        return n;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Apple")
        {
            Destroy(other.gameObject);
            SnakeBodySize++;
        }
        Debug.Log("d");
    }
}
