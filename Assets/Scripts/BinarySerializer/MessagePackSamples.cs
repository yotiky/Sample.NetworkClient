using MessagePack;
using MessagePack.Resolvers;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class Startup
{
    static bool serializerRegistered = false;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Initialize()
    {
        if (!serializerRegistered)
        {
            StaticCompositeResolver.Instance.Register(
                 MessagePack.Resolvers.GeneratedResolver.Instance,
                 MessagePack.Resolvers.StandardResolver.Instance
            );

            var option = MessagePackSerializerOptions.Standard.WithResolver(StaticCompositeResolver.Instance);

            MessagePackSerializer.DefaultOptions = option;
            serializerRegistered = true;
        }
    }

#if UNITY_EDITOR


    [UnityEditor.InitializeOnLoadMethod]
    static void EditorInitialize()
    {
        Initialize();
    }

#endif
}

public class MessagePackSamples : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MessagePackSample();
    }

    private void MessagePackSample()
    {
        Debug.Log("#Basic and ConvertToJson/ConvertFromJson, SerializeToJson samples.");
        {
            var target = new PersonBasic
            {
                Id = 0,
                Addresses = new AddressBasic[]
                {
                    new AddressBasic{ Zipcode = 1002321, Address = "hoge", TelephoneNumber = "0120198198" },
                    new AddressBasic{ Zipcode = 1008492, Address = "fuga", TelephoneNumber = "0120231564" },
                },
            };
            var serialized = MessagePackSerializer.Serialize(target);
            var json = MessagePackSerializer.ConvertToJson(serialized);
            Debug.Log(json);

            var serializedFromJson = MessagePackSerializer.ConvertFromJson(json);
            var deserialized = MessagePackSerializer.Deserialize<PersonBasic>(serializedFromJson);
            Debug.Log(MessagePackSerializer.SerializeToJson(deserialized));
        }

        Debug.Log("#Attribute for properties sample.");
        {
            var target = new AddressSample1
            {
                Zipcode = 100,
                Address = "hogehoge",
                TelephoneNumber = "0120999999",
            };
            var serialized = MessagePackSerializer.Serialize(target);
            Debug.Log(MessagePackSerializer.ConvertToJson(serialized));

            var deserialized = MessagePackSerializer.Deserialize<AddressSample1>(serialized);
            Debug.Log(MessagePackSerializer.SerializeToJson(deserialized));
        }

        Debug.Log("#Non-Attribute at property sample.");
        {
            var target = new AddressSample2
            {
                Zipcode = 200,
                Address = "hogehoge"
            };
            var serialized = MessagePackSerializer.Serialize(target);
            Debug.Log(MessagePackSerializer.ConvertToJson(serialized));

            var deserialized = MessagePackSerializer.Deserialize<AddressSample2>(serialized);
            Debug.Log(MessagePackSerializer.SerializeToJson(deserialized));
        }

        Debug.Log("#Plane class like Json.NET.");
        {
            var target = new AddressSample3
            {
                Zipcode = 300,
                Address = "hogehoge"
            };
            var serialized = MessagePackSerializer.Serialize(target, MessagePack.Resolvers.ContractlessStandardResolver.Options);
            Debug.Log(MessagePackSerializer.ConvertToJson(serialized));

            var deserialized = MessagePackSerializer.Deserialize<AddressSample3>(serialized, MessagePack.Resolvers.ContractlessStandardResolver.Options);
            Debug.Log(MessagePackSerializer.SerializeToJson(deserialized, MessagePack.Resolvers.ContractlessStandardResolver.Options));

            // MessagePack.Resolvers.DynamicObjectResolverAllowPrivate.Optionsを使うとプライベートメンバーにも対応
        }

        Debug.Log("#Using interface sample.");
        {
            IUnionSample target = new FooClass { Zipcode = 400 };
            var serialized = MessagePackSerializer.Serialize(target);
            Debug.Log(MessagePackSerializer.ConvertToJson(serialized));

            var deserialized = MessagePackSerializer.Deserialize<IUnionSample>(serialized);

            // C# 7が使えない場合は、as か インターフェイスに識別子を持たせるなど
            switch (deserialized)
            {
                case FooClass x:
                    Debug.Log(x.Zipcode);
                    break;
                case BarClass x:
                    Debug.Log(x.Address);
                    break;
                default:
                    break;
            }
        }

        Debug.Log("#Using stream sample.");
        {
            var target = new AddressSample1
            {
                Zipcode = 500,
                Address = "hoge"
            };
            using (var stream = new MemoryStream())
            {
                MessagePackSerializer.SerializeAsync(stream, target).Wait();
                var serialized = stream.ToArray();

                var deserialized = MessagePackSerializer.Deserialize<AddressSample1>(serialized);
                Debug.Log(MessagePackSerializer.ConvertToJson(serialized));

                stream.Position = 0;
                var deserializedFromStream = (AddressSample1)MessagePackSerializer.DeserializeAsync(typeof(AddressSample1), stream).Result;
                Debug.Log(MessagePackSerializer.SerializeToJson(deserializedFromStream));
            }
        }
    }

    [MessagePackObject]
    public class PersonBasic
    {
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        public AddressBasic[] Addresses { get; set; }

        public override string ToString()
        {
            return $@"{nameof(PersonBasic)}{{
{nameof(Id)}:{Id},
{nameof(Addresses)}{{
{string.Join("\r\n", Addresses.Select(x => x.ToString()))}
}}
}}";
        }
    }
    [MessagePackObject]
    public class AddressBasic
    {
        [Key(2)]
        public string TelephoneNumber { get; set; }
        [Key(0)]
        public int Zipcode { get; set; }
        [Key(1)]
        public string Address { get; set; }

        public override string ToString()
        {
            return $@"{nameof(Zipcode)}:{Zipcode}, {nameof(Address)}:{Address}, {nameof(TelephoneNumber)}:{TelephoneNumber}";
        }
    }

    [MessagePackObject]
    public class AddressSample1
    {
        [Key("Foo")]
        public int Zipcode { get; set; }
        [Key("Bar")]
        public string Address { get; set; }
        [IgnoreMember]
        public string TelephoneNumber { get; set; }
    }

    [MessagePackObject(true)]
    public class AddressSample2
    {
        public int Zipcode { get; set; }
        public string Address { get; set; }
    }

    public class AddressSample3
    {
        public int Zipcode { get; set; }
        public string Address { get; set; }
    }

    [MessagePack.Union(0, typeof(FooClass))]
    [MessagePack.Union(1, typeof(BarClass))]
    public interface IUnionSample
    {
    }
    [MessagePackObject]
    public class FooClass : IUnionSample
    {
        [Key(0)]
        public int Zipcode { get; set; }
    }
    [MessagePackObject]
    public class BarClass : IUnionSample
    {
        [Key(0)]
        public string Address { get; set; }
    }
}