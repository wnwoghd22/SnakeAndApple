using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<Transform> body_parts = new List<Transform>();

    [SerializeField]
    float moveSpd;

    Vector2 rotate;
    float currentRotate = 1;
    [SerializeField]
    float rotateSensitivity;

    [SerializeField]
    Transform bodyPrefab;
    [SerializeField]
    Transform applePrefab;

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

    }

    private void FixedUpdate()
    {
        MoveFoward();
        Rotate();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Apple")
        {
            Destroy(collision.gameObject);
            Vector2 randomPos = new Vector2(Random.Range(-2.4f, 2.4f), Random.Range(-4.7f, 4.7f));
            Instantiate(applePrefab, randomPos, Quaternion.identity);

            Transform currentPos;
            if (body_parts.Count == 0)
                currentPos = transform;
            else
                currentPos = body_parts[body_parts.Count - 1];
                
            Transform newBodyPart = Instantiate(bodyPrefab, currentPos.position, Quaternion.identity) as Transform;
            body_parts.Add(newBodyPart);
            newBodyPart.GetComponent<SnakeBody>().SetTarget(currentPos);
        }
    }
}
