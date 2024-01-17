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
    LayerMask RockLayer;
    [SerializeField]
    LayerMask TerrainLayer;
    [SerializeField]
    GameObject Canvas;
    [SerializeField]
    TextMeshProUGUI textMeshProUGUI;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hitInfo, 50f, TreeLayer))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.red);
            Canvas.SetActive(true);
            Canvas.GetComponentInChildren<TextMeshProUGUI>().SetText("This is a Dragonblood Tree, " +
                "due to stronger gravity the trees are denser because of this the trees here have grown with thicker and wider trunk");
        }
        else if(Physics.Raycast(ray, out hitInfo, 50f, WaterLayer))
        {
            Canvas.SetActive(true);
            Canvas.GetComponentInChildren<TextMeshProUGUI>().SetText("The only large waterbodies found here are rivers and lakes" +
                " and because of this there is less greenery");
        }
        else if (Physics.Raycast(ray, out hitInfo, 50f, RockLayer))
        {
            Canvas.SetActive(true);
            Canvas.GetComponentInChildren<TextMeshProUGUI>().SetText("The rocks on this planet is simialar to earth and contains similar minerals");
        }
        else if (Physics.Raycast(ray, out hitInfo, 50f, TerrainLayer))
        {
            Canvas.SetActive(true);
            Canvas.GetComponentInChildren<TextMeshProUGUI>().SetText("Kepler 4552b is known for having a rocky terrain and not able to produce as much greenary as earth ");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.green);
            Canvas.SetActive(true);
            Canvas.GetComponentInChildren<TextMeshProUGUI>().SetText("Data not available or your scanning something else");
        }
    }
}
