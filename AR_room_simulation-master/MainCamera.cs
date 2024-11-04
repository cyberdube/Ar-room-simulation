using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Start is called before the first frame update
     void OnPreRender() {
           GL.wireframe = false;
       }
       void OnPostRender() {
           GL.wireframe = false;
       }
}
