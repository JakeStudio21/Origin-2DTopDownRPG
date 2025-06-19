using UnityEngine;

[CreateAssetMenu(fileName = "SelectedPlayerData", menuName = "Game/SelectedPlayerData")]
public class SelectedPlayerData : ScriptableObject
{
    public PlayerClass selectedClass;
}

public enum PlayerClass
{
    None,
    Warrior,
    Assassin
}
