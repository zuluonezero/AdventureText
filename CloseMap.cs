using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMap : MonoBehaviour {

    public Canvas map_canvas;

    public void CloseMe () {
        var cg = map_canvas.GetComponent<CanvasGroup>();
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }
	
}
