using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresseableButton : MonoBehaviour
{
    public Sprite unpressedSprite;
    public Sprite pressedSprite;
    bool isPressed = false;
    public bool stayPressedState = false;
    SpriteRenderer spriteRender;
    public BeTriggered triggeredItem;

    // Start is called before the first frame update
    void Start()
    {
        Globals.Instance.buttons.Add(gameObject);
        spriteRender = GetComponent<SpriteRenderer>();
        spriteRender.sprite = unpressedSprite;
    }

    public void Press()
    {
        Debug.Log("press");
        spriteRender.sprite = pressedSprite;
        triggeredItem.turnOn();
    }
    public void UnPress()
    {

        Debug.Log("unpress");
        spriteRender.sprite = unpressedSprite;
        triggeredItem.turnOff();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Move>())
        {
            if (!stayPressedState)
            {
                UnPress();
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
