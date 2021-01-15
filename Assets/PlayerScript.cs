using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public CharacterController controller;
    public Transform top;
    public GameObject yTop;
    private string selectedtag = "Top";
    public float speed = 12f;
    public int topsayisi = 0;
    GameObject yenitop;
    Queue que = new Queue();
    public Canvas cvs;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,5))//silah alma
        {
            
            var secilecek = hit.transform;
            if(secilecek.CompareTag(selectedtag))
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    yenitop = (GameObject)Instantiate(yTop);
                    yenitop.transform.position = top.transform.position;
                    yenitop.transform.parent = gameObject.transform;
                    que.Enqueue("Top" + topsayisi);
                    topsayisi++;
                    
                }
            }
        }
        if(Input.GetMouseButton(0))
        {
            if(topsayisi != 0)
            {
                yenitop.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                Debug.Log(que.Dequeue());
                topsayisi--;
            }
                
        }
        
        if (GameObject.Find("Etkilesim1").GetComponent<RedToGreen>().isgreen
            && GameObject.Find("Etkilesim2").GetComponent<RedToGreen>().isgreen)
        {
            StartCoroutine(Bekletme());
            GameObject.Find("Etkilesim2").GetComponent<RedToGreen>().isgreen = false;

        }
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 hareket = transform.right * x + transform.forward * z;
        controller.Move(hareket * speed * Time.deltaTime);
    }
    IEnumerator Bekletme()
    {
        yield return new WaitForSeconds(3);
        Instantiate(cvs);
    }
}
