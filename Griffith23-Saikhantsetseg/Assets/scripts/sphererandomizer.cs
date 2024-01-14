using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphererandomizer : MonoBehaviour
{
    public float Size; //float is any number that has decimals e.g. 1.2
    public float YSizeMultiplier;

    public int TestInt; //int is a whole number

    public string Name; //string is a series of characters e.g. "Bob"

    public bool Exists; //bool is a condition that is either true or false

    //public Color myColor; 
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = new Vector3(x: Size, y: Size*YSizeMultiplier, z: Size);
        gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }
}
