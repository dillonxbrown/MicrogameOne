using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float spd;
    Rigidbody2D bod;


    // Start is called before the first frame update
    private void Awake()
    {
        bod = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            bod.AddForce(Vector2.right * spd * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            bod.AddForce(-Vector2.right * spd * Time.deltaTime);
        }
    }
}
