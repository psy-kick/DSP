using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField]
    LayerMask DisplayLayer;
    [SerializeField]
    GameObject Canvas;
    // Start is called before the first frame update
    void Start()
    {
        DisplayLayer = LayerMask.GetMask("Tree");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 50f, DisplayLayer))
        {
            Debug.Log("hit something");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.red);
            Canvas.SetActive(true);
        }
        else
        {
            Debug.Log("nothing");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.green);
            Canvas.SetActive(false);
        }
    }
}
