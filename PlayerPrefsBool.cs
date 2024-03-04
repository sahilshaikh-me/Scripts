using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefs2 : MonoBehaviour
{
    public static void SetBool(string key, bool state)
    {
        PlayerPrefs.SetInt(key, state ? 1 : 0);
    }

    public static bool GetBool(string key)
    {
        return (PlayerPrefs.GetInt(key) == 1);
    }

    /*working
     *  if (PlayerPrefs2.GetBool("MovieAlreadyShown"))
        {
            Debug.Log("Second works");
        }
        else
        {
           
            Debug.Log("firsttime works");
        }
     * 
     * */
}
