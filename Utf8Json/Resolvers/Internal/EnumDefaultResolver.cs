﻿// Decompiled with JetBrains decompiler
// Type: Utf8Json.Resolvers.Internal.EnumDefaultResolver
// Assembly: Assembly-CSharp, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null
// MVID: 4FF70443-CA06-4035-B3D1-98CFA9EE67BF
// Assembly location: D:\steamgames\steamapps\common\SCP Secret Laboratory Dedicated Server\SCPSL_Data\Managed\Assembly-CSharp.dll

using System;
using System.Reflection;
using Utf8Json.Formatters;

namespace Utf8Json.Resolvers.Internal
{
  internal sealed class EnumDefaultResolver : IJsonFormatterResolver
  {
    public static readonly IJsonFormatterResolver Instance = (IJsonFormatterResolver) new EnumDefaultResolver();

    private EnumDefaultResolver()
    {
    }

    public IJsonFormatter<T> GetFormatter<T>()
    {
      return EnumDefaultResolver.FormatterCache<T>.formatter;
    }

    private static class FormatterCache<T>
    {
      public static readonly IJsonFormatter<T> formatter;

      static FormatterCache()
      {
        TypeInfo typeInfo1 = IntrospectionExtensions.GetTypeInfo(typeof (T));
        if (typeInfo1.IsNullable())
        {
          TypeInfo typeInfo2 = IntrospectionExtensions.GetTypeInfo(((Type) typeInfo1).get_GenericTypeArguments()[0]);
          if (!((Type) typeInfo2).IsEnum)
            return;
          object formatterDynamic = EnumDefaultResolver.Instance.GetFormatterDynamic(typeInfo2.AsType());
          if (formatterDynamic == null)
            return;
          EnumDefaultResolver.FormatterCache<T>.formatter = (IJsonFormatter<T>) Activator.CreateInstance(typeof (StaticNullableFormatter<>).MakeGenericType(typeInfo2.AsType()), formatterDynamic);
        }
        else
        {
          if (!typeof (T).IsEnum)
            return;
          EnumDefaultResolver.FormatterCache<T>.formatter = (IJsonFormatter<T>) new EnumFormatter<T>(true);
        }
      }
    }
  }
}
