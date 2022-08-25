using System;
using System.Collections.Generic;
using TestRogueLike.Common;
using TestRogueLike.Game.Characters.Players;
using TestRogueLike.Game.Items;
using TestRogueLike.World.Characters.Players;
using UnityEngine;

public abstract class Chest : MonoBehaviour, Interactable
{
    protected List<Type> LootOptions;
    
    protected int Loot;
    protected bool IsOpened;
    
    public virtual void Interact(PlayerWorld player)
    {
        if (IsOpened) 
            return;
        
        Inventory.Instance.AddItem((Item) Activator.CreateInstance(LootOptions[Loot]));
    }
}
