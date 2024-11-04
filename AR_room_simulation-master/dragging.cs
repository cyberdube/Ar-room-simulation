    using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class dragging : MonoBehaviour {


            BoxCollider m_Collider;
    
    
            GameObject gObj = null;
    
            Plane objPlane;
            Vector3 m0;
    public bool wall = true;
        
            public GameObject side;
            public GameObject floor;
            public GameObject back;
            public GameObject side1;
            public Camera camera1;
            public Camera camera2;
            public GameObject ceiling;
            public GameObject rotate;
    public GameObject walls;
    public GameObject panel;
    public GameObject navbarfirst;
    public GameObject navbarsecond;
    public GameObject menuBar;

    public Button pushNext;
    public Button pushBack;
    public Button pushDone;
    public float metricValue;
    public GameObject menuBarCanvas;
   
    public InputField metric;
    
    private static dragging instance;
    public GameObject model;
    public GameObject modelCanvas;
    
    
    public Button camButtonWrong;
    public Button camButtonPic;
    public GameObject camBackground;
    public Button camButtonCheck;
    
    
    private bool camAvailable;
    private WebCamTexture backCam;
    private Texture defaultBackground;
    private bool takeScreenShotOnNextFrame;
    
    public RawImage background;
    public AspectRatioFitter fit;
    
 
   
   
    
            
    void Start()
    {
        
      
          
         
        walls = GameObject.Find("Walls");
             side = GameObject.Find("Walls/Side");
             floor = GameObject.Find("Walls/Floor");
             back = GameObject.Find("Walls/Back");
            side1 = GameObject.Find("Walls/Side1");
            ceiling = GameObject.Find("Walls/Ceiling");
            camera1 = GameObject.Find("Main Camera").GetComponent<Camera>();
            camera2 = GameObject.Find("Camera").GetComponent<Camera>();
            rotate = GameObject.Find("Sphere");
        pushNext = GameObject.Find("Canvas/NavBarFirst/ButtonNext").GetComponent<Button>();
        pushBack = GameObject.Find("Canvas2/NavBarSecond/ButtonBack").GetComponent<Button>();
        pushDone = GameObject.Find("Canvas2/NavBarSecond/ButtonDone").GetComponent<Button>();
        metric = GameObject.Find("Canvas2/NavBarSecond/Panel/InputHeight").GetComponent<InputField>();


        navbarsecond = GameObject.Find("Canvas2/NavBarSecond");
        navbarfirst = GameObject.Find("Canvas/NavBarFirst");
        panel = GameObject.Find("Canvas2/NavBarSecond/Panel");
        
        menuBar = GameObject.Find("Menu");
        menuBarCanvas = GameObject.Find("Menu/Image/Chairs/ChairCanvas");
        
        modelCanvas = GameObject.Find("Menu/Image/Chairs/ChairCanvas/Chair1");
        model =GameObject.Find("Chair");
        
        camButtonCheck = GameObject.Find("CanvasCam/ButtonCheck").GetComponent<Button>();
        camButtonPic = GameObject.Find("CanvasCam/ButtonCam").GetComponent<Button>();
        camButtonWrong = GameObject.Find("CanvasCam/ButtonWrong").GetComponent<Button>();
        camBackground = GameObject.Find("CanvasCam/Background");
        
        

        
        
        
        
        
        
        menuBar.transform.gameObject.SetActive(false);
        navbarfirst.transform.gameObject.SetActive(false);
        navbarsecond.transform.gameObject.SetActive(false);
        model.transform.gameObject.SetActive(false);
        rotate.transform.gameObject.SetActive(false);
        walls.transform.gameObject.SetActive(false);
              
            
    }
    
            Ray GenerateMouseRay()
{
    Vector3 mousePosFar = new Vector3(Input.mousePosition.x,
                                      Input.mousePosition.y,
                                      Camera.main.farClipPlane);
    Vector3 mousePosNear = new Vector3(Input.mousePosition.x,
                                      Input.mousePosition.y,
                                      Camera.main.nearClipPlane);
    Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
    Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);
    
    Ray mr = new Ray(mousePosN, mousePosF-mousePosN);
    return mr;
}
    

    
  
    
    void NextOnCLick()
    {

         navbarfirst.transform.gameObject.SetActive(false);
      
            navbarsecond.transform.gameObject.SetActive(true);
        
        
        rotate.transform.gameObject.SetActive(false);
        
        
        
        
    }
    
    void BackOnCLick()
    {

          navbarfirst.transform.gameObject.SetActive(true);
              
                    navbarsecond.transform.gameObject.SetActive(false);
                
                
                rotate.transform.gameObject.SetActive(true);
                
        
    }
    
    void DoneOnClick()
    {
        navbarfirst .transform.gameObject.SetActive(false);
                   navbarsecond.transform.gameObject.SetActive(false);
        
        menuBar.transform.gameObject.SetActive(true);
        camBackground.transform.gameObject.SetActive(false);
        wall = false;
        
        
        
    }
    
    void CamCheck() {
        walls.transform.gameObject.SetActive(true);     
        navbarfirst.transform.gameObject.SetActive(true);
            camButtonPic.transform.gameObject.SetActive(false);
            camButtonCheck.transform.gameObject.SetActive(false);
            camButtonWrong.transform.gameObject.SetActive(false);
        rotate.transform.gameObject.SetActive(true);
    }
    
 
    
    

void Update()
{
    if(menuBar.gameObject.activeSelf == true)
    {
        if(Input.GetMouseButtonDown(0))
           {
               Ray mouseRay = GenerateMouseRay();
               RaycastHit hit;
               if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit))
               {
                   gObj = hit.transform.gameObject;
                if (Input.GetMouseButton(0) )
                {
                    menuBar.transform.gameObject.SetActive(false);
                    model.transform.gameObject.SetActive(true);
                    camBackground.transform.gameObject.SetActive(true);
                    model.transform.position = new Vector3(floor.transform.position.x, floor.transform.position.y, back.transform.position.z - 2);
                }
                }
           }
    }
    
    if(menuBar.gameObject.activeSelf == false && navbarfirst.gameObject.activeSelf == false && navbarsecond.gameObject.activeSelf == false)
    {
        if(Input.GetMouseButtonDown(0))
           {
               Ray mouseRay = GenerateMouseRay();
               RaycastHit hit;
               
               
               
               if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit))
               {
                   gObj = hit.transform.gameObject;
                   objPlane = new Plane(Camera.main.transform.up*-1, gObj.transform.position);
                   
                   Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                              float rayDistance;
                              objPlane.Raycast(mRay, out rayDistance);
                              m0 = model.transform.position - mRay.GetPoint(rayDistance);
               }
           }
   else if(Input.GetMouseButton(0) && gObj)
    {
       
      Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
      float rayDistance;
      if(objPlane.Raycast(mRay, out rayDistance))
      {

             float xPos = Mathf.Clamp((mRay.GetPoint(rayDistance).x + m0.x), side.transform.position.x, side1.transform.position.x);
             float zPos = Mathf.Clamp((mRay.GetPoint(rayDistance).z + m0.z), camera1.transform.position.z, back.transform.position.z);
          
          model.transform.position = new Vector3(xPos, floor.transform.position.y, zPos);
      }
    }
    }
    
    
   
    
    
      

    
    
         
    
    
    

    
       pushNext.onClick.AddListener(NextOnCLick);
       pushBack.onClick.AddListener(BackOnCLick);
       pushDone.onClick.AddListener(DoneOnClick);
        camButtonCheck.onClick.AddListener(CamCheck);
    
    
    
  if(menuBar.gameObject.activeSelf == false && navbarfirst.gameObject.activeSelf == true && wall == true)
     {
    if(Input.GetMouseButtonDown(0))
    {
        Ray mouseRay = GenerateMouseRay();
        RaycastHit hit;
        
        
        
        if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit))
        {
            gObj = hit.transform.gameObject;
            
            if(gObj == side)
                    objPlane = new Plane(Camera.main.transform.forward*-1, gObj.transform.position);
            
            else if(gObj == floor)
                    objPlane = new Plane(Camera.main.transform.right*-1, gObj.transform.position);
            
            else if(gObj == back)
                    objPlane = new Plane(Camera.main.transform.right*-1, gObj.transform.position);
            
            else if(gObj == side1)
            objPlane = new Plane(Camera.main.transform.forward*-1, gObj.transform.position);
            
            else if(gObj == ceiling)
            objPlane = new Plane(Camera.main.transform.right*-1, gObj.transform.position);
            
            else if(gObj == rotate)
            objPlane = new Plane(Camera.main.transform.forward*-1, gObj.transform.position);
            
            
            
            //calc mouse Offset
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            objPlane.Raycast(mRay, out rayDistance);
            m0 = gObj.transform.position - mRay.GetPoint(rayDistance);
        
        }
    }

    
    
    
    

    else if (Input.GetMouseButton(0) && gObj == rotate)
      {
          
        Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float rayDistance;
        if(objPlane.Raycast(mRay, out rayDistance))
        {
            
                camera2.transform.RotateAround(rotate.transform.position, new Vector3(0f, 1f, 0f), (mRay.GetPoint(rayDistance).x + m0.x) * Time.deltaTime * 3);
        }
      }
        
        
        
       
    
    
    
    
    
    else if (Input.GetMouseButton(0) && gObj  == side)
    {
      Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
      float rayDistance;
      if(objPlane.Raycast(mRay, out rayDistance))
      {
          
          floor.transform.position = new Vector3((side.transform.position.x + side1.transform.position.x) /2, floor.transform.position.y, floor.transform.position.z);
          floor.transform.localScale = new Vector3((side1.transform.position.x - side.transform.position.x) / 10, 1,  gObj.transform.localScale.z);
          
          back.transform.position = new Vector3((side.transform.position.x + side1.transform.position.x)/2, back.transform.position.y, back.transform.position.z);
          back.transform.localScale = new Vector3( gObj.transform.localScale.x, 1, (side1.transform.position.x - side.transform.position.x) / 10);
          
          side1.transform.position = new Vector3(side1.transform.position.x, back.transform.position.y , floor.transform.position.z);
          
            ceiling.transform.position = new Vector3((side1.transform.position.x + side.transform.position.x) / 2, ceiling.transform.position.y, ceiling.transform.position.z);
            ceiling.transform.localScale = new Vector3((side1.transform.position.x - side.transform.position.x) / 10, 1,  gObj.transform.localScale.z);
        
    
          gObj.transform.position = new Vector3((mRay.GetPoint(rayDistance).x + m0.x),back.transform.position.y, floor.transform.position.z);
          
      }
    }
    
     else if (Input.GetMouseButton(0) && gObj == side1)
       {
         Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
         float rayDistance;
         if(objPlane.Raycast(mRay, out rayDistance))
         {
             
             floor.transform.position = new Vector3((side.transform.position.x + side1.transform.position.x) /2, floor.transform.position.y, floor.transform.position.z);
             floor.transform.localScale = new Vector3((side1.transform.position.x - side.transform.position.x) / 10, 1,  gObj.transform.localScale.z);
             
             back.transform.position = new Vector3((side.transform.position.x + side1.transform.position.x)/2, back.transform.position.y, back.transform.position.z);
             back.transform.localScale = new Vector3(gObj.transform.localScale.x, 1, (side1.transform.position.x - side.transform.position.x) / 10);
             
             ceiling.transform.position = new Vector3((side1.transform.position.x + side.transform.position.x) / 2, ceiling.transform.position.y, ceiling.transform.position.z);
                      ceiling.transform.localScale = new Vector3((side1.transform.position.x - side.transform.position.x) / 10, 1,  gObj.transform.localScale.z);
             
             side.transform.position = new Vector3(side.transform.position.x, back.transform.position.y , floor.transform.position.z);
           
       
             gObj.transform.position = new Vector3((mRay.GetPoint(rayDistance).x + m0.x),back.transform.position.y, floor.transform.position.z);
         }
       }
    
    
    
    
    else if (Input.GetMouseButton(0)&& gObj == floor)
    {
      Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
      float rayDistance;
      if(objPlane.Raycast(mRay, out rayDistance))
      {
          
          
                    float xPos = Mathf.Clamp((mRay.GetPoint(rayDistance).y + m0.y), -15, 15);
          
         
          side.transform.position = new Vector3(side.transform.position.x, (ceiling.transform.position.y + floor.transform.position.y) /2, side.transform.position.z);
          side.transform.localScale = new Vector3((ceiling.transform.position.y - gObj.transform.position.y ) / 10,  gObj.transform.localScale.x, gObj.transform.localScale.z);
          
          back.transform.position = new Vector3(back.transform.position.x, (ceiling.transform.position.y + floor.transform.position.y) /2, back.transform.position.z);
          back.transform.localScale = new Vector3((ceiling.transform.position.y - gObj.transform.position.y ) / 10,  gObj.transform.localScale.z , gObj.transform.localScale.x);
          
          side1.transform.position = new Vector3(side1.transform.position.x, ((ceiling.transform.position.y + floor.transform.position.y) /2), side1.transform.position.z);
          side1.transform.localScale = new Vector3((ceiling.transform.position.y - gObj.transform.position.y ) / 10,  gObj.transform.localScale.x, gObj.transform.localScale.z);
          
          ceiling.transform.position = new Vector3(ceiling.transform.position.x, ceiling.transform.position.y, ceiling.transform.position.z);
          ceiling.transform.localScale = new Vector3((side.transform.position.x - side1.transform.position.x) / 10, 1,  gObj.transform.localScale.z);
          
        
          
         
          gObj.transform.position = new Vector3(back.transform.position.x,xPos, side.transform.position.z) ;

      }
    }
    
    
    else if (Input.GetMouseButton(0)&& gObj == ceiling)
       {
           
         Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
         float rayDistance;
         if(objPlane.Raycast(mRay, out rayDistance))
         {
             
             
                      float xPos = Mathf.Clamp((mRay.GetPoint(rayDistance).y + m0.y), -15, 15);
             side.transform.position = new Vector3(side.transform.position.x, (ceiling.transform.position.y + floor.transform.position.y) /2, side.transform.position.z);
             side.transform.localScale = new Vector3((gObj.transform.position.y - floor.transform.position.y ) / 10,  gObj.transform.localScale.x, gObj.transform.localScale.z);
             
             back.transform.position = new Vector3(back.transform.position.x, (ceiling.transform.position.y + floor.transform.position.y) /2, back.transform.position.z);
             back.transform.localScale = new Vector3((gObj.transform.position.y - floor.transform.position.y ) / 10,  gObj.transform.localScale.z , gObj.transform.localScale.x);
             
             side1.transform.position = new Vector3(side1.transform.position.x, (ceiling.transform.position.y + floor.transform.position.y) /2, side1.transform.position.z);
             side1.transform.localScale = new Vector3((gObj.transform.position.y - floor.transform.position.y ) / 10,  gObj.transform.localScale.x, gObj.transform.localScale.z);
             
           
             
            
             gObj.transform.position = new Vector3(back.transform.position.x,xPos, side.transform.position.z) ;

         }
       }
       
    
    
    
    
    else if (Input.GetMouseButton(0)&& gObj == back)
    {
      Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
      float rayDistance;
      if(objPlane.Raycast(mRay, out rayDistance))
      {
      
          
          float xPos = Mathf.Clamp((mRay.GetPoint(rayDistance).z + m0.z), 0, 50);
          
          side.transform.position = new Vector3(side.transform.position.x, side.transform.position.y, (gObj.transform.position.z) / 2);
          side.transform.localScale = new Vector3( gObj.transform.localScale.x, 1, (gObj.transform.position.z) / 10);
          
          floor.transform.position = new Vector3(floor.transform.position.x, floor.transform.position.y, (gObj.transform.position.z) / 2);
          floor.transform.localScale = new Vector3( gObj.transform.localScale.z, 1, (gObj.transform.position.z) / 10);
          
          ceiling.transform.position = new Vector3(floor.transform.position.x, ceiling.transform.position.y, (gObj.transform.position.z) / 2);
          ceiling.transform.localScale = new Vector3( gObj.transform.localScale.z, 1, (gObj.transform.position.z) / 10);
          
          gObj.transform.position = new Vector3(floor.transform.position.x, side.transform.position.y, xPos);
          
          
          
          side1.transform.position = new Vector3(side1.transform.position.x, side1.transform.position.y, (gObj.transform.position.z) / 2);
          side1.transform.localScale = new Vector3( gObj.transform.localScale.x, 1, (gObj.transform.position.z) / 10);
      }
    }
    
    

}
}
}




