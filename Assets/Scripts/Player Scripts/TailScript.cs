using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailScript : MonoBehaviour
{
    public GameObject Head;
    public GameObject Tail;
    public int tailLength;
    public float tailGap;
    private Vector3 lastPoint;
    private float lengthFromPoint;
    private Queue tailQueue;
    

    // Start is called before the first frame update
    void Start()
    {
        lastPoint = Head.transform.position;
        tailQueue = new Queue();
    }

    // Update is called once per frame
    void Update()
    {
        lengthFromPoint = Vector3.Distance(lastPoint, Head.transform.position);
        if(lengthFromPoint>tailGap)
        {
            UpdateTail();
        }
    }

    public void UpdateTail()
    {
        GameObject tailToPlace;
        if(tailQueue.Count==tailLength)
        {
            tailToPlace = (GameObject) tailQueue.Dequeue();
        }
        else
        {
            tailToPlace = Instantiate(Tail);
        }
        tailToPlace.transform.position = lastPoint;
        tailToPlace.transform.LookAt(Head.transform);
        tailQueue.Enqueue(tailToPlace);
        lastPoint = Head.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        tailLength = 5;
    }


    public void incrementTailBy(int amnt)
    {
        Debug.Log("Incrementing tail by " + amnt);
        if (amnt<0)
        {
            for(int x = 0; x<Mathf.Abs(amnt);x++)
            {
                GameObject toDelete = (GameObject) tailQueue.Dequeue();
                GameObject.Destroy(toDelete);
            }
            
        }
        tailLength += amnt;
    }
}
