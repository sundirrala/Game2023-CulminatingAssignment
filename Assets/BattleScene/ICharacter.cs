using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICharacter : MonoBehaviour
{
    public int hp = 10;

    [SerializeField]
    private int hpMax = 10;

    [SerializeField]
    Ability[] abilities = new Ability[4];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UseAbility(int id)
    {
        //abilities[id].
    }

    public void TakeTurn()
    {
    }
}
