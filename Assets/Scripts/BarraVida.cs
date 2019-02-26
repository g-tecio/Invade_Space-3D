using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class BarraVida : MonoBehaviour {

	public Scrollbar HealthBar;
	public float Health = 100;

	public void Hit(float value)
	{
		Health -= value;
		HealthBar.size = Health / 100f;
	}

}
