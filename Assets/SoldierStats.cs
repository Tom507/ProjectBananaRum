using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SoldierStats : MonoBehaviour
{
    public Transform looktarget;
    public SpriteRenderer teamSprite;
    public Slider healthSlider;

    public Color playerColor = new Color();
    public Color computerColor = new Color();

    private SpriteRenderer spriteRenderer;
    public Sprite swordSprite;
    public Sprite axesprite;
    public Sprite lanceSprite;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Soldier.Weapon w = GetComponentInParent<Soldier>().weapon;
        switch (w)
        {
            case Soldier.Weapon.Sword:
                spriteRenderer.sprite = swordSprite;
                break;
            case Soldier.Weapon.Axe:
                spriteRenderer.sprite = axesprite;
                break;
            case Soldier.Weapon.Lance:
                spriteRenderer.sprite = lanceSprite;
                break;
        }
        looktarget = GameObject.FindGameObjectsWithTag("LookTarget")[0].transform;
        StartCoroutine(Utils.ExecuteAfterSeconds(0.2f, () =>
            {
                if (GetComponentInParent<Soldier>().side == Soldier.Side.Player)
                {
                    teamSprite.color = playerColor;
                }
                else
                {
                    teamSprite.color = computerColor;
                }
            }));
    }
    private void Update()
    {
        transform.LookAt(looktarget);
    }

}
