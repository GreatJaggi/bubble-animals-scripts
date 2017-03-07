using UnityEngine;
using System.Collections;

public class BottomCollider : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision)	{
		if (collision.gameObject.tag == "Pre-Bubble")
			Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
	}//OnCollisionEnter
}
