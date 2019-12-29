﻿// Decompiled with JetBrains decompiler
// Type: CameraFilterPack_Vision_Hell_Blood
// Assembly: Assembly-CSharp, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null
// MVID: 4FF70443-CA06-4035-B3D1-98CFA9EE67BF
// Assembly location: D:\steamgames\steamapps\common\SCP Secret Laboratory Dedicated Server\SCPSL_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Hell_Blood")]
public class CameraFilterPack_Vision_Hell_Blood : MonoBehaviour
{
  private float TimeX = 1f;
  [Range(0.0f, 1f)]
  public float Hole_Size = 0.57f;
  [Range(0.0f, 0.5f)]
  public float Hole_Smooth = 0.362f;
  [Range(-2f, 2f)]
  public float Hole_Speed = 0.85f;
  [Range(-10f, 10f)]
  public float Intensity = 0.24f;
  public Color ColorBlood = new Color(1f, 0.0f, 0.0f, 1f);
  [Range(-1f, 1f)]
  public float BloodAlternative3 = -1f;
  public Shader SCShader;
  private Material SCMaterial;
  [Range(-1f, 1f)]
  public float BloodAlternative1;
  [Range(-1f, 1f)]
  public float BloodAlternative2;

  private Material material
  {
    get
    {
      if ((Object) this.SCMaterial == (Object) null)
      {
        this.SCMaterial = new Material(this.SCShader);
        this.SCMaterial.hideFlags = HideFlags.HideAndDontSave;
      }
      return this.SCMaterial;
    }
  }

  private void Start()
  {
    this.SCShader = Shader.Find("CameraFilterPack/Vision_Hell_Blood");
    if (SystemInfo.supportsImageEffects)
      return;
    this.enabled = false;
  }

  private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
  {
    if ((Object) this.SCShader != (Object) null)
    {
      this.TimeX += Time.deltaTime;
      if ((double) this.TimeX > 100.0)
        this.TimeX = 0.0f;
      this.material.SetFloat("_TimeX", this.TimeX);
      this.material.SetFloat("_Value", this.Hole_Size);
      this.material.SetFloat("_Value2", this.Hole_Smooth);
      this.material.SetFloat("_Value3", this.Hole_Speed * 15f);
      this.material.SetColor("ColorBlood", this.ColorBlood);
      this.material.SetFloat("_Value4", this.Intensity);
      this.material.SetFloat("BloodAlternative1", this.BloodAlternative1);
      this.material.SetFloat("BloodAlternative2", this.BloodAlternative2);
      this.material.SetFloat("BloodAlternative3", this.BloodAlternative3);
      this.material.SetVector("_ScreenResolution", new Vector4((float) sourceTexture.width, (float) sourceTexture.height, 0.0f, 0.0f));
      Graphics.Blit((Texture) sourceTexture, destTexture, this.material);
    }
    else
      Graphics.Blit((Texture) sourceTexture, destTexture);
  }

  private void Update()
  {
  }

  private void OnDisable()
  {
    if (!(bool) (Object) this.SCMaterial)
      return;
    Object.DestroyImmediate((Object) this.SCMaterial);
  }
}
