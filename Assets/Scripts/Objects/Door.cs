using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy,
    button
}

public class Door : Interactable {

    [Header("Door variables")]
    public DoorType thisDoorType;
    public bool open = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerInRange && thisDoorType == DoorType.key)
            {
                //if player has key call the open method
                if(playerInventory.numberOfKeys > 0)
                {
                    //remove player key
                    playerInventory.numberOfKeys--;
                    Open();
                }
            }
        }
    }

    public void Open()
    {
        //turn off the door's sprite renderer
        doorSprite.enabled = false;
        //set open to true
        open = true;
        //turn off the door's box collider
        physicsCollider.enabled = false;
    }

    public void Close()
    {

    }

}
