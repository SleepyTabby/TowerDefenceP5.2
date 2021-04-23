using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectingPicker : MonoBehaviour
{
    [SerializeField] Camera Selectioncamera;
    //public gridMark mark;

    void Start()
    {
        
    }


    void Update()
    {
        RaycastHit hit;
        Ray ray = Selectioncamera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            hit.collider.gameObject.SendMessage("OnSelected");
            if (Input.GetMouseButtonDown(0))
            {
                hit.collider.gameObject.SendMessage("PlaceTower", 1);
            }
            
        }
        
    }
}
