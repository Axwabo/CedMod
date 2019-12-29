﻿// Decompiled with JetBrains decompiler
// Type: Utf8Json.Formatters.GenericCollectionFormatter`2
// Assembly: Assembly-CSharp, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null
// MVID: 4FF70443-CA06-4035-B3D1-98CFA9EE67BF
// Assembly location: D:\steamgames\steamapps\common\SCP Secret Laboratory Dedicated Server\SCPSL_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

namespace Utf8Json.Formatters
{
  public sealed class GenericCollectionFormatter<TElement, TCollection> : CollectionFormatterBase<TElement, TCollection>
    where TCollection : class, ICollection<TElement>, new()
  {
    protected override TCollection Create()
    {
      return new TCollection();
    }

    protected override void Add(ref TCollection collection, int index, TElement value)
    {
      collection.Add(value);
    }
  }
}
