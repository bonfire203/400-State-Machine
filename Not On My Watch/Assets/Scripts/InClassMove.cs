using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InClassMove : MonoBehaviour
{
    public float speed = 2f;
    Vector3 target = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("target").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveTo(target);
    }

    public void moveTo(Vector3 target){
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
