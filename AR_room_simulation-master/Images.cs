using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class Images: MonoBehaviour, IEventSystemHandler
{
    

  [SerializeField]
     GameObject rawImage;
    Texture image;

    void Start () {
         rawImage = GameObject.Find ("Main Camera/Canvas/RawImage");
    }
    
    
    public void setImage(String message)
    {
        
         image = Resources.Load(message) as Texture;
        
    }
    
    void Update() {
        rawImage.GetComponent<RawImage> ().texture = image;
    }
    
}
