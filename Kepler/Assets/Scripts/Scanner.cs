using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class Scanner : MonoBehaviour
{
    [SerializeField]
    LayerMask TreeLayer;
    [SerializeField]
    LayerMask WaterLayer;
    [SerializeField]
    LayerMask TerrainLayer;
    [SerializeField]
    GameObject Canvas;
    [SerializeField]
    TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hitInfo, 50f, TreeLayer))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.red);
            Canvas.SetActive(true);
            Canvas.GetComponentInChildren<TextMeshProUGUI>().SetText("This is a Dragonblood Tree");
        }
        else if(Physics.Raycast(ray, out hitInfo, 50f, WaterLayer))
        {
            Canvas.SetActive(true);
            Canvas.GetComponentInChildren<TextMeshProUGUI>().SetText("This is water");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.green);
            Canvas.SetActive(false);
        }
    }
}
