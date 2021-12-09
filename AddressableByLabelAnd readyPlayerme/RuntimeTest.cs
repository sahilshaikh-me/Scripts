using UnityEngine;
using Wolf3D.ReadyPlayerMe.AvatarSDK;
using Photon.Pun;
using System.Collections;

public class RuntimeTest : MonoBehaviour
{
    [SerializeField] private string AvatarURL = "https://d1a370nemizbjq.cloudfront.net/209a1bc2-efed-46c5-9dfd-edc8a1d9cbe4.glb";
    //  public GameObject PlayerRef;
   
    public static RuntimeTest Instance { get; set; }

    private void Start()
    {
        LoadAvatarCustom();

       
    }
    public void LoadAvatarCustom()
    {
        Debug.Log($"Started loading avatar. [{Time.timeSinceLevelLoad:F2}]");
        AvatarLoader avatarLoader = new AvatarLoader();
        avatarLoader.LoadAvatar(AvatarURL, OnAvatarImported, OnAvatarLoaded);
    }
    private void Update()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void OnAvatarImported(GameObject avatar)
    {
        Debug.Log($"Avatar imported. [{Time.timeSinceLevelLoad:F2}]");
        avatar.transform.SetParent(this.gameObject.transform);

    }

    private void OnAvatarLoaded(GameObject avatar, AvatarMetaData metaData)
    {
        Debug.Log($"Avatar loaded. [{Time.timeSinceLevelLoad:F2}]\n\n{metaData}");
        StartCoroutine(DeleteAfterSomtime(avatar));

    }
    IEnumerator DeleteAfterSomtime( GameObject obj)
    {
        yield return new WaitForSeconds(4);
        Destroy(obj);
    }

}
