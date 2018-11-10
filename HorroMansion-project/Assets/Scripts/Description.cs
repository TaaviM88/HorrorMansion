using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Description : Interactable {

    public string description = "Add here cool description";

    public override void Interact()
    {
        base.Interact();

        Journal.Instance.Log(description);
    }

}
