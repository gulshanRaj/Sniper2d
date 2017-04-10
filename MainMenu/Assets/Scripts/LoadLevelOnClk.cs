using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelOnClk : MonoBehaviour {

	public void LoadByIndex(int sceneIndex){
		SceneManager.LoadScene (sceneIndex);
	}
}
