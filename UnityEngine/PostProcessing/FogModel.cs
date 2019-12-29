﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.FogModel
// Assembly: Assembly-CSharp, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null
// MVID: 4FF70443-CA06-4035-B3D1-98CFA9EE67BF
// Assembly location: D:\steamgames\steamapps\common\SCP Secret Laboratory Dedicated Server\SCPSL_Data\Managed\Assembly-CSharp.dll

using System;

namespace UnityEngine.PostProcessing
{
  [Serializable]
  public class FogModel : PostProcessingModel
  {
    [SerializeField]
    private FogModel.Settings m_Settings = FogModel.Settings.defaultSettings;

    public FogModel.Settings settings
    {
      get
      {
        return this.m_Settings;
      }
      set
      {
        this.m_Settings = value;
      }
    }

    public override void Reset()
    {
      this.m_Settings = FogModel.Settings.defaultSettings;
    }

    [Serializable]
    public struct Settings
    {
      [Tooltip("Should the fog affect the skybox?")]
      public bool excludeSkybox;

      public static FogModel.Settings defaultSettings
      {
        get
        {
          return new FogModel.Settings()
          {
            excludeSkybox = true
          };
        }
      }
    }
  }
}
