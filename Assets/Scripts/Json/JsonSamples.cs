using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using UnityEngine;
using Utf8Json;
using JsonSerializer = Utf8Json.JsonSerializer;

public class JsonSamples : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Utf8Json.Resolvers.CompositeResolver.RegisterAndSetAsDefault(
        //    Utf8Json.Resolvers.GeneratedResolver.Instance,
        //    Utf8Json.Resolvers.StandardResolver.Default);

        JsonUtilitySample();
        NewtonsofJsonSample();
        Utf8JsonSample();
    }

    private void JsonUtilitySample()
    {
        // JsonUtility : Unity純正、速いが制約多め
        var target = new PersonSerializableClassField
        {
            id = 200,
            addresses = new AddressSerializableClassField[]
            {
                new AddressSerializableClassField{ zipcode = 1002321, address = "hoge" },
                new AddressSerializableClassField{ zipcode = 1008492, address = "fuga" },
            },
        };

        var serialized = JsonUtility.ToJson(target);
        Debug.Log(serialized);

        var deserialized = JsonUtility.FromJson<PersonSerializableClassField>(serialized);
        Debug.Log(deserialized.ToString());
    }

    private void NewtonsofJsonSample()
    {
        // Json.NET : C#におけるメジャーどころ、遅いが汎用的で拡張性がある
        {
            var target = new PersonSerializableClassField
            {
                id = 100,
                addresses = new AddressSerializableClassField[]
                {
                    new AddressSerializableClassField{ zipcode = 1002321, address = "hoge" },
                    new AddressSerializableClassField{ zipcode = 1008492, address = "fuga" },
                },
            };

            var serialized = JsonConvert.SerializeObject(target);
            Debug.Log(serialized);

            var deserialized = JsonConvert.DeserializeObject<PersonSerializableClassField>(serialized);
            Debug.Log(deserialized.ToString());
        }

        {
            var target = new PersonPlaneClassProperty
            {
                Id = 200,
                Addresses = new AddressPlaneClassProperty[]
                {
                    new AddressPlaneClassProperty{ Zipcode = 2003921, Address = "hoge" },
                    new AddressPlaneClassProperty{ Zipcode = 2002955, Address = "fuga" },
                },
            };

            var serialized = JsonConvert.SerializeObject(target);
            Debug.Log(serialized);

            var deserialized = JsonConvert.DeserializeObject<PersonPlaneClassProperty>(serialized);
            Debug.Log(deserialized.ToString());
        }

        {
            var target = new AddressRenamedProperty
            {
                Zipcode = 3003924,
                Address = "foobar",
                TelephoneNumber = "0312345678",
            };

            var serialized = JsonConvert.SerializeObject(target);
            Debug.Log(serialized);

            var deserialized = JsonConvert.DeserializeObject<AddressRenamedProperty>(serialized);
            Debug.Log(deserialized.ToString());
        }
    }

    private void Utf8JsonSample()
    {
        // UTF8Json : neuecc氏作、JsonUtilityと同様速い上に汎用的
        // Dose'nt work on HoloLens2 (IL2CPPxARM64)
        {
            var target = new PersonSerializableClassField
            {
                id = 100,
                addresses = new AddressSerializableClassField[]
                {
                    new AddressSerializableClassField{ zipcode = 1002321, address = "hoge" },
                    new AddressSerializableClassField{ zipcode = 1008492, address = "fuga" },
                },
            };
            {
                var serialized = JsonSerializer.ToJsonString(target);
                Debug.Log(serialized);

                var deserialized = JsonSerializer.Deserialize<PersonSerializableClassField>(serialized);
                Debug.Log(deserialized.ToString());
            }

            {
                var serialized = JsonSerializer.Serialize(target);
                Debug.Log(Convert.ToBase64String(serialized));
                var tmp = System.Text.Encoding.UTF8.GetString(serialized);
                Debug.Log(tmp);


                var deserialized = JsonSerializer.Deserialize<PersonSerializableClassField>(serialized);
                Debug.Log(deserialized.ToString());
            }
        }

        {
            var target = new PersonPlaneClassProperty
            {
                Id = 200,
                Addresses = new AddressPlaneClassProperty[]
                {
                    new AddressPlaneClassProperty{ Zipcode = 2003921, Address = "hoge" },
                    new AddressPlaneClassProperty{ Zipcode = 2002955, Address = "fuga" },
                },
            };

            var serialized = JsonSerializer.Serialize(target);
            Debug.Log(Convert.ToBase64String(serialized));
            var tmp = System.Text.Encoding.UTF8.GetString(serialized);
            Debug.Log(tmp);

            var deserialized = JsonSerializer.Deserialize<PersonPlaneClassProperty>(serialized);
            Debug.Log(deserialized.ToString());
        }

        {
            var target = new AddressRenamedProperty
            {
                Zipcode = 3003924,
                Address = "foobar",
                TelephoneNumber = "0312345678",
            };

            var serialized = JsonSerializer.Serialize(target);
            Debug.Log(Convert.ToBase64String(serialized));
            var tmp = System.Text.Encoding.UTF8.GetString(serialized);
            Debug.Log(tmp);

            var deserialized = JsonSerializer.Deserialize<AddressRenamedProperty>(serialized);
            Debug.Log(deserialized.ToString());
        }
    }
}

[Serializable]
public class PersonSerializableClassField
{
    public int id;
    public AddressSerializableClassField[] addresses;

    public override string ToString()
    {
        return $@"{nameof(PersonSerializableClassField)}{{
{nameof(id)}:{id},
{nameof(addresses)}{{
{string.Join("\r\n", addresses.Select(x => x.ToString()))}
}}
}}";
    }
}

[Serializable]
public class AddressSerializableClassField
{
    public int zipcode;
    public string address;

    public override string ToString()
    {
        return $@"{nameof(zipcode)}:{zipcode}, {nameof(address)}:{address}";
    }
}

public class PersonPlaneClassProperty
{
    public int Id { get; set; }
    public AddressPlaneClassProperty[] Addresses { get; set; }
    public override string ToString()
    {
        return $@"{nameof(PersonPlaneClassProperty)}{{
{nameof(Id)}:{Id},
{nameof(Addresses)}{{
{string.Join("\r\n", Addresses.Select(x => x.ToString()))}
}}
}}";
    }
}

public class AddressPlaneClassProperty
{
    public int Zipcode { get; set; }
    public string Address { get; set; }

    public override string ToString()
    {
        return $@"{nameof(Zipcode)}:{Zipcode}, {nameof(Address)}:{Address}";
    }
}

public class AddressRenamedProperty
{
    [JsonProperty("Foo")]
    [DataMember(Name = "Foo")]
    public int Zipcode { get; set; }

    [JsonProperty("Bar")]
    [DataMember(Name = "Bar")]
    public string Address { get; set; }

    [JsonIgnore]
    [IgnoreDataMember]
    public string TelephoneNumber { get; set; }

    public override string ToString()
    {
        return $@"{nameof(AddressRenamedProperty)}
{nameof(Zipcode)}:{Zipcode}, {nameof(Address)}:{Address}, {nameof(TelephoneNumber)}:{TelephoneNumber}";
    }
}