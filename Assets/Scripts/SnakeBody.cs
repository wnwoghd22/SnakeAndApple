using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    private int myOrder;
    private Transform head;

    private Transform targetPos;
    public void SetTarget(Transform _target) => targetPos = _target;

    private Vector3 movementVelocity;
    [Range(0.01f, 1.0f)]
    public float overTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        /*head = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
        for (int i = 0; i < head.GetComponent<PlayerController>().body_parts.Count; i++)
            if (gameObject == head.GetComponent<PlayerController>().body_parts[i].gameObject)
                myOrder = i;*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        /*if(myOrder == 0)
        {
            transform.position = Vector3.SmoothDamp(transform.position, head.position, ref movementVelocity, overTime);
            float targetAngle = Mathf.Atan2(head.position.y - transform.position.y, head.transform.position.x - transform.position.x);
            float targetDegree = (180 / Mathf.PI) * targetAngle;
            transform.rotation = Quaternion.Euler(0, 0, targetDegree - 90);
        }
        else
        {
            Transform targetPos = head.GetComponent<PlayerController>().body_parts[myOrder - 1];
            transform.position = Vector3.SmoothDamp(transform.position, targetPos.position, ref movementVelocity, overTime);
            float targetAngle = Mathf.Atan2(targetPos.position.y - transform.position.y, targetPos.transform.position.x - transform.position.x);
            float targetDegree = (180 / Mathf.PI) * targetAngle;
            transform.rotation = Quaternion.Euler(0, 0, targetDegree - 90);
        }*/

        transform.position = Vector3.SmoothDamp(transform.position, targetPos.position, ref movementVelocity, overTime);
        float targetAngle = Mathf.Atan2(targetPos.position.y - transform.position.y, targetPos.transform.position.x - transform.position.x);
        float targetDegree = (180 / Mathf.PI) * targetAngle;
        transform.rotation = Quaternion.Euler(0, 0, targetDegree - 90);
    }
}
