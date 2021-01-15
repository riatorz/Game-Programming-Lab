using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedToGreen : MonoBehaviour
{
    public bool isgreen;
    public Material red;
    public Material green;
    int sayac = 0;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Top")
        {
            GetComponent<MeshRenderer>().material = green;
            Destroy(collision.collider);
            isgreen = true;
        }
        else
        {
            GetComponent<MeshRenderer>().material = red;
            
        }
    }
}
