using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SoldierStats : MonoBehaviour
{
    public SpriteRenderer teamSprite;
    public Slider healthSlider;

    public Color playerColor = new Color();
    public Color computerColor = new Color();

    private void Start()
    {
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

}
