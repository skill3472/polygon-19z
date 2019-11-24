using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    [SerializeField] public int damage;
    [SerializeField] public string damageType;
    [SerializeField] public float attackRate;
    [SerializeField] public bool malee;

    public abstract void First();
    public abstract void Second();
}
