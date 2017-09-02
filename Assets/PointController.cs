using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour {

	//ポイントを表示するテキスト
	private GameObject pointText;
	
	//scoreの初期化
	private int score = 0;

	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.pointText = GameObject.Find("PointText");
		//ポイントの初期値を表示
		this.pointText.GetComponent<Text>().text = "Score: 0";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//各ターゲットにボールが衝突した時に得点加算
		void OnCollisionEnter(Collision other){
			if(other.gameObject.tag == "SmallStarTag"){
				//小さい星に衝突した時10点加算
				score += 10;
			}else if(other.gameObject.tag == "LargeStarTag"){
				//大きい星に衝突した時20点加算
				score += 20;
			}else if(other.gameObject.tag == "SmallCloudTag" ){
				//小さい雲に衝突した時15点加算
				score += 15;
			}else if(other.gameObject.tag == "LargeCloudTag"){
				//大きい雲に衝突した時50点加算
				score += 50;
			}
			//現在の得点を表示
			this.pointText.GetComponent<Text>().text = "Score: " + score.ToString();
		}
		
}
