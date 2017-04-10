using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitOnClk : MonoBehaviour {

	public void Exit(){
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Exit();
		#endif
	}
}
