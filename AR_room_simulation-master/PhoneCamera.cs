using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneCamera : MonoBehaviour
{
    
    private bool camAvailable;
    private WebCamTexture backCam;
    public Texture defaultBackground;
    public Camera camera1;
    private static PhoneCamera instance;
    public Button capture;
        public Button retry;
    public bool cam = false;
    
    
    
    public RawImage background;
    public AspectRatioFitter fit;
    
    
    public GameObject canvasCam;
    public Button camCheck;
    

    
    


    private bool takeScreenShotOnNextFrame;

       private void OnPostRender() {
           if (takeScreenShotOnNextFrame) {
               takeScreenShotOnNextFrame = false;
               RenderTexture renderTexture = camera1.targetTexture;
               
               Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
               
               Rect rect = new Rect(0,0,renderTexture.width, renderTexture.height);
               renderResult.ReadPixels(rect, 0, 0);
               
               
               background.texture = renderResult;
               
               RenderTexture.ReleaseTemporary(renderTexture);
               camera1.targetTexture = null;
           
           }
       }
       
       private void TakeScreenshot(int width, int height)
       {
           camera1.targetTexture = RenderTexture.GetTemporary(width, height, 16);
           takeScreenShotOnNextFrame = true;
       }
       
        void  TakeScreenshot_Static() {
           int width = 500;
           int height = 500;
           TakeScreenshot(width, height);
       }
    
    void Cam() {
        backCam.Pause();
    }
    
    void CamAgain() {
        backCam.Play();
    }
    
    void canvasCamera() {
        canvasCam.transform.gameObject.SetActive(true);
        camCheck.transform.gameObject.SetActive(false);
        retry.transform.gameObject.SetActive(false);
        capture.transform.gameObject.SetActive(false);
    }
    
   
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        camera1 =GameObject.Find("Main Camera").GetComponent<Camera>();
        capture = GameObject.Find("CanvasCam/ButtonCam").GetComponent<Button>();
        retry = GameObject.Find("CanvasCam/ButtonWrong").GetComponent<Button>();
        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;
        canvasCam = GameObject.Find("CanvasCam/Background");
        camCheck = GameObject.Find("CanvasCam/ButtonCheck").GetComponent<Button>();
        
        if(devices.Length == 0)
        {
            Debug.Log("No camera detected");
            return;
        }
        
        for (int i = 0; i < devices.Length; i++)
        {
            if(!devices[i].isFrontFacing)
            {
                backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
                
            }
        }
        
        if(backCam == null)
        {
            Debug.Log("Unable to find camera");
            return;
        }
        
        backCam.Play();
        background.texture = backCam;
        
        camAvailable = true;
    }
    

    // Update is called once per frame
    void Update()
    {
        
        camCheck.onClick.AddListener(canvasCamera);
        
        capture.onClick.AddListener(Cam);
        retry.onClick.AddListener(CamAgain);
        if(!camAvailable )
            return;
       
        float ratio = (float)backCam.width / (float)backCam.height;
        fit.aspectRatio = ratio;
        
        float scaleY = backCam.videoVerticallyMirrored ? -1f: 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);
        
        int orient  = -backCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
        
    }
}
