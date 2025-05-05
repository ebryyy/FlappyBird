using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesisatci : MonoBehaviour
{
    private GameObject[] Holder;
    public float Min,Max;
    private float lastPipeX;
    private float distance = 3f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        Holder = GameObject.FindGameObjectsWithTag("PipeHolder");
        for (int i = 0; i < Holder.Length; i++)
        {
            Vector3 temp = Holder[i].transform.position;
            temp.y = Random.Range(Min,Max);
            Holder[i].transform.position = temp;
        }
        lastPipeX = Holder[0].transform.position.x;

        for (int i = 1; i < Holder.Length; i++)
        {
            if (lastPipeX < Holder[i].transform.position.x)
            {
                lastPipeX = Holder[i].transform.position.x;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == ("PipeHolder")){
            Vector3 temp = target.transform.position;
            temp.x = lastPipeX + distance;
            temp.y = Random.Range(Min,Max);
            
            target.transform.position = temp;
            lastPipeX = temp.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
