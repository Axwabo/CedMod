﻿// Decompiled with JetBrains decompiler
// Type: MaterialLanguageReplacer
// Assembly: Assembly-CSharp, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null
// MVID: 4FF70443-CA06-4035-B3D1-98CFA9EE67BF
// Assembly location: D:\steamgames\steamapps\common\SCP Secret Laboratory Dedicated Server\SCPSL_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MaterialLanguageReplacer : MonoBehaviour
{
  public Material englishVersion;

  private void Start()
  {
    this.GetComponent<Renderer>().material = this.englishVersion;
  }

  private void OnDestroy()
  {
    Object.Destroy((Object) this.GetComponent<Renderer>().material);
  }
}
