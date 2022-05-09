using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float PlayerMoveTimer;
    private float PlayerMoveTimerMax;
    Transform PlayerTransform;
    private Vector3 Direction;
    // Start is called before the first frame update
    void Awake()
    {
        PlayerTransform = transform;
        PlayerMoveTimerMax = 0.5f;
        PlayerMoveTimer = PlayerMoveTimerMax;
        Direction = new Vector3(0,0,0.5f);
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
            PlayerTransform.position += Direction;
            PlayerMoveTimer -= PlayerMoveTimerMax;

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
}
