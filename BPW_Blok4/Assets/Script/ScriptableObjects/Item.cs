﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class Item : ScriptableObject
{
	public Sprite itemSprite;
	public string itemDescription;
	public bool isKey;
    public bool isCoin;
    public bool isMasterKey;
    public bool isApple;
    public bool isEnemyTooth;

}
