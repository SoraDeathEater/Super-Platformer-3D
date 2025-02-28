using UnityEngine;

[CreateAssetMenu(menuName = "Player Stats")]
public class PLayerStats : ScriptableObject
{
    public int health;
    public int maxHealth;
    public int moveSpeed;
    public int jumpForce;
    public int gravity;


}
