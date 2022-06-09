using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPC : MonoBehaviour
{
    public Item[] RequirementBuildPC;
    public bool isReadyToUse;

    private void Update () {
        for (int i = 0; i < RequirementBuildPC.Length; i++)
        {
            if(RequirementBuildPC[i].isAdded) {
                isReadyToUse = true;
            } else {
                isReadyToUse = false;
                break;
            }
        }
    }

    private void SetRequirement(Item item, bool state) {
        Item isItemExist = MatchRequirement(item);
        if(isItemExist == null) return;

        for (int i = 0; i < RequirementBuildPC.Length; i++)
        {
            if(item.id == RequirementBuildPC[i].id) {
                RequirementBuildPC[i].isAdded = state;
                if(state) 
                    Debug.Log("Add PartOfComputer : " + RequirementBuildPC[i].name);
                else 
                    Debug.Log("Remove PartOfComputer : " + RequirementBuildPC[i].name);
            }
        }
    }

    private Item MatchRequirement (Item item) {
        for (int i = 0; i < RequirementBuildPC.Length; i++)
        {
            if(item.id == RequirementBuildPC[i].id) {
                Debug.Log("Komponen yang masuk kedalam kotak tersebut cocok dengan salah satu persyaratan : " + item.name);
                return item;
            }
        }
        Debug.Log("Komponen yang masuk kedalam kotak tersebut tidak cocok dengan salah satu persyaratan : " + item.name);
        return null;
    }

    private void OnTriggerEnter(Collider other) {
        PartOfComputer poc = other.transform.GetComponent<PartOfComputer>();
        if(poc != null) {
            SetRequirement(poc.item, true);
        }
    }

    private void OnTriggerExit(Collider other) {
        PartOfComputer poc = other.transform.GetComponent<PartOfComputer>();
        if(poc != null) {
            SetRequirement(poc.item, false);
        }
    }
}

[System.Serializable]
public class Item {
    public int id;
    public string name;
    public bool isAdded;
}
