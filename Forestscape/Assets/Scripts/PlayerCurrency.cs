using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerCurrency")]
public class PlayerCurrency : ScriptableObject
{
    [SerializeField] public int playerMoney;

    public int Money => playerMoney;
}
