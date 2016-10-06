using UnityEngine;

public class ActivateTriggerTag : MonoBehaviour {
	public enum Mode {
		Trigger   = 0, // Just broadcast the action on to the target
		Replace   = 1, // replace target with source
		Activate  = 2, // Activate the target GameObject
		Enable    = 3, // Enable a component
		Animate   = 4, // Start animation on target
		Deactivate= 5 // Decativate target GameObject
	}

	/// The action to accomplish
	public Mode action = Mode.Activate;

	/// The game object to affect. If none, the trigger work on this game object
	public Object target;
	public GameObject source;
	public int triggerCount = 1;///
	public bool repeatTrigger = false;
	public string tag;
	public string animationState;

	void DoActivateTrigger () {
		triggerCount--;

		if (triggerCount == 0 || repeatTrigger) {
			Object currentTarget = target != null ? target : gameObject;
			Behaviour targetBehaviour = currentTarget as Behaviour;
			GameObject targetGameObject = currentTarget as GameObject;
			if (targetBehaviour != null)
				targetGameObject = targetBehaviour.gameObject;
		
			switch (action) {
				case Mode.Trigger:
					targetGameObject.BroadcastMessage ("DoActivateTrigger");
					break;
				case Mode.Replace:
					if (source != null) {
						Object.Instantiate (source, targetGameObject.transform.position, targetGameObject.transform.rotation);
						DestroyObject (targetGameObject);
					}
					break;
				case Mode.Activate:
					targetGameObject.SetActive(true);
					break;
				case Mode.Enable:
					if (targetBehaviour != null)
						targetBehaviour.enabled = true;
					break;	
				case Mode.Animate:
				targetGameObject.GetComponent<Animator>().Play(animationState, -1, 0f);
					break;	
				case Mode.Deactivate:
					targetGameObject.SetActive(false);
					break;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		print (other.tag);
		if (tag.Length > 0&&tag.Equals(other.tag)) {
			print("ativou");
			DoActivateTrigger ();
		}
	}
	void OnTriggerEnter (Collider other) {
		print (other.tag);
		if (tag.Length > 0&&tag.Equals(other.tag)) {
			print("ativou");
			DoActivateTrigger ();
		}
	}
}