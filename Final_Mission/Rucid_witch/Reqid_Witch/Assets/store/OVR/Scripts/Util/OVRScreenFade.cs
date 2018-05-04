/************************************************************************************

Copyright   :   Copyright 2017 Oculus VR, LLC. All Rights reserved.

Licensed under the Oculus VR Rift SDK License Version 3.4.1 (the "License");
you may not use the Oculus VR Rift SDK except in compliance with the License,
which is provided at the time of installation or download, or which
otherwise accompanies this software in either electronic or hard copy form.

You may obtain a copy of the License at

https://developer.oculus.com/licenses/sdk-3.4.1

Unless required by applicable law or agreed to in writing, the Oculus VR SDK
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

************************************************************************************/

using UnityEngine;
using System.Collections; // required for Coroutines
using System.Collections.Generic;

/// <summary>
/// Fades the screen from black after a new scene is loaded. Fade can also be controlled mid-scene using SetUIFade and SetFadeLevel
/// </summary>
public class OVRScreenFade : MonoBehaviour
{
	//   [Tooltip("Fade duration")]
	//public float fadeTime = 2.0f;

	[Tooltip("Screen color at maximum fade")]
	public Color fadeColor = new Color(0.01f, 0.01f, 0.01f, 1.0f);

	public bool fadeOnStart = true;

	private float uiFadeAlpha = 0;

	private MeshRenderer fadeRenderer;
	private MeshFilter fadeMesh;
	private Material fadeMaterial = null;
	private bool isFading = false;

	public float currentAlpha { get; private set; }

	void Awake()
	{
		// create the fade material
		fadeMaterial = new Material(Shader.Find("Oculus/Unlit Transparent Color"));
		fadeMesh = gameObject.AddComponent<MeshFilter>();
		fadeRenderer = gameObject.AddComponent<MeshRenderer>();

		Mesh mesh = new Mesh();
		fadeMesh.mesh = mesh;

		Vector3[] vertices = new Vector3[4];

		float width = 2f;
		float height = 2f;
		float depth = 1f;

		vertices[0] = new Vector3(-width, -height, depth);
		vertices[1] = new Vector3(width, -height, depth);
		vertices[2] = new Vector3(-width, height, depth);
		vertices[3] = new Vector3(width, height, depth);

		mesh.vertices = vertices;

		int[] tri = new int[6];

		tri[0] = 0;
		tri[1] = 2;
		tri[2] = 1;

		tri[3] = 2;
		tri[4] = 3;
		tri[5] = 1;

		mesh.triangles = tri;

		Vector3[] normals = new Vector3[4];

		normals[0] = -Vector3.forward;
		normals[1] = -Vector3.forward;
		normals[2] = -Vector3.forward;
		normals[3] = -Vector3.forward;

		mesh.normals = normals;

		Vector2[] uv = new Vector2[4];

		uv[0] = new Vector2(0, 0);
		uv[1] = new Vector2(1, 0);
		uv[2] = new Vector2(0, 1);
		uv[3] = new Vector2(1, 1);

		mesh.uv = uv;

		fadeRenderer.material = fadeMaterial;
	}




	/// <summary>
	/// Starts a fade in when a new level is loaded
	/// </summary>
	void OnLevelFinishedLoading(int level)
	{
		StartCoroutine(Fade(1, 0));
	}

	/// <summary>
	/// Automatically starts a fade in
	/// </summary>
	void Start()
	{
		if (fadeOnStart)
		{
			StartCoroutine(Fade(1, 0));
		}
	}

	void OnEnable()
	{
		if (!fadeOnStart)
		{
			SetFadeLevel(0);
		}
	}

	/// <summary>
	/// Cleans up the fade material
	/// </summary>
	void OnDestroy()
	{
		if (fadeRenderer != null)
			Destroy(fadeRenderer);

		if (fadeMaterial != null)
			Destroy(fadeMaterial);

		if (fadeMesh != null)
			Destroy(fadeMesh);
	}

	/// <summary>
	/// Set the UI fade level - fade due to UI in foreground
	/// </summary>
	public void SetUIFade(float level)
	{
		uiFadeAlpha = Mathf.Clamp01(level);
		SetMaterialAlpha();
	}
	/// <summary>
	/// Override current fade level
	/// </summary>
	/// <param name="level"></param>
	public void SetFadeLevel(float level)
	{
		currentAlpha = level;
		SetMaterialAlpha();
	}
	/// <summary>
	/// Start a fade out
	/// </summary>
	public void FadeOut()
	{
		StartCoroutine(Fade(0, 1));
	}
	public void fade(float startAlpha, float endAlpha)
	{
		StartCoroutine(Fade(startAlpha, endAlpha));
	}
	public void fade(float startAlpha, float endAlpha, float fadeTime)
	{
		StartCoroutine(Fade(startAlpha, endAlpha, fadeTime));
	}
	public void fade(Color newScreenOverlayColor, float startAlpha, float endAlpha, float fadeTime)
	{
		StartCoroutine(Fade(newScreenOverlayColor, startAlpha, endAlpha, fadeTime));
	}
	public void fade(Color newScreenOverlayColor, float startAlpha, float endAlpha, float fadeTime, float fadeDelay)
	{
		StartCoroutine(Fade(newScreenOverlayColor, startAlpha, endAlpha, fadeTime, fadeDelay));
	}
	public void blinking(Color newScreenOverlayColor, float fadeDuration, float delay)
	{
		StartCoroutine(Blinking(newScreenOverlayColor, fadeDuration, delay));
	}
	public void fadeSmoth(Color newScreenOverlayColor, float startAlpha, float endAlpha, float firstFadeTime, float secondFadeTime, float fadeDelay)
	{
		StartCoroutine(FadeSmoth(newScreenOverlayColor, startAlpha,  endAlpha,  firstFadeTime,  secondFadeTime, fadeDelay));
	}
	IEnumerator Fade(float startAlpha, float endAlpha)
	{
		fadeColor = new Color(0, 0, 0, 0);
		float elapsedTime = 0.0f;
		while (elapsedTime < 2.0f)
		{
			elapsedTime += Time.deltaTime;
			currentAlpha = Mathf.Lerp(startAlpha, endAlpha, Mathf.Clamp01(elapsedTime / 2.0f));
			SetMaterialAlpha();
			yield return new WaitForEndOfFrame();
		}
	}
	IEnumerator Fade(float startAlpha, float endAlpha, float fadeTime)
	{
		fadeColor = new Color(0, 0, 0, 0);
		float elapsedTime = 0.0f;
		while (elapsedTime < fadeTime)
		{
			elapsedTime += Time.deltaTime;
			currentAlpha = Mathf.Lerp(startAlpha, endAlpha, Mathf.Clamp01(elapsedTime / fadeTime));
			SetMaterialAlpha();
			yield return new WaitForEndOfFrame();
		}
	}
	IEnumerator Fade(Color newScreenOverlayColor, float startAlpha, float endAlpha, float fadeTime)
	{
		Color currentColor = new Color(0, 0, 0, 0);
		fadeColor = newScreenOverlayColor;
		float elapsedTime = 0.0f;
		while (elapsedTime < fadeTime)
		{
			elapsedTime += Time.deltaTime;
			currentAlpha = Mathf.Lerp(startAlpha, endAlpha, Mathf.Clamp01(elapsedTime / fadeTime));
			SetMaterialAlpha();
			yield return new WaitForEndOfFrame();
		}
		SetMaterialAlpha(currentColor);
	}
	IEnumerator Fade(Color newScreenOverlayColor, float startAlpha, float endAlpha, float fadeTime, float fadeDelay)
	{
		Color currentColor = new Color(0, 0, 0, 0);
		fadeColor = newScreenOverlayColor;
		float elapsedTime = 0.0f;
		float delay = 0.0f;
		while (delay < fadeDelay)
		{
			delay += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		while (elapsedTime < fadeTime)
		{
			elapsedTime += Time.deltaTime;
			currentAlpha = Mathf.Lerp(startAlpha, endAlpha, Mathf.Clamp01(elapsedTime / fadeTime));
			SetMaterialAlpha();
			yield return new WaitForEndOfFrame();
		}
		SetMaterialAlpha(currentColor);
	}
	IEnumerator FadeSmoth(Color newScreenOverlayColor, float startAlpha, float endAlpha, float firstFadeTime, float secondFadeTime, float fadeDelay)
	{
		Color currentColor = new Color(0, 0, 0, 0);
		fadeColor = newScreenOverlayColor;
		float firstTimer = 0.0f;
		float DelayTimer = 0.0f;
		float secondeTimer = 0.0f;
		while (firstTimer < firstFadeTime)
		{
			firstTimer += Time.deltaTime;
			currentAlpha = Mathf.Lerp(startAlpha, endAlpha, Mathf.Clamp01(firstTimer / firstFadeTime));
			SetMaterialAlpha();
			yield return new WaitForEndOfFrame();
		}
		while (DelayTimer < fadeDelay)
		{
			DelayTimer += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		//fadeColor = currentColor;
		while (secondeTimer < secondFadeTime)
		{
			secondeTimer += Time.deltaTime;
			currentAlpha = Mathf.Lerp(endAlpha, startAlpha, Mathf.Clamp01(secondeTimer / secondFadeTime));
			SetMaterialAlpha();
			yield return new WaitForEndOfFrame();
		}
		SetMaterialAlpha(currentColor);
	}
	IEnumerator Blinking(Color newScreenOverlayColor, float fadeDuration, float delay)
	{
		float timer = 0.0f;
		float Alltimer = 0.0f;
		bool flug = false;
		Color currentColor = fadeColor;
		while (Alltimer < fadeDuration)
		{
			timer += Time.deltaTime;
			if (delay < timer)
			{
				Alltimer += timer;
				timer = 0;
				flug = !flug;
				if (!flug)
				{
					SetMaterialAlpha(newScreenOverlayColor);
				}
				else
				{
					SetMaterialAlpha(currentColor);
				}
			}

			yield return null;
		}
		SetMaterialAlpha(currentColor);
	}
	/// <summary>
	/// Update material alpha. UI fade and the current fade due to fade in/out animations (or explicit control)
	/// both affect the fade. (The max is taken) 
	/// </summary>
	private void SetMaterialAlpha()
	{
		Color color = fadeColor;
		color.a = Mathf.Max(currentAlpha, uiFadeAlpha);
		isFading = color.a > 0;
		if (fadeMaterial != null)
		{
			fadeMaterial.color = color;
			fadeRenderer.material = fadeMaterial;
			fadeRenderer.enabled = isFading;
		}
	}
	private void SetMaterialAlpha(Color newScreenOverlayColor)
	{
		fadeColor = newScreenOverlayColor;
		Color color = fadeColor;
		isFading = true;
		if (fadeMaterial != null)
		{
			fadeMaterial.color = color;
			fadeRenderer.material = fadeMaterial;
			fadeRenderer.enabled = isFading;
		}
	}
}
