/*
The MIT License (MIT)

Copyright (c) 2018 - 2025 Everest Team

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace CommonCom.Util;

public static class BinaryHelper {
    // Serializes data to (usually) a binary buffer for transmission
    // A buffer length of 0 indicates that the object is null
    // Some primitive types are special cased, to avoid the overhead of the buffer

    public static void WriteObject(this BinaryWriter writer, object? value) {
        if (value == null) {
            writer.Write(0);
            return;
        }

        switch (value)
        {
            // Primitives
            case bool v:
                writer.Write(v);
                return;
            case byte v:
                writer.Write(v);
                return;
            case byte[] v:
                writer.Write(v.Length);
                writer.Write(v);
                return;
            case char v:
                writer.Write(v);
                return;
            case char[] v:
                writer.Write(v.Length);
                writer.Write(v);
                return;
            case decimal v:
                writer.Write(v);
                return;
            case double v:
                writer.Write(v);
                return;
            case float v:
                writer.Write(v);
                return;
            case int v:
                writer.Write(v);
                return;
            case long v:
                writer.Write(v);
                return;
            case sbyte v:
                writer.Write(v);
                return;
            case short v:
                writer.Write(v);
                return;
            case string v:
                writer.Write(v);
                return;

            case IEnumerable v when v.GetType().IsArray || IsAssignableTo(v.GetType(), typeof(IList)):
                var values = v.Cast<object>().ToArray();
                writer.Write(values.Length);
                for (int i = 0; i < values.Length; i++) {
                    writer.WriteObject(values[i]);
                }
                return;
            default:
                throw new ArgumentException($"Type [{value.GetType()}] isn't supported.");
        }

    }

    public static T ReadObject<T>(this BinaryReader reader) => (T)reader.ReadObject(typeof(T))!;
    public static object? ReadObject(this BinaryReader reader, System.Type type) {
        // Primitives
        if (type == typeof(bool))
            return reader.ReadBoolean();
        if (type == typeof(byte))
            return reader.ReadByte();
        if (type == typeof(byte[]))
            return reader.ReadBytes(reader.ReadInt32());
        if (type == typeof(char))
            return reader.ReadChar();
        if (type == typeof(char[]))
            return reader.ReadChars(reader.ReadInt32());
        if (type == typeof(decimal))
            return reader.ReadDecimal();
        if (type == typeof(double))
            return reader.ReadDouble();
        if (type == typeof(float))
            return reader.ReadSingle();
        if (type == typeof(int))
            return reader.ReadInt32();
        if (type == typeof(long))
            return reader.ReadInt64();
        if (type == typeof(sbyte))
            return reader.ReadSByte();
        if (type == typeof(short))
            return reader.ReadInt16();
        if (type == typeof(string))
            return reader.ReadString();

        if (type.IsArray) {
            int count = reader.Read();
            var elemType = type.GetElementType()!;

            var values = Array.CreateInstance(elemType, count);
            for (int i = 0; i < count; i++) {
                values.SetValue(reader.ReadObject(elemType), i);
            }

            return values;
        }
        if (IsAssignableTo(type, typeof(IList)) && type.IsGenericType) {
            int count = reader.Read();
            var elemType = type.GetElementType() ?? type.GenericTypeArguments[0];

            var list = (IList)Activator.CreateInstance(type)!;
            for (int i = 0; i < count; i++) {
                list.Add(reader.ReadObject(elemType));
            }

            return list;
        }

        bool nullable = !type.IsValueType;
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>)) {
            nullable = true;
            type = Nullable.GetUnderlyingType(type)!;
        }

        int length = reader.Read();
        if (nullable && length == 0) {
            return null;
        }

        throw new Exception();
    }
    private static bool IsAssignableTo(System.Type? type, System.Type targetType) {
        return targetType.IsAssignableFrom(type);
    }
}
