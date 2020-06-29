#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168

namespace Utf8Json.Resolvers
{
    using System;
    using Utf8Json;

    public class GeneratedResolver : global::Utf8Json.IJsonFormatterResolver
    {
        public static readonly global::Utf8Json.IJsonFormatterResolver Instance = new GeneratedResolver();

        GeneratedResolver()
        {

        }

        public global::Utf8Json.IJsonFormatter<T> GetFormatter<T>()
        {
            return FormatterCache<T>.formatter;
        }

        static class FormatterCache<T>
        {
            public static readonly global::Utf8Json.IJsonFormatter<T> formatter;

            static FormatterCache()
            {
                var f = GeneratedResolverGetFormatterHelper.GetFormatter(typeof(T));
                if (f != null)
                {
                    formatter = (global::Utf8Json.IJsonFormatter<T>)f;
                }
            }
        }
    }

    internal static class GeneratedResolverGetFormatterHelper
    {
        static readonly global::System.Collections.Generic.Dictionary<Type, int> lookup;

        static GeneratedResolverGetFormatterHelper()
        {
            lookup = new global::System.Collections.Generic.Dictionary<Type, int>(16)
            {
                {typeof(global::AddressSerializableClassField[]), 0 },
                {typeof(global::AddressPlaneClassProperty[]), 1 },
                {typeof(object[]), 2 },
                {typeof(global::Utf8Json.IJsonFormatter[]), 3 },
                {typeof(global::Utf8Json.IJsonFormatterResolver[]), 4 },
                {typeof(global::NetworkClientSamples), 5 },
                {typeof(global::AddressSerializableClassField), 6 },
                {typeof(global::PersonSerializableClassField), 7 },
                {typeof(global::AddressPlaneClassProperty), 8 },
                {typeof(global::PersonPlaneClassProperty), 9 },
                {typeof(global::AddressRenamedProperty), 10 },
                {typeof(global::Utf8Json.JsonFormatterAttribute), 11 },
                {typeof(global::Utf8Json.SerializationConstructorAttribute), 12 },
                {typeof(global::Utf8Json.FormatterNotRegisteredException), 13 },
                {typeof(global::Utf8Json.JsonParsingException), 14 },
                {typeof(global::Utf8Json.Resolvers.DynamicCompositeResolver), 15 },
            };
        }

        internal static object GetFormatter(Type t)
        {
            int key;
            if (!lookup.TryGetValue(t, out key)) return null;

            switch (key)
            {
                case 0: return new global::Utf8Json.Formatters.ArrayFormatter<global::AddressSerializableClassField>();
                case 1: return new global::Utf8Json.Formatters.ArrayFormatter<global::AddressPlaneClassProperty>();
                case 2: return new global::Utf8Json.Formatters.ArrayFormatter<object>();
                case 3: return new global::Utf8Json.Formatters.ArrayFormatter<global::Utf8Json.IJsonFormatter>();
                case 4: return new global::Utf8Json.Formatters.ArrayFormatter<global::Utf8Json.IJsonFormatterResolver>();
                case 5: return new Utf8Json.Formatters.NetworkClientSamplesFormatter();
                case 6: return new Utf8Json.Formatters.AddressSerializableClassFieldFormatter();
                case 7: return new Utf8Json.Formatters.PersonSerializableClassFieldFormatter();
                case 8: return new Utf8Json.Formatters.AddressPlaneClassPropertyFormatter();
                case 9: return new Utf8Json.Formatters.PersonPlaneClassPropertyFormatter();
                case 10: return new Utf8Json.Formatters.AddressRenamedPropertyFormatter();
                case 11: return new Utf8Json.Formatters.Utf8Json.JsonFormatterAttributeFormatter();
                case 12: return new Utf8Json.Formatters.Utf8Json.SerializationConstructorAttributeFormatter();
                case 13: return new Utf8Json.Formatters.Utf8Json.FormatterNotRegisteredExceptionFormatter();
                case 14: return new Utf8Json.Formatters.Utf8Json.JsonParsingExceptionFormatter();
                case 15: return new Utf8Json.Formatters.Utf8Json.Resolvers.DynamicCompositeResolverFormatter();
                default: return null;
            }
        }
    }
}

#pragma warning disable 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612

#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 219
#pragma warning disable 168

namespace Utf8Json.Formatters
{
    using System;
    using Utf8Json;


    public sealed class NetworkClientSamplesFormatter : global::Utf8Json.IJsonFormatter<global::NetworkClientSamples>
    {
        readonly global::Utf8Json.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public NetworkClientSamplesFormatter()
        {
            this.____keyMapping = new global::Utf8Json.Internal.AutomataDictionary()
            {
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("www"), 0},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("webRequest"), 1},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("httpWebRequest"), 2},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("systemHttpClient"), 3},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("windowsHttpClient"), 4},
            };

            this.____stringByteKeys = new byte[][]
            {
                JsonWriter.GetEncodedPropertyNameWithBeginObject("www"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("webRequest"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("httpWebRequest"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("systemHttpClient"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("windowsHttpClient"),
                
            };
        }

        public void Serialize(ref JsonWriter writer, global::NetworkClientSamples value, global::Utf8Json.IJsonFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            

            writer.WriteRaw(this.____stringByteKeys[0]);
            formatterResolver.GetFormatterWithVerify<global::WWWSamples>().Serialize(ref writer, value.www, formatterResolver);
            writer.WriteRaw(this.____stringByteKeys[1]);
            formatterResolver.GetFormatterWithVerify<global::WebRequestSamples>().Serialize(ref writer, value.webRequest, formatterResolver);
            writer.WriteRaw(this.____stringByteKeys[2]);
            formatterResolver.GetFormatterWithVerify<global::HttpWebRequestSamples>().Serialize(ref writer, value.httpWebRequest, formatterResolver);
            writer.WriteRaw(this.____stringByteKeys[3]);
            formatterResolver.GetFormatterWithVerify<global::SystemHttpClientSamples>().Serialize(ref writer, value.systemHttpClient, formatterResolver);
            writer.WriteRaw(this.____stringByteKeys[4]);
            formatterResolver.GetFormatterWithVerify<global::WindowsHttpClientSamples>().Serialize(ref writer, value.windowsHttpClient, formatterResolver);
            
            writer.WriteEndObject();
        }

        public global::NetworkClientSamples Deserialize(ref JsonReader reader, global::Utf8Json.IJsonFormatterResolver formatterResolver)
        {
            if (reader.ReadIsNull())
            {
                return null;
            }
            

            var __www__ = default(global::WWWSamples);
            var __www__b__ = false;
            var __webRequest__ = default(global::WebRequestSamples);
            var __webRequest__b__ = false;
            var __httpWebRequest__ = default(global::HttpWebRequestSamples);
            var __httpWebRequest__b__ = false;
            var __systemHttpClient__ = default(global::SystemHttpClientSamples);
            var __systemHttpClient__b__ = false;
            var __windowsHttpClient__ = default(global::WindowsHttpClientSamples);
            var __windowsHttpClient__b__ = false;

            var ____count = 0;
            reader.ReadIsBeginObjectWithVerify();
            while (!reader.ReadIsEndObjectWithSkipValueSeparator(ref ____count))
            {
                var stringKey = reader.ReadPropertyNameSegmentRaw();
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    reader.ReadNextBlock();
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __www__ = formatterResolver.GetFormatterWithVerify<global::WWWSamples>().Deserialize(ref reader, formatterResolver);
                        __www__b__ = true;
                        break;
                    case 1:
                        __webRequest__ = formatterResolver.GetFormatterWithVerify<global::WebRequestSamples>().Deserialize(ref reader, formatterResolver);
                        __webRequest__b__ = true;
                        break;
                    case 2:
                        __httpWebRequest__ = formatterResolver.GetFormatterWithVerify<global::HttpWebRequestSamples>().Deserialize(ref reader, formatterResolver);
                        __httpWebRequest__b__ = true;
                        break;
                    case 3:
                        __systemHttpClient__ = formatterResolver.GetFormatterWithVerify<global::SystemHttpClientSamples>().Deserialize(ref reader, formatterResolver);
                        __systemHttpClient__b__ = true;
                        break;
                    case 4:
                        __windowsHttpClient__ = formatterResolver.GetFormatterWithVerify<global::WindowsHttpClientSamples>().Deserialize(ref reader, formatterResolver);
                        __windowsHttpClient__b__ = true;
                        break;
                    default:
                        reader.ReadNextBlock();
                        break;
                }

                NEXT_LOOP:
                continue;
            }

            var ____result = new global::NetworkClientSamples();
            if(__www__b__) ____result.www = __www__;
            if(__webRequest__b__) ____result.webRequest = __webRequest__;
            if(__httpWebRequest__b__) ____result.httpWebRequest = __httpWebRequest__;
            if(__systemHttpClient__b__) ____result.systemHttpClient = __systemHttpClient__;
            if(__windowsHttpClient__b__) ____result.windowsHttpClient = __windowsHttpClient__;

            return ____result;
        }
    }


    public sealed class AddressSerializableClassFieldFormatter : global::Utf8Json.IJsonFormatter<global::AddressSerializableClassField>
    {
        readonly global::Utf8Json.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public AddressSerializableClassFieldFormatter()
        {
            this.____keyMapping = new global::Utf8Json.Internal.AutomataDictionary()
            {
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("zipcode"), 0},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("address"), 1},
            };

            this.____stringByteKeys = new byte[][]
            {
                JsonWriter.GetEncodedPropertyNameWithBeginObject("zipcode"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("address"),
                
            };
        }

        public void Serialize(ref JsonWriter writer, global::AddressSerializableClassField value, global::Utf8Json.IJsonFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            

            writer.WriteRaw(this.____stringByteKeys[0]);
            writer.WriteInt32(value.zipcode);
            writer.WriteRaw(this.____stringByteKeys[1]);
            writer.WriteString(value.address);
            
            writer.WriteEndObject();
        }

        public global::AddressSerializableClassField Deserialize(ref JsonReader reader, global::Utf8Json.IJsonFormatterResolver formatterResolver)
        {
            if (reader.ReadIsNull())
            {
                return null;
            }
            

            var __zipcode__ = default(int);
            var __zipcode__b__ = false;
            var __address__ = default(string);
            var __address__b__ = false;

            var ____count = 0;
            reader.ReadIsBeginObjectWithVerify();
            while (!reader.ReadIsEndObjectWithSkipValueSeparator(ref ____count))
            {
                var stringKey = reader.ReadPropertyNameSegmentRaw();
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    reader.ReadNextBlock();
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __zipcode__ = reader.ReadInt32();
                        __zipcode__b__ = true;
                        break;
                    case 1:
                        __address__ = reader.ReadString();
                        __address__b__ = true;
                        break;
                    default:
                        reader.ReadNextBlock();
                        break;
                }

                NEXT_LOOP:
                continue;
            }

            var ____result = new global::AddressSerializableClassField();
            if(__zipcode__b__) ____result.zipcode = __zipcode__;
            if(__address__b__) ____result.address = __address__;

            return ____result;
        }
    }


    public sealed class PersonSerializableClassFieldFormatter : global::Utf8Json.IJsonFormatter<global::PersonSerializableClassField>
    {
        readonly global::Utf8Json.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public PersonSerializableClassFieldFormatter()
        {
            this.____keyMapping = new global::Utf8Json.Internal.AutomataDictionary()
            {
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("id"), 0},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("addresses"), 1},
            };

            this.____stringByteKeys = new byte[][]
            {
                JsonWriter.GetEncodedPropertyNameWithBeginObject("id"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("addresses"),
                
            };
        }

        public void Serialize(ref JsonWriter writer, global::PersonSerializableClassField value, global::Utf8Json.IJsonFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            

            writer.WriteRaw(this.____stringByteKeys[0]);
            writer.WriteInt32(value.id);
            writer.WriteRaw(this.____stringByteKeys[1]);
            formatterResolver.GetFormatterWithVerify<global::AddressSerializableClassField[]>().Serialize(ref writer, value.addresses, formatterResolver);
            
            writer.WriteEndObject();
        }

        public global::PersonSerializableClassField Deserialize(ref JsonReader reader, global::Utf8Json.IJsonFormatterResolver formatterResolver)
        {
            if (reader.ReadIsNull())
            {
                return null;
            }
            

            var __id__ = default(int);
            var __id__b__ = false;
            var __addresses__ = default(global::AddressSerializableClassField[]);
            var __addresses__b__ = false;

            var ____count = 0;
            reader.ReadIsBeginObjectWithVerify();
            while (!reader.ReadIsEndObjectWithSkipValueSeparator(ref ____count))
            {
                var stringKey = reader.ReadPropertyNameSegmentRaw();
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    reader.ReadNextBlock();
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __id__ = reader.ReadInt32();
                        __id__b__ = true;
                        break;
                    case 1:
                        __addresses__ = formatterResolver.GetFormatterWithVerify<global::AddressSerializableClassField[]>().Deserialize(ref reader, formatterResolver);
                        __addresses__b__ = true;
                        break;
                    default:
                        reader.ReadNextBlock();
                        break;
                }

                NEXT_LOOP:
                continue;
            }

            var ____result = new global::PersonSerializableClassField();
            if(__id__b__) ____result.id = __id__;
            if(__addresses__b__) ____result.addresses = __addresses__;

            return ____result;
        }
    }


    public sealed class AddressPlaneClassPropertyFormatter : global::Utf8Json.IJsonFormatter<global::AddressPlaneClassProperty>
    {
        readonly global::Utf8Json.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public AddressPlaneClassPropertyFormatter()
        {
            this.____keyMapping = new global::Utf8Json.Internal.AutomataDictionary()
            {
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("Zipcode"), 0},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("Address"), 1},
            };

            this.____stringByteKeys = new byte[][]
            {
                JsonWriter.GetEncodedPropertyNameWithBeginObject("Zipcode"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("Address"),
                
            };
        }

        public void Serialize(ref JsonWriter writer, global::AddressPlaneClassProperty value, global::Utf8Json.IJsonFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            

            writer.WriteRaw(this.____stringByteKeys[0]);
            writer.WriteInt32(value.Zipcode);
            writer.WriteRaw(this.____stringByteKeys[1]);
            writer.WriteString(value.Address);
            
            writer.WriteEndObject();
        }

        public global::AddressPlaneClassProperty Deserialize(ref JsonReader reader, global::Utf8Json.IJsonFormatterResolver formatterResolver)
        {
            if (reader.ReadIsNull())
            {
                return null;
            }
            

            var __Zipcode__ = default(int);
            var __Zipcode__b__ = false;
            var __Address__ = default(string);
            var __Address__b__ = false;

            var ____count = 0;
            reader.ReadIsBeginObjectWithVerify();
            while (!reader.ReadIsEndObjectWithSkipValueSeparator(ref ____count))
            {
                var stringKey = reader.ReadPropertyNameSegmentRaw();
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    reader.ReadNextBlock();
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __Zipcode__ = reader.ReadInt32();
                        __Zipcode__b__ = true;
                        break;
                    case 1:
                        __Address__ = reader.ReadString();
                        __Address__b__ = true;
                        break;
                    default:
                        reader.ReadNextBlock();
                        break;
                }

                NEXT_LOOP:
                continue;
            }

            var ____result = new global::AddressPlaneClassProperty();
            if(__Zipcode__b__) ____result.Zipcode = __Zipcode__;
            if(__Address__b__) ____result.Address = __Address__;

            return ____result;
        }
    }


    public sealed class PersonPlaneClassPropertyFormatter : global::Utf8Json.IJsonFormatter<global::PersonPlaneClassProperty>
    {
        readonly global::Utf8Json.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public PersonPlaneClassPropertyFormatter()
        {
            this.____keyMapping = new global::Utf8Json.Internal.AutomataDictionary()
            {
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("Id"), 0},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("Addresses"), 1},
            };

            this.____stringByteKeys = new byte[][]
            {
                JsonWriter.GetEncodedPropertyNameWithBeginObject("Id"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("Addresses"),
                
            };
        }

        public void Serialize(ref JsonWriter writer, global::PersonPlaneClassProperty value, global::Utf8Json.IJsonFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            

            writer.WriteRaw(this.____stringByteKeys[0]);
            writer.WriteInt32(value.Id);
            writer.WriteRaw(this.____stringByteKeys[1]);
            formatterResolver.GetFormatterWithVerify<global::AddressPlaneClassProperty[]>().Serialize(ref writer, value.Addresses, formatterResolver);
            
            writer.WriteEndObject();
        }

        public global::PersonPlaneClassProperty Deserialize(ref JsonReader reader, global::Utf8Json.IJsonFormatterResolver formatterResolver)
        {
            if (reader.ReadIsNull())
            {
                return null;
            }
            

            var __Id__ = default(int);
            var __Id__b__ = false;
            var __Addresses__ = default(global::AddressPlaneClassProperty[]);
            var __Addresses__b__ = false;

            var ____count = 0;
            reader.ReadIsBeginObjectWithVerify();
            while (!reader.ReadIsEndObjectWithSkipValueSeparator(ref ____count))
            {
                var stringKey = reader.ReadPropertyNameSegmentRaw();
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    reader.ReadNextBlock();
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __Id__ = reader.ReadInt32();
                        __Id__b__ = true;
                        break;
                    case 1:
                        __Addresses__ = formatterResolver.GetFormatterWithVerify<global::AddressPlaneClassProperty[]>().Deserialize(ref reader, formatterResolver);
                        __Addresses__b__ = true;
                        break;
                    default:
                        reader.ReadNextBlock();
                        break;
                }

                NEXT_LOOP:
                continue;
            }

            var ____result = new global::PersonPlaneClassProperty();
            if(__Id__b__) ____result.Id = __Id__;
            if(__Addresses__b__) ____result.Addresses = __Addresses__;

            return ____result;
        }
    }


    public sealed class AddressRenamedPropertyFormatter : global::Utf8Json.IJsonFormatter<global::AddressRenamedProperty>
    {
        readonly global::Utf8Json.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public AddressRenamedPropertyFormatter()
        {
            this.____keyMapping = new global::Utf8Json.Internal.AutomataDictionary()
            {
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("Foo"), 0},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("Bar"), 1},
            };

            this.____stringByteKeys = new byte[][]
            {
                JsonWriter.GetEncodedPropertyNameWithBeginObject("Foo"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("Bar"),
                
            };
        }

        public void Serialize(ref JsonWriter writer, global::AddressRenamedProperty value, global::Utf8Json.IJsonFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            

            writer.WriteRaw(this.____stringByteKeys[0]);
            writer.WriteInt32(value.Zipcode);
            writer.WriteRaw(this.____stringByteKeys[1]);
            writer.WriteString(value.Address);
            
            writer.WriteEndObject();
        }

        public global::AddressRenamedProperty Deserialize(ref JsonReader reader, global::Utf8Json.IJsonFormatterResolver formatterResolver)
        {
            if (reader.ReadIsNull())
            {
                return null;
            }
            

            var __Zipcode__ = default(int);
            var __Zipcode__b__ = false;
            var __Address__ = default(string);
            var __Address__b__ = false;

            var ____count = 0;
            reader.ReadIsBeginObjectWithVerify();
            while (!reader.ReadIsEndObjectWithSkipValueSeparator(ref ____count))
            {
                var stringKey = reader.ReadPropertyNameSegmentRaw();
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    reader.ReadNextBlock();
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __Zipcode__ = reader.ReadInt32();
                        __Zipcode__b__ = true;
                        break;
                    case 1:
                        __Address__ = reader.ReadString();
                        __Address__b__ = true;
                        break;
                    default:
                        reader.ReadNextBlock();
                        break;
                }

                NEXT_LOOP:
                continue;
            }

            var ____result = new global::AddressRenamedProperty();
            if(__Zipcode__b__) ____result.Zipcode = __Zipcode__;
            if(__Address__b__) ____result.Address = __Address__;

            return ____result;
        }
    }

}

#pragma warning disable 168
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 219
#pragma warning disable 168

namespace Utf8Json.Formatters.Utf8Json
{
    using System;
    using Utf8Json;


    public sealed class JsonFormatterAttributeFormatter : global::Utf8Json.IJsonFormatter<global::Utf8Json.JsonFormatterAttribute>
    {
        readonly global::Utf8Json.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public JsonFormatterAttributeFormatter()
        {
            this.____keyMapping = new global::Utf8Json.Internal.AutomataDictionary()
            {
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("FormatterType"), 0},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("Arguments"), 1},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("TypeId"), 2},
            };

            this.____stringByteKeys = new byte[][]
            {
                JsonWriter.GetEncodedPropertyNameWithBeginObject("FormatterType"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("Arguments"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("TypeId"),
                
            };
        }

        public void Serialize(ref JsonWriter writer, global::Utf8Json.JsonFormatterAttribute value, global::Utf8Json.IJsonFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            

            writer.WriteRaw(this.____stringByteKeys[0]);
            formatterResolver.GetFormatterWithVerify<global::System.Type>().Serialize(ref writer, value.FormatterType, formatterResolver);
            writer.WriteRaw(this.____stringByteKeys[1]);
            formatterResolver.GetFormatterWithVerify<object[]>().Serialize(ref writer, value.Arguments, formatterResolver);
            writer.WriteRaw(this.____stringByteKeys[2]);
            formatterResolver.GetFormatterWithVerify<object>().Serialize(ref writer, value.TypeId, formatterResolver);
            
            writer.WriteEndObject();
        }

        public global::Utf8Json.JsonFormatterAttribute Deserialize(ref JsonReader reader, global::Utf8Json.IJsonFormatterResolver formatterResolver)
        {
            if (reader.ReadIsNull())
            {
                return null;
            }
            

            var __FormatterType__ = default(global::System.Type);
            var __FormatterType__b__ = false;
            var __Arguments__ = default(object[]);
            var __Arguments__b__ = false;
            var __TypeId__ = default(object);
            var __TypeId__b__ = false;

            var ____count = 0;
            reader.ReadIsBeginObjectWithVerify();
            while (!reader.ReadIsEndObjectWithSkipValueSeparator(ref ____count))
            {
                var stringKey = reader.ReadPropertyNameSegmentRaw();
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    reader.ReadNextBlock();
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __FormatterType__ = formatterResolver.GetFormatterWithVerify<global::System.Type>().Deserialize(ref reader, formatterResolver);
                        __FormatterType__b__ = true;
                        break;
                    case 1:
                        __Arguments__ = formatterResolver.GetFormatterWithVerify<object[]>().Deserialize(ref reader, formatterResolver);
                        __Arguments__b__ = true;
                        break;
                    case 2:
                        __TypeId__ = formatterResolver.GetFormatterWithVerify<object>().Deserialize(ref reader, formatterResolver);
                        __TypeId__b__ = true;
                        break;
                    default:
                        reader.ReadNextBlock();
                        break;
                }

                NEXT_LOOP:
                continue;
            }

            var ____result = new global::Utf8Json.JsonFormatterAttribute(__FormatterType__);

            return ____result;
        }
    }


    public sealed class SerializationConstructorAttributeFormatter : global::Utf8Json.IJsonFormatter<global::Utf8Json.SerializationConstructorAttribute>
    {
        readonly global::Utf8Json.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public SerializationConstructorAttributeFormatter()
        {
            this.____keyMapping = new global::Utf8Json.Internal.AutomataDictionary()
            {
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("TypeId"), 0},
            };

            this.____stringByteKeys = new byte[][]
            {
                JsonWriter.GetEncodedPropertyNameWithBeginObject("TypeId"),
                
            };
        }

        public void Serialize(ref JsonWriter writer, global::Utf8Json.SerializationConstructorAttribute value, global::Utf8Json.IJsonFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            

            writer.WriteRaw(this.____stringByteKeys[0]);
            formatterResolver.GetFormatterWithVerify<object>().Serialize(ref writer, value.TypeId, formatterResolver);
            
            writer.WriteEndObject();
        }

        public global::Utf8Json.SerializationConstructorAttribute Deserialize(ref JsonReader reader, global::Utf8Json.IJsonFormatterResolver formatterResolver)
        {
            if (reader.ReadIsNull())
            {
                return null;
            }
            

            var __TypeId__ = default(object);
            var __TypeId__b__ = false;

            var ____count = 0;
            reader.ReadIsBeginObjectWithVerify();
            while (!reader.ReadIsEndObjectWithSkipValueSeparator(ref ____count))
            {
                var stringKey = reader.ReadPropertyNameSegmentRaw();
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    reader.ReadNextBlock();
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __TypeId__ = formatterResolver.GetFormatterWithVerify<object>().Deserialize(ref reader, formatterResolver);
                        __TypeId__b__ = true;
                        break;
                    default:
                        reader.ReadNextBlock();
                        break;
                }

                NEXT_LOOP:
                continue;
            }

            var ____result = new global::Utf8Json.SerializationConstructorAttribute();

            return ____result;
        }
    }


    public sealed class FormatterNotRegisteredExceptionFormatter : global::Utf8Json.IJsonFormatter<global::Utf8Json.FormatterNotRegisteredException>
    {
        readonly global::Utf8Json.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public FormatterNotRegisteredExceptionFormatter()
        {
            this.____keyMapping = new global::Utf8Json.Internal.AutomataDictionary()
            {
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("Message"), 0},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("Data"), 1},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("InnerException"), 2},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("TargetSite"), 3},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("StackTrace"), 4},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("HelpLink"), 5},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("Source"), 6},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("HResult"), 7},
            };

            this.____stringByteKeys = new byte[][]
            {
                JsonWriter.GetEncodedPropertyNameWithBeginObject("Message"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("Data"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("InnerException"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("TargetSite"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("StackTrace"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("HelpLink"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("Source"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("HResult"),
                
            };
        }

        public void Serialize(ref JsonWriter writer, global::Utf8Json.FormatterNotRegisteredException value, global::Utf8Json.IJsonFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            

            writer.WriteRaw(this.____stringByteKeys[0]);
            writer.WriteString(value.Message);
            writer.WriteRaw(this.____stringByteKeys[1]);
            formatterResolver.GetFormatterWithVerify<global::System.Collections.IDictionary>().Serialize(ref writer, value.Data, formatterResolver);
            writer.WriteRaw(this.____stringByteKeys[2]);
            formatterResolver.GetFormatterWithVerify<global::System.Exception>().Serialize(ref writer, value.InnerException, formatterResolver);
            writer.WriteRaw(this.____stringByteKeys[3]);
            formatterResolver.GetFormatterWithVerify<global::System.Reflection.MethodBase>().Serialize(ref writer, value.TargetSite, formatterResolver);
            writer.WriteRaw(this.____stringByteKeys[4]);
            writer.WriteString(value.StackTrace);
            writer.WriteRaw(this.____stringByteKeys[5]);
            writer.WriteString(value.HelpLink);
            writer.WriteRaw(this.____stringByteKeys[6]);
            writer.WriteString(value.Source);
            writer.WriteRaw(this.____stringByteKeys[7]);
            writer.WriteInt32(value.HResult);
            
            writer.WriteEndObject();
        }

        public global::Utf8Json.FormatterNotRegisteredException Deserialize(ref JsonReader reader, global::Utf8Json.IJsonFormatterResolver formatterResolver)
        {
            if (reader.ReadIsNull())
            {
                return null;
            }
            

            var __Message__ = default(string);
            var __Message__b__ = false;
            var __Data__ = default(global::System.Collections.IDictionary);
            var __Data__b__ = false;
            var __InnerException__ = default(global::System.Exception);
            var __InnerException__b__ = false;
            var __TargetSite__ = default(global::System.Reflection.MethodBase);
            var __TargetSite__b__ = false;
            var __StackTrace__ = default(string);
            var __StackTrace__b__ = false;
            var __HelpLink__ = default(string);
            var __HelpLink__b__ = false;
            var __Source__ = default(string);
            var __Source__b__ = false;
            var __HResult__ = default(int);
            var __HResult__b__ = false;

            var ____count = 0;
            reader.ReadIsBeginObjectWithVerify();
            while (!reader.ReadIsEndObjectWithSkipValueSeparator(ref ____count))
            {
                var stringKey = reader.ReadPropertyNameSegmentRaw();
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    reader.ReadNextBlock();
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __Message__ = reader.ReadString();
                        __Message__b__ = true;
                        break;
                    case 1:
                        __Data__ = formatterResolver.GetFormatterWithVerify<global::System.Collections.IDictionary>().Deserialize(ref reader, formatterResolver);
                        __Data__b__ = true;
                        break;
                    case 2:
                        __InnerException__ = formatterResolver.GetFormatterWithVerify<global::System.Exception>().Deserialize(ref reader, formatterResolver);
                        __InnerException__b__ = true;
                        break;
                    case 3:
                        __TargetSite__ = formatterResolver.GetFormatterWithVerify<global::System.Reflection.MethodBase>().Deserialize(ref reader, formatterResolver);
                        __TargetSite__b__ = true;
                        break;
                    case 4:
                        __StackTrace__ = reader.ReadString();
                        __StackTrace__b__ = true;
                        break;
                    case 5:
                        __HelpLink__ = reader.ReadString();
                        __HelpLink__b__ = true;
                        break;
                    case 6:
                        __Source__ = reader.ReadString();
                        __Source__b__ = true;
                        break;
                    case 7:
                        __HResult__ = reader.ReadInt32();
                        __HResult__b__ = true;
                        break;
                    default:
                        reader.ReadNextBlock();
                        break;
                }

                NEXT_LOOP:
                continue;
            }

            var ____result = new global::Utf8Json.FormatterNotRegisteredException(__Message__);
            if(__HelpLink__b__) ____result.HelpLink = __HelpLink__;
            if(__Source__b__) ____result.Source = __Source__;

            return ____result;
        }
    }


    public sealed class JsonParsingExceptionFormatter : global::Utf8Json.IJsonFormatter<global::Utf8Json.JsonParsingException>
    {
        readonly global::Utf8Json.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public JsonParsingExceptionFormatter()
        {
            this.____keyMapping = new global::Utf8Json.Internal.AutomataDictionary()
            {
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("Offset"), 0},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("ActualChar"), 1},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("Message"), 2},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("Data"), 3},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("InnerException"), 4},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("TargetSite"), 5},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("StackTrace"), 6},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("HelpLink"), 7},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("Source"), 8},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("HResult"), 9},
            };

            this.____stringByteKeys = new byte[][]
            {
                JsonWriter.GetEncodedPropertyNameWithBeginObject("Offset"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("ActualChar"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("Message"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("Data"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("InnerException"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("TargetSite"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("StackTrace"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("HelpLink"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("Source"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("HResult"),
                
            };
        }

        public void Serialize(ref JsonWriter writer, global::Utf8Json.JsonParsingException value, global::Utf8Json.IJsonFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            

            writer.WriteRaw(this.____stringByteKeys[0]);
            writer.WriteInt32(value.Offset);
            writer.WriteRaw(this.____stringByteKeys[1]);
            writer.WriteString(value.ActualChar);
            writer.WriteRaw(this.____stringByteKeys[2]);
            writer.WriteString(value.Message);
            writer.WriteRaw(this.____stringByteKeys[3]);
            formatterResolver.GetFormatterWithVerify<global::System.Collections.IDictionary>().Serialize(ref writer, value.Data, formatterResolver);
            writer.WriteRaw(this.____stringByteKeys[4]);
            formatterResolver.GetFormatterWithVerify<global::System.Exception>().Serialize(ref writer, value.InnerException, formatterResolver);
            writer.WriteRaw(this.____stringByteKeys[5]);
            formatterResolver.GetFormatterWithVerify<global::System.Reflection.MethodBase>().Serialize(ref writer, value.TargetSite, formatterResolver);
            writer.WriteRaw(this.____stringByteKeys[6]);
            writer.WriteString(value.StackTrace);
            writer.WriteRaw(this.____stringByteKeys[7]);
            writer.WriteString(value.HelpLink);
            writer.WriteRaw(this.____stringByteKeys[8]);
            writer.WriteString(value.Source);
            writer.WriteRaw(this.____stringByteKeys[9]);
            writer.WriteInt32(value.HResult);
            
            writer.WriteEndObject();
        }

        public global::Utf8Json.JsonParsingException Deserialize(ref JsonReader reader, global::Utf8Json.IJsonFormatterResolver formatterResolver)
        {
            if (reader.ReadIsNull())
            {
                return null;
            }
            

            var __Offset__ = default(int);
            var __Offset__b__ = false;
            var __ActualChar__ = default(string);
            var __ActualChar__b__ = false;
            var __Message__ = default(string);
            var __Message__b__ = false;
            var __Data__ = default(global::System.Collections.IDictionary);
            var __Data__b__ = false;
            var __InnerException__ = default(global::System.Exception);
            var __InnerException__b__ = false;
            var __TargetSite__ = default(global::System.Reflection.MethodBase);
            var __TargetSite__b__ = false;
            var __StackTrace__ = default(string);
            var __StackTrace__b__ = false;
            var __HelpLink__ = default(string);
            var __HelpLink__b__ = false;
            var __Source__ = default(string);
            var __Source__b__ = false;
            var __HResult__ = default(int);
            var __HResult__b__ = false;

            var ____count = 0;
            reader.ReadIsBeginObjectWithVerify();
            while (!reader.ReadIsEndObjectWithSkipValueSeparator(ref ____count))
            {
                var stringKey = reader.ReadPropertyNameSegmentRaw();
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    reader.ReadNextBlock();
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __Offset__ = reader.ReadInt32();
                        __Offset__b__ = true;
                        break;
                    case 1:
                        __ActualChar__ = reader.ReadString();
                        __ActualChar__b__ = true;
                        break;
                    case 2:
                        __Message__ = reader.ReadString();
                        __Message__b__ = true;
                        break;
                    case 3:
                        __Data__ = formatterResolver.GetFormatterWithVerify<global::System.Collections.IDictionary>().Deserialize(ref reader, formatterResolver);
                        __Data__b__ = true;
                        break;
                    case 4:
                        __InnerException__ = formatterResolver.GetFormatterWithVerify<global::System.Exception>().Deserialize(ref reader, formatterResolver);
                        __InnerException__b__ = true;
                        break;
                    case 5:
                        __TargetSite__ = formatterResolver.GetFormatterWithVerify<global::System.Reflection.MethodBase>().Deserialize(ref reader, formatterResolver);
                        __TargetSite__b__ = true;
                        break;
                    case 6:
                        __StackTrace__ = reader.ReadString();
                        __StackTrace__b__ = true;
                        break;
                    case 7:
                        __HelpLink__ = reader.ReadString();
                        __HelpLink__b__ = true;
                        break;
                    case 8:
                        __Source__ = reader.ReadString();
                        __Source__b__ = true;
                        break;
                    case 9:
                        __HResult__ = reader.ReadInt32();
                        __HResult__b__ = true;
                        break;
                    default:
                        reader.ReadNextBlock();
                        break;
                }

                NEXT_LOOP:
                continue;
            }

            var ____result = new global::Utf8Json.JsonParsingException(__Message__);
            if(__ActualChar__b__) ____result.ActualChar = __ActualChar__;
            if(__HelpLink__b__) ____result.HelpLink = __HelpLink__;
            if(__Source__b__) ____result.Source = __Source__;

            return ____result;
        }
    }

}

#pragma warning disable 168
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 219
#pragma warning disable 168

namespace Utf8Json.Formatters.Utf8Json.Resolvers
{
    using System;
    using Utf8Json;


    public sealed class DynamicCompositeResolverFormatter : global::Utf8Json.IJsonFormatter<global::Utf8Json.Resolvers.DynamicCompositeResolver>
    {
        readonly global::Utf8Json.Internal.AutomataDictionary ____keyMapping;
        readonly byte[][] ____stringByteKeys;

        public DynamicCompositeResolverFormatter()
        {
            this.____keyMapping = new global::Utf8Json.Internal.AutomataDictionary()
            {
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("formatters"), 0},
                { JsonWriter.GetEncodedPropertyNameWithoutQuotation("resolvers"), 1},
            };

            this.____stringByteKeys = new byte[][]
            {
                JsonWriter.GetEncodedPropertyNameWithBeginObject("formatters"),
                JsonWriter.GetEncodedPropertyNameWithPrefixValueSeparator("resolvers"),
                
            };
        }

        public void Serialize(ref JsonWriter writer, global::Utf8Json.Resolvers.DynamicCompositeResolver value, global::Utf8Json.IJsonFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            

            writer.WriteRaw(this.____stringByteKeys[0]);
            formatterResolver.GetFormatterWithVerify<global::Utf8Json.IJsonFormatter[]>().Serialize(ref writer, value.formatters, formatterResolver);
            writer.WriteRaw(this.____stringByteKeys[1]);
            formatterResolver.GetFormatterWithVerify<global::Utf8Json.IJsonFormatterResolver[]>().Serialize(ref writer, value.resolvers, formatterResolver);
            
            writer.WriteEndObject();
        }

        public global::Utf8Json.Resolvers.DynamicCompositeResolver Deserialize(ref JsonReader reader, global::Utf8Json.IJsonFormatterResolver formatterResolver)
        {
            if (reader.ReadIsNull())
            {
                return null;
            }
            

            var __formatters__ = default(global::Utf8Json.IJsonFormatter[]);
            var __formatters__b__ = false;
            var __resolvers__ = default(global::Utf8Json.IJsonFormatterResolver[]);
            var __resolvers__b__ = false;

            var ____count = 0;
            reader.ReadIsBeginObjectWithVerify();
            while (!reader.ReadIsEndObjectWithSkipValueSeparator(ref ____count))
            {
                var stringKey = reader.ReadPropertyNameSegmentRaw();
                int key;
                if (!____keyMapping.TryGetValueSafe(stringKey, out key))
                {
                    reader.ReadNextBlock();
                    goto NEXT_LOOP;
                }

                switch (key)
                {
                    case 0:
                        __formatters__ = formatterResolver.GetFormatterWithVerify<global::Utf8Json.IJsonFormatter[]>().Deserialize(ref reader, formatterResolver);
                        __formatters__b__ = true;
                        break;
                    case 1:
                        __resolvers__ = formatterResolver.GetFormatterWithVerify<global::Utf8Json.IJsonFormatterResolver[]>().Deserialize(ref reader, formatterResolver);
                        __resolvers__b__ = true;
                        break;
                    default:
                        reader.ReadNextBlock();
                        break;
                }

                NEXT_LOOP:
                continue;
            }

            var ____result = (global::Utf8Json.Resolvers.DynamicCompositeResolver)global::Utf8Json.Resolvers.DynamicCompositeResolver.Create(__formatters__, __resolvers__);

            return ____result;
        }
    }

}

#pragma warning disable 168
#pragma warning restore 219
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
