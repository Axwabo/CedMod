﻿// Decompiled with JetBrains decompiler
// Type: Utf8Json.JsonFormatterExtensions
// Assembly: Assembly-CSharp, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null
// MVID: 4FF70443-CA06-4035-B3D1-98CFA9EE67BF
// Assembly location: D:\steamgames\steamapps\common\SCP Secret Laboratory Dedicated Server\SCPSL_Data\Managed\Assembly-CSharp.dll

namespace Utf8Json
{
  public static class JsonFormatterExtensions
  {
    public static string ToJsonString<T>(
      this IJsonFormatter<T> formatter,
      T value,
      IJsonFormatterResolver formatterResolver)
    {
      JsonWriter writer = new JsonWriter();
      formatter.Serialize(ref writer, value, formatterResolver);
      return writer.ToString();
    }
  }
}
