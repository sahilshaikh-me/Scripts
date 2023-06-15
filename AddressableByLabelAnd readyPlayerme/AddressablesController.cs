using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

public class AddressablesController : MonoBehaviour
{
	[SerializeField]
	private string _label;
	private Transform _parent;
	private List<GameObject> _createdObjs { get; } = new List<GameObject>();


	private void Start()
	{
		_parent = GameObject.Find("AddressableTest").transform;
		
	}
	
	private async void Instantiate()
	{
		await AddressablesLoader.InitAssets("machine", _createdObjs, _parent);
		//Debug.Log(AddressablesLoader.InitAssets(_label, _createdObjs, _parent));
		//await AddressablesLoader.InitAssets("mat", _createdMat, _parent);
	}
	private void Update()
	{
        if (Input.GetKeyDown(KeyCode.H))
        {
			Debug.Log($"Machine Load. [{Time.timeSinceLevelLoad:F2}]");
			Instantiate();
		}

	}
	private void OnGUI()
	{
		foreach (var item in _createdObjs)
		{

			GUI.Label(new Rect(100, 100, 100, 1000), item.name);
		}
	}
}


public class Load{

        void Start()
	{
		AsyncOperationHandle<IResourceLocator> loadContentCatalogAsync = Addressables.LoadContentCatalogAsync(
		 @"http://localhost/addressables/catalog_2021.12.09.10.54.40.json");
		loadContentCatalogAsync.Completed += OnCompleted;
	}
	private void OnCompleted(AsyncOperationHandle<IResourceLocator> obj)
	{
		Addressables.InstantiateAsync("cube");
		Addressables.InstantiateAsync("sphere");
	}





}
