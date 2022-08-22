using System;
using System.Collections.Generic;
using TestRogueLike.Common;
using TestRogueLike.Game.Items;
using TestRogueLike.World.Characters.Players;
using UnityEngine;

public abstract class Chest : MonoBehaviour, Interactable
{
    protected List<Type> lootOptions;
    
    protected int loot;
    protected bool isOpened;
    public virtual void Interact(PlayerWorld player)
    {
        if (isOpened) 
            return;
        
        player.AddItem((Item) Activator.CreateInstance(lootOptions[loot]));
    }
}
