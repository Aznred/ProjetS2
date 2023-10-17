using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(menuName = "Scriptable object/Ennemy" + "")]
public class Ennemy : ScriptableObject
{
    public string name;
    public Sprite Mobimage;
    public int Damage;
    public int Health;
    public int Dexterity;
    public int Resistance;
    public int Magic;
    public int Intelligence;
    public EnemyType type;
    public enum EnemyType
    {
        Enemy,
        Ally
    }
}
