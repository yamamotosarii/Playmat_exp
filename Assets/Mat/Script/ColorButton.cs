using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorButton : MonoBehaviour {
	public Button yourButton;
    public Material material;
    private int count = 0;

	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		//MatControll.MainColor = this.GetComponent<Image>().color;
        MatController Color = GetComponent<MatController>();
        MatController.MainColor = this.GetComponent<Image>().color;

	}
}
