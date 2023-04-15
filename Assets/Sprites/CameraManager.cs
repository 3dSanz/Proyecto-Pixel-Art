using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
     public Transform target;
     public Vector3 offset;
     public Vector2 limitX;
     public Vector2 limitY;
     GameManager gameManager;
     public float interpolationRatio;

    void Start()
    {
        target = GameObject.Find("Personaje").GetComponent<Transform>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void LateUpdate()
    {
        if(target != null && gameManager.isGameOver == false)
        {
        Vector3 desiredPosition = target.position + offset;

        float clampX = Mathf.Clamp(desiredPosition.x, limitX.x, limitX.y);

        float clampY = Mathf.Clamp(desiredPosition.y, limitY.x, limitY.y);

        Vector3 clampedPosition = new Vector3(clampX, clampY, desiredPosition.z);

        Vector3 lerpedPosition = Vector3.Lerp(transform.position,clampedPosition,interpolationRatio);

        transform.position = lerpedPosition;
        }
    }
       
}
