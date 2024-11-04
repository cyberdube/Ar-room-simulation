using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    
    
    void OnPreRender() {
 
    {
        GL.wireframe = true;
        }
    }
    void OnPostRender() {
        GL.wireframe = true;
    }
}
