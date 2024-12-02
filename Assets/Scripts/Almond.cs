using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Almond : MonoBehaviour
{
    [SerializeField] private GameObject appleBack;
    [SerializeField] private GameController controller;

    public void OnMouseDown()
    {
        if(appleBack.activeSelf && controller.canReveal)
        {
            appleBack.SetActive(false);
            controller.CardRevealed(this);
        }
    }

    private int _id;
    public int id
    { 
        get { return _id; }
    }

    public void ChangeSprite(int id, Sprite image)
    {
        _id = id;

        //Gets sprite and changes property
        GetComponent<SpriteRenderer>().sprite = image;
    }

    public void Unreveal()
    {
        appleBack.SetActive(true);
    }
}
