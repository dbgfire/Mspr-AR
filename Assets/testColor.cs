using UnityEngine;
using System.Collections.Generic;

public class testColor : MonoBehaviour {

	public List<Camera> RenderCameras;
	[Space(20)]
	public bool FreezeEnable = false;
    private bool SkinnedMesh;


    void Start () 
	{  
        for(int i=0;i< RenderCameras.Count ;i++ ){
            if (FreezeEnable && RenderCameras[i]) RenderCameras[i].enabled = false;
        }
        if (GetComponent<SkinnedMeshRenderer>()) SkinnedMesh = true;
        
    }

	private void Update() 
	{  
        for(int i=0;i< RenderCameras.Count ;i++ ){
            RenderTexture _rt=null;
            if (!RenderCameras[i]) return;
            if (!_rt && RenderCameras[i].targetTexture)
            {
                _rt = RenderCameras[i].targetTexture;
                if (SkinnedMesh) GetComponent<SkinnedMeshRenderer>().materials[i].SetTexture("_MainTex", RenderCameras[i].targetTexture);
                else GetComponent<MeshRenderer>().materials[i].SetTexture("_MainTex", RenderCameras[i].targetTexture);
            }

            if (_rt && _rt != RenderCameras[i].targetTexture) Destroy(_rt);
            
        }
    }
		
	void onGUI () 
	{
		  
            for(int i=0;i< RenderCameras.Count ;i++ ){
            
                if (FreezeEnable) RenderCameras[i].enabled = false;
			    else RenderCameras[i].enabled = true;
            }
            
	
	}
}