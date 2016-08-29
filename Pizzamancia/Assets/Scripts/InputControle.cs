using UnityEngine;
using System.Collections;

public class InputControle : MonoBehaviour {
	static InputControle inputControleInst;
	Vector2 movePad;
	bool btnPular;
	bool btnAtacar;
	bool btnConjurar;
	bool btnSelectPrev;
	bool btnSelectNext;

	public void Awake () {
		inputControleInst = this;
	}

	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update () {
        movePad = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        btnPular = Input.GetButtonDown("Jump");
        btnConjurar = Input.GetButtonDown("Fire1");
        btnAtacar = Input.GetButtonDown ("Fire2");
        btnSelectPrev = Input.GetButtonDown("Select Prev");
        btnSelectNext = Input.GetButtonDown("Select Next");
	}

	public static InputControle getInstance () {
		return inputControleInst;
	}

	public Vector2 MovePad {
		get { return movePad; }
		set { movePad = value; }
	}

	public bool BtnPular {
		get { return btnPular; }
		set { btnPular = value; }
	}

	public bool BtnAtacar {
		get { return btnAtacar; }
		set { btnAtacar = value; }
	}

	public bool BtnConjurar {
		get { return btnConjurar; }
		set { btnConjurar = value; }
	}

	public bool BtnSelectPrev {
		get { return btnSelectPrev; }
		set { btnSelectPrev = value; }
	}

	public bool BtnSelectNext {
		get { return btnSelectNext; }
		set { btnSelectNext = value; }
	}
}
