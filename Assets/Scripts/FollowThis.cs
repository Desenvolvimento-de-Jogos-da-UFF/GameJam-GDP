using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThis : MonoBehaviour
{

    [SerializeField] private Transform focusedObject;
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;
    [SerializeField] private float camDelay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 newPos = focusedObject.position;
        newPos.z = -10;
        newPos.x += xOffset;
        newPos.y += yOffset;
        transform.position = Vector3.Lerp(transform.position, newPos, camDelay);

    }
}
