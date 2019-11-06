using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = new Vector3(2, 0, 0);
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.position -= distance;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.gameObject.transform.position += distance;
        }

    }
}
