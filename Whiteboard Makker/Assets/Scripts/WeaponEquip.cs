using UnityEngine;

public class WeaponEquip : MonoBehaviour
{
    public GameObject pistol; 
   // public GameObject hammer;
    public string tmp;

    private void Awake()
    {
        WeaponToEquip("na");
    }
    private void Update()
    {
        //WeaponToEquip(tmp);
    }
    public void WeaponToEquip(string weapon)
    {
        if (weapon == "pistol")
        {
            pistol.SetActive(true); 
            //hammer.SetActive(false);
        }
        else if(weapon =="hammer")
        {
            pistol.SetActive(false);
            //hammer.SetActive(true);
        }
        else
        {
            pistol.SetActive(false);
            //hammer.SetActive(false);
        }

    }
}
