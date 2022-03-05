using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemClass
{
    public enum ItemPrefabOrder
    {
        Muffler, Letter, Note, CardKey,
        PocketWatch, CabinetKey, Sword1, Sword2,
        Fruit, Leaf, Branch, Sap, PianoMemo, MonsterEssence, Flesh1, Flesh2, PatternLeaf, Liquid,
        Dagger, RedJewel
    }
    public int prefabOrder;

    public ItemClass(ItemPrefabOrder order)
    {
        prefabOrder = (int)order;
    }
}
