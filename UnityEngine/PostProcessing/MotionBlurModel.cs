﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.MotionBlurModel
// Assembly: Assembly-CSharp, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null
// MVID: 4FF70443-CA06-4035-B3D1-98CFA9EE67BF
// Assembly location: D:\steamgames\steamapps\common\SCP Secret Laboratory Dedicated Server\SCPSL_Data\Managed\Assembly-CSharp.dll

using System;

namespace UnityEngine.PostProcessing
{
  [Serializable]
  public class MotionBlurModel : PostProcessingModel
  {
    [SerializeField]
    private MotionBlurModel.Settings m_Settings = MotionBlurModel.Settings.defaultSettings;

    public MotionBlurModel.Settings settings
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
      this.m_Settings = MotionBlurModel.Settings.defaultSettings;
    }

    [Serializable]
    public struct Settings
    {
      [Range(0.0f, 360f)]
      [Tooltip("The angle of rotary shutter. Larger values give longer exposure.")]
      public float shutterAngle;
      [Range(4f, 32f)]
      [Tooltip("The amount of sample points, which affects quality and performances.")]
      public int sampleCount;
      [Range(0.0f, 1f)]
      [Tooltip("The strength of multiple frame blending. The opacity of preceding frames are determined from this coefficient and time differences.")]
      public float frameBlending;

      public static MotionBlurModel.Settings defaultSettings
      {
        get
        {
          return new MotionBlurModel.Settings()
          {
            shutterAngle = 270f,
            sampleCount = 10,
            frameBlending = 0.0f
          };
        }
      }
    }
  }
}
