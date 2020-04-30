using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    private int myOrder;

    private Transform targetPos;
    public void SetTarget(Transform _target) => targetPos = _target;

    private Vector3 movementVelocity;
    [Range(0.01f, 1.0f)]
    public float overTime = 0.5f;
    bool pause;
    public void Pause() => pause = true;

    void Follow()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPos.position, ref movementVelocity, overTime);
        float targetAngle = Mathf.Atan2(targetPos.position.y - transform.position.y, targetPos.transform.position.x - transform.position.x);
        float targetDegree = (180 / Mathf.PI) * targetAngle;
        transform.rotation = Quaternion.Euler(0, 0, targetDegree - 90);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!pause)
            Follow();
    }
}
