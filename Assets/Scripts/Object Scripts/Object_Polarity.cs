using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Polarity : MonoBehaviour
{

    string myPolarity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Positive"))   //blue bullet
        {
            Magnet_Manager.instance.Subscribe(this.gameObject);
            gameObject.tag = "Positive2";
            myPolarity = "blue";
        }

        if (other.CompareTag("Negative")) //red bullet
        {
            if (Magnet_Manager.instance.target != null)
                Magnet_Manager.instance.target.GetComponent<Renderer>().material.color = Color.white;

            Magnet_Manager.instance.target = this.gameObject;
            Magnet_Manager.instance.MoveObjects();
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (myPolarity == "blue")
        {
            if (other.gameObject.CompareTag("Positive2") == true) //blue square
            {
                gameObject.tag = "Untagged";
                gameObject.GetComponent<Renderer>().material.color = Color.white;
                Magnet_Manager.instance.PleaseCommentDownBelow(other.gameObject);
            }
        }
    }

}
