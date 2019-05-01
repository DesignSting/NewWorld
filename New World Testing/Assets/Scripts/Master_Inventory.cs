using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master_Inventory : MonoBehaviour {

    public static Master_Inventory Instance = null;
    public int arrayLength;
    public int weaponDMG;

    public List<WeaponsList> m_WeaponsList = new List<WeaponsList>();
    //public List<ResourcesList> m_ResourcesList = new List<ResourcesList>();

    void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        arrayLength = m_WeaponsList.Count;
        RunThis();
    }

    public void Update()
    {
        
    }

    public void RunThis()
    {
        for(int i=0;i<m_WeaponsList.Count; i++)
        {
            Debug.Log(m_WeaponsList[i].GetDamage());
        }
    }
}
