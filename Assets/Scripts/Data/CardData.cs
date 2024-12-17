using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardData
{
    [SerializeField]
    private string _identifier;

    [SerializeField, SpritePreview]
    private Sprite _sprite;

    [SerializeField, Range(-180, 180)]
    private int angle = 0;

    public string Identifier => _identifier;

    public Sprite Sprite => _sprite;

    public int Angle => angle;
}
