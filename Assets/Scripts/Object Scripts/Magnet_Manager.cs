using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet_Manager : MonoBehaviour {
    [HideInInspector]
    public static Magnet_Manager instance;
    [HideInInspector]
    public List<GameObject> thingsToMove = new List<GameObject>();
    [HideInInspector]
    public GameObject target;
    [HideInInspector]
    public bool shouldMove = false;
    [HideInInspector]
    public bool timerStarted = false;

    public float shootForce = 1f;

    private void Awake()
    {
        instance = this;
    }

    public void Subscribe(GameObject toSubscribe)
    {
        Debug.Log("Subscribing " + toSubscribe.name);

        if (thingsToMove.Contains(toSubscribe))
            return;
        thingsToMove.Add(toSubscribe);
        
    }

    public void PleaseCommentDownBelow(GameObject toUnsubscribe)
    {
        Debug.Log("Unsubscribing " + toUnsubscribe.name);

        if (thingsToMove.Contains(toUnsubscribe))
        {
            thingsToMove.Remove(toUnsubscribe);
        }
    }

    public void MoveObjects()
    {
        if (shouldMove == true)
            StopCoroutine("CoroutineObjects");

        StartCoroutine("CoroutineObjects");

        if (timerStarted == false)
        {
            timerStarted = true;
            Invoke("StopMoving", 2f);
        }
    } 

    public IEnumerator CoroutineObjects()
    {
        shouldMove = true;
        while (shouldMove)
        {
            //thingsToMove
            foreach (GameObject obj in thingsToMove)
            {
                if (obj != null)
                {
                    Rigidbody body;
                    if (obj.GetComponent<Rigidbody>() == null)
                        body = obj.AddComponent<Rigidbody>();
                    else
                        body = obj.GetComponent<Rigidbody>();

                    Vector3 moveDir = target.transform.position - obj.transform.position;
                    body.AddForce(moveDir.normalized * shootForce, ForceMode.Impulse);
                }
            }

            if (thingsToMove.Count <= 0 )
            {
                shouldMove = false;
            }



            yield return new WaitForEndOfFrame();

        }

    }

    void StopMoving()
    {
        shouldMove = false;
        timerStarted = false;

        target.GetComponent<Renderer>().material.color = Color.white;
        target = null;
        

    }
}
