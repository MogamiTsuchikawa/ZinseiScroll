using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] GameObject haikeiNaka;
    [SerializeField] GameObject haikeiUe;
    [SerializeField] GameObject haikeiNakaPrefab;
    [SerializeField] GameObject haikeiUePrefab;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i < 100; i++)
        {
            var naka = Instantiate(haikeiNakaPrefab);
            naka.transform.position = new Vector3(19.2f * i, 0, 30);
            naka.transform.parent = haikeiNaka.transform;
            var ue = Instantiate(haikeiUePrefab);
            ue.transform.position = new Vector3(19.2f * i, 0, 30);
            ue.transform.parent = haikeiUe.transform;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(moveSpeed, 0, 0);
        haikeiNaka.transform.position += new Vector3(moveSpeed / 2, 0, 0);
        haikeiUe.transform.position += new Vector3(moveSpeed / 3, 0, 0);
    }
}
