using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridMark : MonoBehaviour
{
    bool Selected;
    [SerializeField] GameObject SelectedGridmark;
    [SerializeField] float yOffset;
    GameObject OBJ;
    GameObject[] towerOBJ = new GameObject[10];
    Vector3 objectPosition;
    Vector3 towerPosition;
    [Header("towerSettings")]
    [SerializeField] float Size = 3.5f;
    [SerializeField] Vector3 Offset;
    
    void Start()
    {
        OBJ =  Instantiate(SelectedGridmark, new Vector3(transform.position.x,(transform.position.y - yOffset), transform.position.z), transform.rotation);
        OBJ.SetActive(false);
        objectPosition = OBJ.transform.position;
        //tower stuff
        //fire tower
        towerOBJ[0] = instancer_objectPooling.instance.SpawnFromOBJPool("FireTower", transform.position, transform.rotation, false);//Instantiate(Towers[0], transform.position, transform.rotation);
        towerOBJ[0].transform.localScale = new Vector3(Size, Size, Size);
        towerPosition = towerOBJ[0].transform.position;
        towerOBJ[0].SetActive(false);
        towerOBJ[1] = instancer_objectPooling.instance.SpawnFromOBJPool("iceTower", transform.position, transform.rotation, false);//Instantiate(Towers[0], transform.position, transform.rotation);
        towerOBJ[1].transform.localScale = new Vector3(Size, Size, Size);
        towerPosition = towerOBJ[1].transform.position;
        towerOBJ[1].SetActive(false);
        //

    }


    void Update()
    {
        //if(UIManager.instance.selectedBuilding == 1)
        //{
            if (Selected)
            {
                OBJ.SetActive(true);
                OBJ.transform.position = Vector3.Lerp(OBJ.transform.position, new Vector3(OBJ.transform.position.x, (objectPosition.y + yOffset), OBJ.transform.position.z), 0.11f);
                towerOBJ[0].transform.position = Vector3.Lerp(towerOBJ[0].transform.position, new Vector3(towerOBJ[0].transform.position.x, (towerPosition.y + (Offset.y / 1.5f)), towerOBJ[0].transform.position.z), 0.11f);
            }
            else
            {
                if (towerPosition.y <= (OBJ.transform.position.y + Offset.y))
                {
                    towerOBJ[0].transform.position = new Vector3(OBJ.transform.position.x, OBJ.transform.position.y + Offset.y, OBJ.transform.position.z);
                }


                OBJ.transform.position = Vector3.Lerp(OBJ.transform.position, new Vector3(OBJ.transform.position.x, (objectPosition.y - yOffset), OBJ.transform.position.z), 0.1f);
                towerOBJ[0].transform.position = Vector3.Lerp(towerOBJ[0].transform.position, new Vector3(towerOBJ[0].transform.position.x, (towerPosition.y - yOffset), towerOBJ[0].transform.position.z), 0.1f);
                if (objectPosition == OBJ.transform.position)
                {
                    OBJ.SetActive(false);
                }

            }
        //}
        //if (UIManager.instance.selectedBuilding == 0)
        //{
            if (Selected)
            {
                OBJ.SetActive(true);
                OBJ.transform.position = Vector3.Lerp(OBJ.transform.position, new Vector3(OBJ.transform.position.x, (objectPosition.y + yOffset), OBJ.transform.position.z), 0.11f);
                towerOBJ[1].transform.position = Vector3.Lerp(towerOBJ[1].transform.position, new Vector3(towerOBJ[1].transform.position.x, (towerPosition.y + (Offset.y / 1.5f)), towerOBJ[1].transform.position.z), 0.11f);
            }
            else
            {
                if (towerPosition.y <= (OBJ.transform.position.y + Offset.y))
                {
                    towerOBJ[1].transform.position = new Vector3(OBJ.transform.position.x, OBJ.transform.position.y + Offset.y, OBJ.transform.position.z);
                }


                OBJ.transform.position = Vector3.Lerp(OBJ.transform.position, new Vector3(OBJ.transform.position.x, (objectPosition.y - yOffset), OBJ.transform.position.z), 0.1f);
                towerOBJ[1].transform.position = Vector3.Lerp(towerOBJ[1].transform.position, new Vector3(towerOBJ[1].transform.position.x, (towerPosition.y - yOffset), towerOBJ[1].transform.position.z), 0.1f);
                if (objectPosition == OBJ.transform.position)
                {
                    OBJ.SetActive(false);
                }

            }
        //}

    }
    private void LateUpdate()
    {
        Selected = false;
    }

    public void OnSelected()
    {
        Selected = true;
    }
    public void PlaceTower()
    {
        //fire
       if(UIManager.instance.selectedBuilding == 1 && UIManager.instance.IncreaseScore(true, true) >= 3)
       {
            towerOBJ[0].SetActive(true);
            UIManager.instance.money -= 3;
        }
       //normal
        if (UIManager.instance.selectedBuilding == 0 && UIManager.instance.IncreaseScore(true, true) >= 1)
        {
            UIManager.instance.money -= 1;
            towerOBJ[1].SetActive(true);
            // EntityManager.instance.ThereisANewTower();
        }
    }
    public void RemSelected()
    {
        Selected = false;
        OBJ.transform.position = objectPosition;
        OBJ.SetActive(false);
    }
}
