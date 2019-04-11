using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public string lastHit = "";
    public TailScript playerTail;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleHit(ControllerColliderHit hit)
    {
        

        if(hit.gameObject.name!=lastHit)
        {
            Debug.Log("CollisionHandler detected new hit between " + hit.controller.name  + " and " + hit.gameObject.tag);
            if (hit.gameObject.tag == "Add5")
            {
                if (hit.controller.tag == "Player")
                {
                    playerTail.incrementTailBy(5);
                }
            }
        }

        lastHit = hit.gameObject.name;

    }
}
