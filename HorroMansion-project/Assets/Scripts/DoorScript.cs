using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : Interactable {

    Animator anime;
    public bool isLocked = false;
    bool doorIsOpen = false;
    public bool isDoubleDoor = true;
    public float closingTime = 4f;
    float countdown;
    public string DoorDescription = "hey, this is a door";
    public string hintIfDoorIsLocked = "Hey, this is door is locked";
    public GameObject door1;
    public GameObject door2;
    
    
	// Use this for initialization
	void Start () {
        anime = GetComponent<Animator>();
        countdown = closingTime;
        if(door1 == null || door2 == null)
        {
            return;
        }
	}

    public override void Interact()
    {
        base.Interact();
        if(!doorIsOpen)
        {
            InteractiveDoor(true);
        }
    }

    // Update is called once per frame
    void Update ()
    {

        if(doorIsOpen)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                //suljetaan ovi tietyn ajanpäästä
                InteractiveDoor(false);
            }
        }
        
	}


    //Avataan tai suljetaan ovi
    public void InteractiveDoor(bool open)
    {
        if(!isLocked)
        {
            //katotaan avaanko ovi vai suljetaanko se
            doorIsOpen = open;
            anime.SetBool("OpenDoor", open);

            if (open == true)
            {
                // Laitetaan ovien colliderit triggeriksi että päästään läpi
                Collider col1 = door1.GetComponent<Collider>();
                if(col1 != null)
                {
                    col1.isTrigger = true;
                }

                if (isDoubleDoor == true)
                {
                    Collider col2 = door2.GetComponent<Collider>();
                    if (col2 != null)
                    {
                        col2.isTrigger = true;
                    }
                }
                countdown = closingTime;
            }
            else
            {
                //Laitetaan ovien colliderit kiinteiksi että päästään läpi
                Collider col1 = door1.GetComponent<Collider>();
                if(col1 != null)
                {
                    col1.isTrigger = false;
                }
                if (isDoubleDoor == true)
                {
                    Collider col2 = door2.GetComponent<Collider>();
                    if (col2 != null)
                    {
                        col2.isTrigger = false;
                    }
                }  
            }
        }
        else
        {
            //Mikäli ovi on lukossa niin kutsutaan tätä
            InformJournalDoorIsLocked();
        }
        
    }

    //varmuudeksi jos ei jostain syystä pysty pääsemään käsiksi suoraan iteractvibedoo methodiin.
    public void OpenDoor()
    {
        InteractiveDoor(true);

    }
   
    public void CloseDoor()
    {
        InteractiveDoor(false);
        
    }

    //Kerrotaan Journanille vinkki että miksi ovi ei aukene
    public void InformJournalDoorIsLocked()
    {
       
        Journal.Instance.Log(hintIfDoorIsLocked);
    }
}
