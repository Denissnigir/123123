using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
 

    [Header("Set in Inspector")]
    public float speed;
    public float upperForce;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if(Input.GetKeyDown(KeyCode.Space)) {
            Rigidbody2D birdRG = GetComponent<Rigidbody2D>();
            birdRG.velocity = Vector3.zero;
            birdRG.AddForce(Vector3.up * upperForce);
        }

        if (pos.y <= -5)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
