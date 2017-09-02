using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : MonoBehaviour {
	
	//HingeJointコンポーネントを入れる
	private HingeJoint myHingeJoint;
	
	//初期の傾き
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float flickAngle = -20;


	// Use this for initialization
	void Start () {
		//HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();
		
		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach(Touch touch in Input.touches){ 
		
		//画面左側をタップした時左フリッパーを動かす
		if(touch.phase == TouchPhase.Began && tag =="LeftFripperTag" && touch.position.x <= Screen.width * 0.5f){
			SetAngle(this.flickAngle);
		}
		//画面右側をタップした時右フリッパーを動かす
		if(touch.phase == TouchPhase.Began && tag =="RightFripperTag" && touch.position.x > Screen.width * 0.5f){
			SetAngle(this.flickAngle);
		}
		
		//画面から指が離された時フリッパーを元に戻す
		if(touch.phase == TouchPhase.Ended && tag =="LeftFripperTag" && touch.position.x <= Screen.width * 0.5f){
			SetAngle(this.defaultAngle);
		}
		if(touch.phase == TouchPhase.Ended && tag =="RightFripperTag" && touch.position.x > Screen.width * 0.5f){
			SetAngle(this.defaultAngle);
		}
	}
	}
	
	//フリッパーの傾きを設定
		public void SetAngle(float angle){
			JointSpring jointSpr = this.myHingeJoint.spring;
			jointSpr.targetPosition = angle;
			this.myHingeJoint.spring = jointSpr;
		}
}
