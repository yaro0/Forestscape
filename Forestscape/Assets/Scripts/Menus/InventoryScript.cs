using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "InventoryScript")]
public class InventoryScript : ScriptableObject
{
    [SerializeField] public Hashtable inventory = new Hashtable(){
	{1, false},
	{2, false},
	{3, false}
};
    
    public Hashtable Inventory => inventory;
}
