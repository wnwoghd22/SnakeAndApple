using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpd;

    Vector2 rotate;
    float currentRotate = 1;
    [SerializeField]
    float rotateSensitivity;

    void MoveFoward()
    {
        transform.position += transform.up * moveSpd * Time.deltaTime;
    }
    void Rotate()
    {
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, currentRotate));
    }
    

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90);
        currentRotate = transform.rotation.z;
    }

    private void FixedUpdate()
    {
        MoveFoward();
        Rotate();
        Debug.Log(transform.rotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Vector2 targetPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 rotatePos = targetPos - (Vector2)transform.position;

            rotate = transform.InverseTransformPoint(rotatePos);
            if (rotate.x > 0)
                currentRotate -= rotateSensitivity * Time.deltaTime;
            if (rotate.x < 0)
                currentRotate += rotateSensitivity * Time.deltaTime;
        }
        if(Input.GetMouseButton(0) == true)
        { 
            Vector2 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 rotatePos = targetPos - (Vector2)transform.position;

            rotate = transform.InverseTransformPoint(rotatePos);
            if (rotate.x > 0)
                currentRotate -= rotateSensitivity * Time.deltaTime;
            if (rotate.x < 0)
                currentRotate += rotateSensitivity * Time.deltaTime;
        }
    }
}
