using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VoxelBusters.NativePlugins;

public class ShareScript : MonoBehaviour
{
    private string msg;
    private string Url ="   "+ " https://play.google.com/store/apps/details?id=com.Sahill.Dino3D ";
    // Start is called before the first frame update
    void Start()
    {
        msg =  "  I cant belive i scored  " + "  " + PlayerPrefs.GetInt("highScore", 0).ToString() + " Click Here To Play This Game ";

    }
    public void FinishShare(eShareResult result)
    {
        Debug.Log("Finish Sharing :"+ result +msg+Url);
    }

  public void Share()
    {
        ShareSheet ss = new ShareSheet();
        ss.Text = msg;
        ss.URL = Url;

        NPBinding.UI.SetPopoverPointAtLastTouchPosition();
        NPBinding.Sharing.ShowView(ss, FinishShare);
    }
}
