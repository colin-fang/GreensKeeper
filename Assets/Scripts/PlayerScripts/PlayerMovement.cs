using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    public FloatValue currentHealth;
    public SignalObject playerHealthSignal;
    public VectorValue startingPosition;
    public Inventory playerInventory;
    public SpriteRenderer receivedItemSprite;
    public SignalObject playerHit;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startingPosition.initialValue;
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Is the player in an interaction?
        if (currentState == PlayerState.interact)
        {
            return;
        }
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (change != Vector3.zero && currentState == PlayerState.walk)
        {
            MoveCharacter();
        }

    }

    void MoveCharacter()
    {
        change.Normalize();
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    public void Knock(float knockDuration, float damage)
    {
        currentHealth.RuntimeValue -= damage;
        playerHealthSignal.Raise();
        if (currentHealth.RuntimeValue > 0)
        {
            StartCoroutine(KnockCo(knockDuration));
        }
        else
        {
            this.gameObject.SetActive(false);
        }

    }

    private IEnumerator KnockCo(float knockDuration)
    {
        playerHit.Raise();
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockDuration);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.walk;
            myRigidbody.velocity = Vector2.zero;
        }
    }


    public void RaiseItem()
    {
        if(playerInventory.currentItem != null)
        {
            if(currentState != PlayerState.interact)
            {
                currentState = PlayerState.interact;
                receivedItemSprite.sprite = playerInventory.currentItem.itemSprite;
            }
            else
            {
                currentState = PlayerState.walk;
                receivedItemSprite.sprite = null;
                playerInventory.currentItem = null;
            }
        }
        
       
    }
}