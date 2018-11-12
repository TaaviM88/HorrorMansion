using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRequired : Interactable {

    public Equipment requiredItem;

   
    //Add this if you want spawn new item after player has "solve the puzzle"
    //public GameObject spawnItem;
    public GameObject spawnObject;
    public Transform spawnpoint;
    bool puzzleIsSolved = false;
    public string puzzleHint = " Here cool hint for player.";
    public string puzzleSolved = "Hey, you have already solve this.";

    private void Awake()
    {
        spawnpoint.gameObject.SetActive(false);
    }


    public override void Interact()
    {
        base.Interact();
        if (!puzzleIsSolved)
        {
            //tsekataan jos pelaajalla on 
            Equipment e = EquipmentManager.instance.ReturnCurrentEquipment();
            if (requiredItem.name == e.name)
            {
                /* GameObject newSpawnObject = Instantiate<GameObject>(spawnObject);
                 newSpawnObject.transform.position = new Vector3(0, 0, 0);
                 newSpawnObject.transform.parent = spawnpoint.transform;*/

                spawnpoint.gameObject.SetActive(true);
                puzzleIsSolved = true;
                // GameObject newSpawnItem = Instantiate<GameObject>(spawnItem);

            }
            else
            {
                WriteToJournal(puzzleHint);
            }

        }
        else
            WriteToJournal(puzzleSolved);
    }


    private void WriteToJournal(string text)
    {
        Journal.Instance.Log(text);
    }

}
