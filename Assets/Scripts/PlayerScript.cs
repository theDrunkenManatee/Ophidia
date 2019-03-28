using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject Head;
    public GameObject Tail;
    public int tailLength;
    public Vector3 lastPoint;
    public float tailGap;
    public float lengthFromPoint;
    private Queue tailQueue;
    

    // Start is called before the first frame update
    void Start()
    {
        lastPoint = Head.transform.position;
        tailQueue = new Queue();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lengthFromPoint = Vector3.Distance(lastPoint, Head.transform.position);
        if(lengthFromPoint>tailGap)
        {
            UpdateTail();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Add5")
        {
            incrementTailBy(5);
        }
        if (collision.gameObject.tag == "Minus7")
        {
            incrementTailBy(-7);
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
        tailQueue.Enqueue(tailToPlace);
        lastPoint = Head.transform.position;
    }
    
    public void incrementTailBy(int amnt)
    {
        if(amnt<0)
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
